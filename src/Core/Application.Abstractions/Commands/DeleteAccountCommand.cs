using MediatR;

namespace Application.Abstractions.Commands;

public record DeleteAccountCommand(string Name, string UserId) : IRequest;