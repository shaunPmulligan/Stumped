using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Stumped;
using Stumped.Data;
using Stumped.Handlers;
using Microsoft.EntityFrameworkCore;
using Stumped.Commands;

namespace StumpedTests.Tests
{
    public class CreateUserHandlerTests
    {
        private readonly Mock<AppDbContext> _mockContext;
        private readonly CreateUserHandler _handler;

        public CreateUserHandlerTests()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            _mockContext = new Mock<AppDbContext>(options);
            _handler = new CreateUserHandler(_mockContext.Object);
        }

        [Fact]
        public async Task Handle_ValidRequest_ReturnsUser()
        {
            var command = new CreateUserCommand
            {
                FirstName = "John",
                LastName = "Doe",
                IDNumber = "12345",
                Password = "password",
                Email = "john.doe@example.com"
            };

            var result = await _handler.Handle(command, CancellationToken.None);

            Assert.NotNull(result);
            Assert.Equal("John", result.FirstName);
        }
    }

}
