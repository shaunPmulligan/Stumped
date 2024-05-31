using MediatR;
using Stumped.Commands;
using Stumped.Data;
using Stumped.Models;

namespace Stumped.Handlers
{
    public class AddVehicleHandler : IRequestHandler<AddVehicleCommand, Vehicle>
    {
        private readonly AppDbContext _context;

        public AddVehicleHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Vehicle> Handle(AddVehicleCommand request, CancellationToken cancellationToken)
        {
            var vehicle = new Vehicle
            {
                VIN = request.VIN,
                LicenseNumber = request.LicenseNumber,
                PlateNumber = request.PlateNumber,
                LicenseExpiry = request.LicenseExpiry,
                Model = request.Model,
                Color = request.Color,
                AccountId = request.AccountId
            };

            _context.Vehicles.Add(vehicle);
            await _context.SaveChangesAsync(cancellationToken);

            return vehicle;
        }
    }

}
