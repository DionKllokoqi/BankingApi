using Application.Abstractions.Commands;
using Domain.Exceptions;
using Domain.Repositories;
using MediatR;

namespace Application.CommandHandlers;

public class DeleteAccountCommandHandler(IUserRepository userRepository) : IRequestHandler<DeleteAccountCommand>
{
    public async Task Handle(DeleteAccountCommand request, CancellationToken cancellationToken)
    {
        var user = await userRepository.GetById(Guid.Parse(request.UserId)) ?? throw new UserNotFoundException(request.UserId);

        user.DeleteAccount(request.Name);
        await userRepository.DeleteAccount(user.Id, request.Name);
        await userRepository.SaveChangesAsync();

        return;
    }
}