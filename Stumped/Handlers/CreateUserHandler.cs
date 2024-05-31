using MediatR;
using Stumped.Commands;
using Stumped.Data;
using Stumped.Models;

namespace Stumped.Handlers
{
    public class CreateUserHandler : IRequestHandler<CreateUserCommand, User>
    {
        private readonly AppDbContext _context;

        public CreateUserHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<User> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = new User
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                IDNumber = request.IDNumber,
                Password = request.Password,
                Email = request.Email,
                Account = new Account { Balance = 0 }
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync(cancellationToken);
            return user;
        }
    }

}
