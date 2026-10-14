using MechanicShop.Application.Features.Customers.Mappers;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MyMechanicShop.Application.Features.Customers.Dtos;
using MyMechanicShop.Application.Interfaces;
using MyMechanicShop.Domain.Common.Results;

namespace MyMechanicShop.Application.Features.Customers.Queries.GetCustomers;

public class GetCustomersQueryHandler(IAppDbContext context )
 : IRequestHandler<GetCustomersQuery, Result<List<CustomerDto>>>
{
    private readonly IAppDbContext _context = context;

    public async Task<Result<List<CustomerDto>>> Handle(GetCustomersQuery query, CancellationToken ct)
    {
       var customersResult = await _context.Customers.Include(c => c.Vehicles).AsNoTracking().ToListAsync(ct);
   
       return customersResult.ToDtos();
    }
}