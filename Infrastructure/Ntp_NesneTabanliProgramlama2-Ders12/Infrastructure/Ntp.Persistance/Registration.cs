using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Ntp.Application.Interfaces.Repositories;
using Ntp.Application.UnitOfWorks;
using Ntp.Persistance.Context;
using Ntp.Persistance.Repositories;
using Ntp.Persistance.UnitOfWorks;

namespace Ntp.Persistance;

public static class Registration
{
    public static void AddPersistance(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

        services.AddScoped(typeof(IReadRepository<>), typeof(ReadRepository<>));
        services.AddScoped(typeof(IWriteRepository<>), typeof(WriteRepository<>));
        services.AddScoped<IUnitOfWork, UnitOfWork>();

    }
}