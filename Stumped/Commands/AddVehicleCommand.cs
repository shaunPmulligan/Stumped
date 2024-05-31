using MediatR;
using Stumped.Models;

namespace Stumped.Commands
{
    public class AddVehicleCommand : IRequest<Vehicle>
    {
        public string VIN { get; set; }
        public string LicenseNumber { get; set; }
        public string PlateNumber { get; set; }
        public DateTime LicenseExpiry { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public int AccountId { get; set; }
    }

}
