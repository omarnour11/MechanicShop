using MediatR;
using MyMechanicShop.Application.Features.Customers.Dtos;
using MyMechanicShop.Domain.Common.Results;

namespace MyMechanicShop.Application.Features.Customers.Queries.GetCustomers;


public sealed record GetCustomersQuery : IRequest<Result<List<CustomerDto>>>;