using Domain.Entities;
using FluentAssertions;

namespace Domain.Tests;

public class UserAddAccountShould
{
    [Fact]
    public void AddAccount_WhenAccountDoesNotExistYet_ShouldAdd()
    {
        // Arrange
        var user = new User("test", "test");

        // Act
        user.AddAccount("test", 100);

        // Assert
        user.Accounts.Should().HaveCount(1);
    }

    [Fact]
    public void AddAccount_WhenAccountAlreadyExists_ShouldThrow()
    {
        // Arrange
        var user = new User("test", "test");
        user.AddAccount("test", 100);

        // Act
        Action act = () => user.AddAccount("test", 100);

        // Assert
        act.Should().Throw<ArgumentException>();
    }
}