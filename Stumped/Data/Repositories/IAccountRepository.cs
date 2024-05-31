using Stumped.Models;

namespace Stumped.Data.Repositories
{
    public interface IAccountRepository
    {
        Task<Account> GetAccountByIdAsync(int accountId);
        Task<Account> UpdateAccountAsync(Account account);
    }

}
