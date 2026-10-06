using MediatR;
using MyMechanicShop.Domain.Common.Results;

namespace MyMechanicShop.Application.Features.Identity.Queries.RefreshToken;


public sealed record RefreshTokenQuery(string RefreshToken,
                                       string ExpiredAccessToken) : IRequest<Result<TokenResponse>>;