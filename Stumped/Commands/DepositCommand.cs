using MediatR;
using Stumped.Models;

namespace Stumped.Commands
{
    public class DepositCommand : IRequest<Account>
    {
        public int AccountId { get; set; }
        public decimal Amount { get; set; }
    }

}
