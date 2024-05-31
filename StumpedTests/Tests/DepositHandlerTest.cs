using Microsoft.EntityFrameworkCore;
using Moq;
using Stumped.Commands;
using Stumped.Data;
using Stumped.Handlers;
using Stumped.Models;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

public class DepositHandlerTests
{
    private readonly DbContextOptions<AppDbContext> _options;
    private readonly AppDbContext _context;
    private readonly DepositHandler _handler;

    public DepositHandlerTests()
    {
        _options = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase(databaseName: "TestDatabase")
            .Options;
        _context = new AppDbContext(_options);
        _handler = new DepositHandler(_context);
    }

    [Fact]
    public async Task Handle_ValidRequest_IncreasesBalance()
    {
        var account = new Account { Balance = 100m };
        _context.Accounts.Add(account);
        await _context.SaveChangesAsync();

        var command = new DepositCommand
        {
            AccountId = account.AccountId,
            Amount = 50m
        };

        var result = await _handler.Handle(command, CancellationToken.None);

        Assert.NotNull(result);
        Assert.Equal(150m, result.Balance);
    }
}
