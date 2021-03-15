using DAL.Data;
using DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DAL
{
    public static class DALExtension
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            return services;
        }

        public static IServiceCollection AddOnlineTeamScanContext(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<OnlineTeamScanContext>(options => options.UseSqlServer(connectionString));
            return services;
        }
    }
}
