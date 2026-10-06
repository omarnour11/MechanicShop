using System.Security.Claims;
using System.Security.Principal;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MyMechanicShop.Application.Common.Errors;
using MyMechanicShop.Application.Interfaces;
using MyMechanicShop.Domain.Common.Results;

namespace MyMechanicShop.Application.Features.Identity.Queries.RefreshToken;


public class RefreshTokenQueryHandler(ILogger<RefreshTokenQueryHandler> logger 
,IIdentityService identityService , IAppDbContext context , ITokenProvider tokenProvider) : IRequestHandler<RefreshTokenQuery,Result<TokenResponse>>
{
    private readonly ILogger<RefreshTokenQueryHandler> _logger = logger;
    private readonly IIdentityService _identityService = identityService;
    private readonly IAppDbContext _context = context;
    private readonly ITokenProvider _tokenProvider = tokenProvider;

    public async Task<Result<TokenResponse>> Handle (RefreshTokenQuery query , CancellationToken ct)
    {
        var principal =  _tokenProvider.GetPrincipalFromExpiredToken(query.ExpiredAccessToken);
        if(principal is null)
        {
            _logger.LogError("Expired access token is not valid");
            
            return ApplicationErrors.ExpiredAccessTokenInvalid;

        }

        var userId = principal.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        if(userId is null)
        {

          _logger.LogError("Invalid userId claim");

          return ApplicationErrors.UserIdClaimInvalid;

        }

        var getUserResult = await _identityService.GetUserByIdAsync(userId);

        if (getUserResult.IsError)
        {
            _logger.LogError("Get user by id error occurred: {ErrorDescription}", getUserResult.TopError.Description);
            return getUserResult.Errors;
        }

        var refreshToken = await _context.RefreshTokens.FirstOrDefaultAsync(
            r => r.Token == query.RefreshToken && r.UserId == userId,
            ct);

        if (refreshToken is null ||
            refreshToken.ExpiresOnUtc <= DateTimeOffset.UtcNow)
        {
            _logger.LogWarning("Refresh token is missing or expired");

            return ApplicationErrors.InvalidRefreshToken;
        }

        var generateTokenResult = await _tokenProvider.GenerateJwtTokenAsync(
            getUserResult.Value,
            ct);

        if (generateTokenResult.IsError)
        {
            return generateTokenResult.Errors;
        }

        return generateTokenResult.Value;
    }
}