using MediatR;
using MyMechanicShop.Application.Features.Customers.Dtos;
using MyMechanicShop.Domain.Common.Results;

namespace MyMechanicShop.Application.Features.Customers.Queries.GetCustomerById;

public sealed record GetCustomerByIdQuery (Guid Id) : IRequest<Result<CustomerDto>>;