using MediatR;

namespace Stumped.Commands
{
    public class RenewLicenseCommand : IRequest<bool>
    {
        public int AccountId { get; set; }
        public int VehicleId { get; set; }
        public int QuoteId { get; set; }
    }

}
