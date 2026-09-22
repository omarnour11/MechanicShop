using MediatR;
using MyMechanicShop.Application.Features.Customers.Dtos;
using MyMechanicShop.Domain.Common.Results;

namespace MyMechanicShop.Application.Features.Customers.Commands.CreateCustomer;

public sealed record CreateCustomerCommand (string Name,
                                            string PhoneNumber,
                                            string Email,
                                            List<CreateVehicleCommand> Vehicles) 
                                            : IRequest<Result<CustomerDto>>;
