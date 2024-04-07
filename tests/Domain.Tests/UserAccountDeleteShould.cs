using Domain.Entities;
using FluentAssertions;

namespace Domain.Tests;

public class UserAccountDeleteShould
{
    [Fact]
    public void DeleteAccount_WhenAccountExists_ShouldNotThrowException()
    {
        // Arrange
        var user = new User("test", "test");
        user.AddAccount("test", 100);
        var accountName = "test";

        // Act
        user.DeleteAccount(accountName);

        // Assert
        user.Accounts!.Should().BeEmpty();
    }

    [Fact]
    public void DeleteAccount_WhenAccountDoesNotExist_ShouldThrowArgumentException()
    {
        // Arrange
        var user = new User("test", "test");
        user.AddAccount("test", 100);
        var accountName = "test2";

        // Act
        Action act = () => user.DeleteAccount(accountName);

        // Assert
        act.Should().Throw<ArgumentException>();
    }
}