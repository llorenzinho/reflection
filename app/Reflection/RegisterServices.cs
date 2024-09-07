using Hangfire;
using Hangfire.MemoryStorage;
using Hangfire.PostgreSql;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Reflection.PersonServices;

namespace Reflection;

public static class RegisterServices
{
    public static void Register(IServiceCollection services)
    {
        services.AddTransient<IPersonService, PersonService>();
        
        services.AddHangfire((sp, options) =>
        {
            options
                .SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
                .UseSimpleAssemblyNameTypeSerializer()
                .UseRecommendedSerializerSettings()
                .UsePostgreSqlStorage(
                    options => options.UseNpgsqlConnection(
                        sp.GetRequiredService<IConfiguration>().GetConnectionString("defaultConnection"))
                );
        });
        services.AddHangfireServer(
            options =>
            {
                options.ServerName = "Reflection";
                options.WorkerCount = 1;
            }
        );

        PersonService.Reflect();
    }
}