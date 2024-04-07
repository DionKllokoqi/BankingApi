using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Hosting;
using Presentation.APIs;

namespace Presentation;

public static class ApiConfig
{
    public static void AddRestApi(this WebApplication app)
    {
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Radancy Banking API V1");
            });
        }

        app.UseAuthentication();
        app.UseAuthorization();

        app.MapGet("/", () => "The service is running.");

        app.ConfigureUserApi();
    }
}