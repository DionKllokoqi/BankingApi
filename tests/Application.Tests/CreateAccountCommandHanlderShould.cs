using Application.Abstractions.Commands;
using Application.CommandHandlers;
using Domain.Entities;
using Domain.Exceptions;
using Domain.Repositories;
using FluentAssertions;
using Moq;

namespace Application.Tests;

public class CreateAccountCommandHanlderShould
{
    [Fact]
    public async Task Handle_WhenUserExists_ShouldCreateAccountAndNotThrowExceptionAsync()
    {
        // Arrange
        var userRepository = new Mock<IUserRepository>();

        var handler = new CreateAccountCommandHandler(userRepository.Object);

        var request = new CreateAccountCommand(Guid.NewGuid().ToString(), "name", 100);

        userRepository.Setup(x => x.GetById(It.IsAny<Guid>())).ReturnsAsync(new User("userId", "password"));

        // Act
        Func<Task> act = async () => await handler.Handle(request, CancellationToken.None);

        // Assert
        await act.Should().NotThrowAsync();
    }

    [Fact]
    public async Task Handle_WhenUserDoesNotExist_ShouldThrowUserNotFoundExceptionAsync()
    {
        // Arrange
        var userRepository = new Mock<IUserRepository>();

        var handler = new CreateAccountCommandHandler(userRepository.Object);

        var request = new CreateAccountCommand(Guid.NewGuid().ToString(), "name", 100);

        userRepository.Setup(x => x.GetById(It.IsAny<Guid>())).ReturnsAsync((User?)null);

        // Act
        Func<Task> act = async () => await handler.Handle(request, CancellationToken.None);

        // Assert
        await act.Should().ThrowAsync<UserNotFoundException>();
    }
}