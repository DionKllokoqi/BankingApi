using Application.Abstractions.Requests;
using Contracts.DTOs;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.APIs;

public static class UserEndpoints
{
    internal static void ConfigureUserApi(this WebApplication app)
    {
        app.MapPost("/api/register", RegisterUserAsync);
    }

    public static async Task<Ok<LoginDto>> RegisterUserAsync([FromBody] RegisterRequest request, [FromServices] IMediator mediator)
    {
        var result = await mediator.Send(request);
        return TypedResults.Ok(result);
    }
}