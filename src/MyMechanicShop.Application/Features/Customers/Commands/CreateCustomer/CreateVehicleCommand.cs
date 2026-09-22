using MediatR;
using MyMechanicShop.Application.Features.Customers.Dtos;
using MyMechanicShop.Domain.Common.Results;

namespace MyMechanicShop.Application.Features.Customers.Commands.CreateCustomer;

public sealed record CreateVehicleCommand (string Make,
                                           string Model,
                                           int Year,
                                           string LicensePlate) 
                                           :IRequest<Result<VehicleDto>>;
