using System.Security.Claims;

using MyMechanicShop.Application.Features.Identity;
using MyMechanicShop.Application.Features.Identity.Dtos;
using MyMechanicShop.Domain.Common.Results;

namespace MyMechanicShop.Application.Interfaces;

public interface ITokenProvider
{
    Task<Result<TokenResponse>> GenerateJwtTokenAsync(AppUserDto user, CancellationToken ct = default);
    ClaimsPrincipal? GetPrincipalFromExpiredToken(string token);
}
