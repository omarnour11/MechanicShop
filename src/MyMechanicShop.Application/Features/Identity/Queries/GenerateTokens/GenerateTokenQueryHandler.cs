using MediatR;
using Microsoft.Extensions.Logging;
using MyMechanicShop.Application.Interfaces;
using MyMechanicShop.Domain.Common.Results;

namespace MyMechanicShop.Application.Features.Identity.Queries.GenerateTokens;


public class GenerateTokenQueryHandler(ILogger<GenerateTokenQueryHandler> logger,
                                       IIdentityService identityService,
                                       ITokenProvider tokenProvider) 
: IRequestHandler<GenerateTokenQuery , Result<TokenResponse>>

{
    private readonly ILogger<GenerateTokenQueryHandler> _logger = logger;
    private readonly IIdentityService _identityService = identityService;
    private readonly ITokenProvider _tokenProvider = tokenProvider;

    public async Task<Result<TokenResponse>> Handle(GenerateTokenQuery query,
                                              CancellationToken ct)
    {
        var userResult = await _identityService.AuthenticateAsync(query.Email,query.Password);
   
        if (userResult.IsError)
        {
            return userResult.Errors;
        }

        var generateTokenResult = await _tokenProvider.GenerateJwtTokenAsync(userResult.Value,ct);

        if(generateTokenResult.IsError)
        {
            return generateTokenResult.Errors;
        }

        return generateTokenResult.Value;
    }

}