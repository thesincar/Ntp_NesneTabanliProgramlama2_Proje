using MapperConfiguration = global::AutoMapper.MapperConfiguration;
using MapperConfigurationExpression = global::AutoMapper.MapperConfigurationExpression;
using RuntimeMapper = global::AutoMapper.IMapper;

namespace Ntp.Mapper.AutoMapper;

public class Mapper : Application.Interfaces.AutoMapper.IMapper
{
    public record TypePair(Type SourceType, Type DestinationType);
    public static List<TypePair> typePairs = new();

    private RuntimeMapper MapperContainer;
    public TDestination Map<TDestination, TSource>(TSource source, string? ignore = null)
    {
        Config<TDestination, TSource>(5, ignore);
        return MapperContainer.Map<TDestination>(source!);
    }

    public IList<TDestination> Map<TDestination, TSource>(IList<TSource> source, string? ignore = null)
    {
        Config<TDestination, TSource>(5, ignore);
        return MapperContainer.Map<IList<TDestination>>(source);
    }

    public TDestination Map<TDestination, TSource>(object source, string? ignore = null)
    {
        Config<TDestination, object>(5, ignore);
        return MapperContainer.Map<TDestination>(source);
    }

    public IList<TDestination> Map<TDestination, TSource>(IList<object> source, string? ignore = null)
    {
        Config<TDestination, IList<object>>(5, ignore);
        return MapperContainer.Map<IList<TDestination>>(source);
    }

    protected void Config<TDestination, TSource>(int depth = 5, string? ignore = null)
    {
        var typePair = new TypePair(typeof(TSource), typeof(TDestination));
        var exists = typePairs.Any(a => a.DestinationType == typePair.DestinationType && a.SourceType == typePair.SourceType);

        if (!exists)
            typePairs.Add(typePair);

        if (MapperContainer is not null && exists && ignore is null)
            return;

        var cfg = new MapperConfigurationExpression();
        foreach (var item in typePairs)
        {
            if (ignore is not null)
                cfg.CreateMap(item.SourceType, item.DestinationType).MaxDepth(depth).ForMember(ignore, opt => opt.Ignore()).ReverseMap();
            else
                cfg.CreateMap(item.SourceType, item.DestinationType).MaxDepth(depth).ReverseMap();
        }

        var config = new MapperConfiguration(cfg, global::Microsoft.Extensions.Logging.Abstractions.NullLoggerFactory.Instance);
        MapperContainer = config.CreateMapper();
    }
}
