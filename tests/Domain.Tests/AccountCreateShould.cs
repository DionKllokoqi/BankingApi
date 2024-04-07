using Domain.Entities;
using FluentAssertions;

namespace Domain.Tests
{
    public class AccountCreateShould
    {
        [Fact]
        public void Create_WhenInitialBalanceIsLessThan100_ShouldThrowArgumentException()
        {
            // Arrange & Act
            Action act = () => Account.Create(Guid.NewGuid(), 99);

            // Assert
            act.Should().Throw<ArgumentException>();
        }

        [Theory]
        [InlineData(100)]
        [InlineData(101)]
        public void Create_WhenInitialBalanceIsGreaterThanOrEqualTo100_ShouldCreateAccount(decimal initialBalance)
        {
            // Arrange
            var userId = Guid.NewGuid();

            // Act
            var account = Account.Create(userId, initialBalance);

            // Assert
            account.UserId.Should().Be(userId);
            account.Balance.Should().Be(initialBalance);
        }
    }
}