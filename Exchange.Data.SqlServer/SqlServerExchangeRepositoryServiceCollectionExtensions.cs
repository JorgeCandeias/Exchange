using Microsoft.Extensions.DependencyInjection;

namespace Exchange.Data.SqlServer;

public static class SqlServerExchangeRepositoryServiceCollectionExtensions
{
    public static IServiceCollection AddSqlServerExchangeRepository(this IServiceCollection services, Action<SqlServerExchangeRepositoryOptions> configure)
    {
        return services
            .AddSingleton<IExchangeRepository, SqlServerExchangeRepository>()
            .AddOptions<SqlServerExchangeRepositoryOptions>()
            .Configure(configure)
            .ValidateDataAnnotations()
            .Services;
    }
}