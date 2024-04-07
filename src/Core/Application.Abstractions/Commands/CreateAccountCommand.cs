using MediatR;

namespace Application.Abstractions.Commands;

public record CreateAccountCommand(string UserId, string Name, decimal InitialBalance) : IRequest;