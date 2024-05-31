using Microsoft.EntityFrameworkCore;
using Stumped.Models;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace Stumped.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Quote> Quotes { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>()
                .HasOne(u => u.Account)
                .WithOne(a => a.User)
                .HasForeignKey<Account>(a => a.UserId);

            modelBuilder.Entity<Account>()
                .HasMany(a => a.Transactions)
                .WithOne(t => t.Account)
                .HasForeignKey(t => t.AccountId);

            modelBuilder.Entity<Account>()
                .HasMany(a => a.Quotes)
                .WithOne(q => q.Account)
                .HasForeignKey(q => q.AccountId);

            modelBuilder.Entity<Account>()
                .HasMany(a => a.Vehicles)
                .WithOne(v => v.Account)
                .HasForeignKey(v => v.AccountId);
        }
    }

}
