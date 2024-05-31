using MediatR;
using Microsoft.EntityFrameworkCore;
using Stumped.Commands;
using Stumped.Data;
using Stumped.Models;

namespace Stumped.Handlers
{
    public class GetVehicleListHandler : IRequestHandler<GetVehicleListQuery, List<Vehicle>>
    {
        private readonly AppDbContext _context;

        public GetVehicleListHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Vehicle>> Handle(GetVehicleListQuery request, CancellationToken cancellationToken)
        {
            var query = _context.Vehicles.AsQueryable();

            if (!string.IsNullOrEmpty(request.VIN))
            {
                query = query.Where(v => v.VIN.Contains(request.VIN));
            }

            if (!string.IsNullOrEmpty(request.Model))
            {
                query = query.Where(v => v.Model.Contains(request.Model));
            }

            if (!string.IsNullOrEmpty(request.Color))
            {
                query = query.Where(v => v.Color.Contains(request.Color));
            }

            if (request.AccountId.HasValue)
            {
                query = query.Where(v => v.AccountId == request.AccountId);
            }

            return await query
                .Skip((request.Page - 1) * request.PageSize)
                .Take(request.PageSize)
                .ToListAsync(cancellationToken);
        }
    }

}
