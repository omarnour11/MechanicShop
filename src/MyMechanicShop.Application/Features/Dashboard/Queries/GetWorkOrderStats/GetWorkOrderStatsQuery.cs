using MyMechanicShop.Application.Features.Dashboard.Dtos;
using MyMechanicShop.Domain.Common.Results;

using MediatR;

namespace MyMechanicShop.Application.Features.Dashboard.Queries.GetWorkOrderStats;

public sealed record GetWorkOrderStatsQuery(DateOnly Date) : IRequest<Result<TodayWorkOrderStatsDto>>;