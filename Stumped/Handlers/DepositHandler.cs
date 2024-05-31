using MediatR;
using Stumped.Commands;
using Stumped.Data;
using Stumped.Models;

namespace Stumped.Handlers
{
    public class DepositHandler : IRequestHandler<DepositCommand, Account>
    {
        private readonly AppDbContext _context;

        public DepositHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Account> Handle(DepositCommand request, CancellationToken cancellationToken)
        {
            var account = await _context.Accounts.FindAsync(request.AccountId);
            if (account == null)
            {
                throw new Exception("Account not found");
            }

            account.Balance += request.Amount;
            _context.Accounts.Update(account);
            await _context.SaveChangesAsync(cancellationToken);

            return account;
        }
    }

}
