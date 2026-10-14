using MediatR;
using MyMechanicShop.Domain.Common.Results;

namespace MyMechanicShop.Application.Features.Identity.Queries.GenerateTokens;

public sealed record GenerateTokenQuery (string Email , string Password) : IRequest<Result<TokenResponse>>;
