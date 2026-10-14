using MediatR;
using MyMechanicShop.Domain.Common.Results;
using MyMechanicShop.Domain.Customers.Vehicles;

namespace MyMechanicShop.Application.Features.Customers.Commands.UpdateCustomer;

public sealed record UpdateCustomerCommand (Guid CustomerId,
                                            string Name,
                                            string PhoneNumber,
                                            string Email,
                                            List<UpdateVehicleCommand> Vehicles)
:IRequest<Result<Updated>>;