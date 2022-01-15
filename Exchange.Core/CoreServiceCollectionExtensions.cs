using Microsoft.Extensions.DependencyInjection;

namespace Exchange.Core;

public static class CoreServiceCollectionExtensions
{
    public static IServiceCollection AddExchangeCore(this IServiceCollection services)
    {
        return services
            .AddSingleton<ISystemClock, SystemClock>();
    }
}