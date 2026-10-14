using MediatR;
using MyMechanicShop.Domain.Common.Results;
namespace MyMechanicShop.Application.Features.Customers.Commands.UpdateCustomer;
public sealed record UpdateVehicleCommand(
 Guid? VehicleId,
 string Make,
 string Model,
 int Year,
 string LicensePlate) : IRequest<Result<Updated>>;