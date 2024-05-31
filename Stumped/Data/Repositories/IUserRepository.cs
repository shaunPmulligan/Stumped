using Stumped.Models;

namespace Stumped.Data.Repositories
{
    public interface IUserRepository
    {
        Task<User> CreateUserAsync(User user);
        Task<User> GetUserByIdAsync(int userId);
    }

}
