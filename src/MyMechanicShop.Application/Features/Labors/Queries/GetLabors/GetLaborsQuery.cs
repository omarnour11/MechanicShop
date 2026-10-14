using MyMechanicShop.Application.Features.Labors.Dtos;
using MyMechanicShop.Domain.Common.Results;
using MediatR;

namespace MyMechanicShop.Application.Features.Labors.Queries.GetLabors;

public sealed record GetLaborsQuery : IRequest<Result<List<LaborDto>>>;