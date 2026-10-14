using MediatR;
using MyMechanicShop.Domain.Common.Results;

namespace MyMechanicShop.Application.Features.Customers.Commands.RemoveCustomer;
public sealed record RemoveCustomerCommand (Guid CustomerId) : IRequest<Result<Deleted>>;