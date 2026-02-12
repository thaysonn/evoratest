using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Padaria.Application.Extensions;

public static class ServicesCollection
{
    public static IServiceCollection AddApplication(this IServiceCollection services) 
    { 
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        return services;
    }
}
