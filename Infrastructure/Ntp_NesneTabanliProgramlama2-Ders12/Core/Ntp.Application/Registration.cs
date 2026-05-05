using Microsoft.Extensions.DependencyInjection;
using Ntp.Application.Exceptions;
using System.Reflection;

namespace Ntp.Application;

public static class Registration
{
    public static void AddApplication(this IServiceCollection services)
    {
        var assembly = Assembly.GetExecutingAssembly();

        services.AddTransient<ExceptionMiddleware>();
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(assembly));

    }
}