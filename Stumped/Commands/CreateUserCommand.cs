using MediatR;
using Stumped.Models;

namespace Stumped.Commands
{
    public class CreateUserCommand : IRequest<User>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string IDNumber { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
    }
}
