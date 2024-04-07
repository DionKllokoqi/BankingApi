using Contracts.DTOs;
using MediatR;

namespace Application.Abstractions.Requests;

public record RegisterRequest(string UserName, string Password) : IRequest<LoginDto>;