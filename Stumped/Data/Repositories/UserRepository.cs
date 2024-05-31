﻿using Microsoft.EntityFrameworkCore;
using Stumped.Models;

namespace Stumped.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<User> CreateUserAsync(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<User> GetUserByIdAsync(int userId)
        {
            return await _context.Users.Include(u => u.Account).FirstOrDefaultAsync(u => u.UserId == userId);
        }
    }


}
