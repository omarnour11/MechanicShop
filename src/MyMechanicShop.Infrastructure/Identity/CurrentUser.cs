using System.Security.Claims;

using MyMechanicShop.Application.Interfaces;

using Microsoft.AspNetCore.Http;

namespace MyMechanicShop.Infrastructure.Identity;

public sealed class CurrentUser(IHttpContextAccessor httpContextAccessor) : IUser
{
    public string? Id =>
        httpContextAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier) ??
        httpContextAccessor.HttpContext?.User.FindFirstValue("sub");
}
