
using MediatR;
using MyMechanicShop.Application.Features.Identity.Dtos;
using MyMechanicShop.Domain.Common.Results;

namespace MyMechanicShop.Application.Features.Identity.Queries.GetUserInfo;
public sealed record GetUserByIdQuery(string? UserId) : IRequest<Result<AppUserDto>>;