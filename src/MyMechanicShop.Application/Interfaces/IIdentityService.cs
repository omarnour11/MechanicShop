using MyMechanicShop.Application.Features.Identity.Dtos;
using MyMechanicShop.Domain.Common.Results;

namespace MyMechanicShop.Application.Interfaces;

public interface IIdentityService
{
    Task<bool> IsInRoleAsync(string userId, string role);
    Task<bool> AuthorizeAsync(string userId, string? policyName);
    Task<Result<AppUserDto>> AuthenticateAsync(string email, string password);
    Task<Result<AppUserDto>> GetUserByIdAsync(string userId);
    Task<string?> GetUserNameAsync(string userId);
}
