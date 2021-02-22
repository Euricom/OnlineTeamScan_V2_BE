using DAL;
using Microsoft.Extensions.DependencyInjection;

namespace BL
{
    public static class BLExtension
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {         
            return services;
        }

        public static IServiceCollection SetupRepositories(this IServiceCollection services)
        {
            services.AddRepositories();
            return services;
        }

        public static IServiceCollection RegisterContext(this IServiceCollection services, string connectionString)
        {
            services.AddOnlineTeamScanContext(connectionString);
            return services;
        }
    }
}
