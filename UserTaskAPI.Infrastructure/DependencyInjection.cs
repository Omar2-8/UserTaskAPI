using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using UserTask.Application.Interfaces;
using UserTask.Infrastructure.Extensions;
using UserTask.Infrastructure.Repositories;

namespace UserTask.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddJwtAuthentication(configuration);
      
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<ITaskRepository, TaskRepository>();
        services.AddScoped<IUnitOfWork, UnitOfWork.UnitOfWork>();
        return services;
    }
}