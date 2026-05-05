
using Microsoft.Extensions.DependencyInjection;
using Ntp.Application.Interfaces.AutoMapper;

namespace Ntp.Mapper;

public static class Registration
{
    public static void AddCustomMapper(this IServiceCollection services)
    {
        services.AddSingleton<IMapper, AutoMapper.Mapper>();

    }
}