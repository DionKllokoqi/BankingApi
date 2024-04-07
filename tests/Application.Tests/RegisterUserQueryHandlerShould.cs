using Application.Abstractions.Requests;
using Application.QueryHandlers;
using Application.Services;
using Contracts.DTOs;
using Domain.Entities;
using Domain.Repositories;
using FluentAssertions;
using Moq;

namespace Application.Tests
{
    public class RegisterUserQueryHandlerShould
    {
        [Fact]
        public async Task Handle_WhenUserDoesNotExist_ShouldCreateUserAsync()
        {
            // Arrange
            var userRepository = new Mock<IUserRepository>();

            var tokenService = new Mock<ITokenService>();

            var handler = new RegisterUserQueryHandler(userRepository.Object, tokenService.Object);

            var request = new RegisterRequest("username", "password");

            userRepository.Setup(x => x.Create(It.IsAny<string>(), It.IsAny<string>())).ReturnsAsync(new User("username", "password"));

            tokenService.Setup(x => x.GenerateToken(It.IsAny<User>())).Returns("token");

            // Act
            var result = await handler.Handle(request, CancellationToken.None);

            // Assert
            result.Should().BeEquivalentTo(new LoginDto(result.Id, "token"));
        }
    }
}