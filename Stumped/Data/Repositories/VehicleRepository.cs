using Microsoft.EntityFrameworkCore;
using Stumped.Models;

namespace Stumped.Data.Repositories
{
    public class VehicleRepository : IVehicleRepository
    {
        private readonly AppDbContext _context;

        public VehicleRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Vehicle> AddVehicleAsync(Vehicle vehicle)
        {
            _context.Vehicles.Add(vehicle);
            await _context.SaveChangesAsync();
            return vehicle;
        }

        public async Task<List<Vehicle>> GetVehiclesAsync(string vin, string model, string color, int? accountId, int page, int pageSize)
        {
            var query = _context.Vehicles.AsQueryable();

            if (!string.IsNullOrEmpty(vin))
            {
                query = query.Where(v => v.VIN.Contains(vin));
            }

            if (!string.IsNullOrEmpty(model))
            {
                query = query.Where(v => v.Model.Contains(model));
            }

            if (!string.IsNullOrEmpty(color))
            {
                query = query.Where(v => v.Color.Contains(color));
            }

            if (accountId.HasValue)
            {
                query = query.Where(v => v.AccountId == accountId);
            }

            return await query.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();
        }
    }

}
