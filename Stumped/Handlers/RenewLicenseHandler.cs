using MediatR;
using Stumped.Commands;
using Stumped.Data;

namespace Stumped.Handlers
{
    public class RenewLicenseHandler : IRequestHandler<RenewLicenseCommand, bool>
    {
        private readonly AppDbContext _context;

        public RenewLicenseHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(RenewLicenseCommand request, CancellationToken cancellationToken)
        {
            var account = await _context.Accounts.FindAsync(request.AccountId);
            if (account == null)
            {
                throw new Exception("Account not found");
            }

            var vehicle = await _context.Vehicles.FindAsync(request.VehicleId);
            if (vehicle == null)
            {
                throw new Exception("Vehicle not found");
            }

            var quote = await _context.Quotes.FindAsync(request.QuoteId);
            if (quote == null || quote.Status != "Pending")
            {
                throw new Exception("Quote not found or already processed");
            }

            if (account.Balance < quote.Amount)
            {
                throw new Exception("Insufficient funds");
            }

            account.Balance -= quote.Amount;
            vehicle.LicenseExpiry = vehicle.LicenseExpiry.AddYears(1);
            quote.Status = "Paid";

            _context.Accounts.Update(account);
            _context.Vehicles.Update(vehicle);
            _context.Quotes.Update(quote);

            await _context.SaveChangesAsync(cancellationToken);

            return true;
        }
    }

}
