using MechanicShop.Application.Features.Customers.Mappers;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MyMechanicShop.Application.Features.Customers.Dtos;
using MyMechanicShop.Application.Interfaces;
using MyMechanicShop.Domain.Common.Results;
using MyMechanicShop.Domain.Customers;

namespace MyMechanicShop.Application.Features.Customers.Queries.GetCustomerById;


public class GetCustomerByIdQueryHandler (IAppDbContext context,
                                          ILogger<GetCustomerByIdQueryHandler> logger) 
: IRequestHandler<GetCustomerByIdQuery, Result<CustomerDto>>
{
    private readonly IAppDbContext _context = context;
    private readonly ILogger<GetCustomerByIdQueryHandler> _logger = logger;

    public async Task<Result<CustomerDto>> Handle(GetCustomerByIdQuery query, CancellationToken ct)
    {
        var customer = await _context.Customers.AsNoTracking().Include(c=>c.Vehicles).FirstOrDefaultAsync(c => c.Id == query.Id, ct);

        if(customer is null)
        {
            _logger.LogWarning("Customer with id {Id} was not found", query.Id);
                    return Error.NotFound(
                code: "Customer_NotFound",
                description: $"Customer with id '{query.Id}' was not found");

        }
    
         return customer.ToDto();

    }
}