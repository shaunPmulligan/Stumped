using Stumped.Models;

namespace Stumped.Data.Repositories
{
    public interface IVehicleRepository
    {
        Task<Vehicle> AddVehicleAsync(Vehicle vehicle);
        Task<List<Vehicle>> GetVehiclesAsync(string vin, string model, string color, int? accountId, int page, int pageSize);
    }
}
