using MyMechanicShop.Application.Features.Labors.Dtos;
using MyMechanicShop.Application.Features.Labors.Mappers;
using MyMechanicShop.Application.Interfaces;
using MyMechanicShop.Domain.Common.Results;
using MyMechanicShop.Domain.Identity;

using MediatR;

using Microsoft.EntityFrameworkCore;

namespace MyMechanicShop.Application.Features.Labors.Queries.GetLabors;

public class GetLaborsQueryHandler(IAppDbContext context)
    : IRequestHandler<GetLaborsQuery, Result<List<LaborDto>>>
{
    private readonly IAppDbContext _context = context;

    public async Task<Result<List<LaborDto>>> Handle(GetLaborsQuery query, CancellationToken ct)
    {
        var labors = await _context.Employees.AsNoTracking().Where(e => e.Role == Role.Labor).ToListAsync(ct);

        return labors.ToDtos();
    }
}