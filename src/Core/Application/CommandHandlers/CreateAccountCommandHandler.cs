using Application.Abstractions.Commands;
using Domain.Exceptions;
using Domain.Repositories;
using MediatR;

namespace Application.CommandHandlers;

public class CreateAccountCommandHandler(IUserRepository userRepository) : IRequestHandler<CreateAccountCommand>
{
    public async Task Handle(CreateAccountCommand request, CancellationToken cancellationToken = default)
    {
        var user = await userRepository.GetById(Guid.Parse(request.UserId)) ?? throw new UserNotFoundException(request.UserId);

        user.AddAccount(request.Name, request.InitialBalance);
        await userRepository.AddAccount(user.Id, user.Accounts!.Last());
        await userRepository.SaveChangesAsync();

        return;
    }
}