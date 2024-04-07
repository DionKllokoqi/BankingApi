using Application.Abstractions.Requests;
using Application.Services;
using Contracts.DTOs;
using Domain.Repositories;
using MediatR;

namespace Application.QueryHandlers;

public class RegisterUserQueryHandler(IUserRepository userRepository, ITokenService tokenService) : IRequestHandler<RegisterRequest, LoginDto>
{
    public async Task<LoginDto> Handle(RegisterRequest request, CancellationToken cancellationToken)
    {
        var user = await userRepository.Create(request.UserName, request.Password);

        var token = tokenService.GenerateToken(user);

        await userRepository.SaveChangesAsync();

        return new LoginDto(user.Id.ToString(), token);
    }
}