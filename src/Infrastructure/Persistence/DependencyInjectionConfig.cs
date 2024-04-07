using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Repositories;

namespace Persistence;

public static class DependencyInjectionConfig
{
    public static IServiceCollection AddPersistence(this IServiceCollection services)
    {
        _ = services.AddDbContext<UserDbContext>(options =>
        {
            options.UseInMemoryDatabase("UserDb");
        });

        services.AddScoped<IUserRepository, UserRepository>();

        return services;
    }
}