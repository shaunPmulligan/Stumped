using MediatR;
using Stumped.Models;

namespace Stumped.Commands
{
    public class GetVehicleListQuery : IRequest<List<Vehicle>>
    {
        public string VIN { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public int? AccountId { get; set; }
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }

}
