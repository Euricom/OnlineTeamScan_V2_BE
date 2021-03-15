using BL.Services.IndividualScoreServices;
using BL.Services.TeamscanServices;
using BL.Services.TeamServices;
using DAL;
using Microsoft.Extensions.DependencyInjection;

namespace BL
{
    public static class BLExtension
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddTransient<ITeamService, TeamService>();
            services.AddTransient<ITeamscanService, TeamscanService>();
            services.AddTransient<IIndividualScoreService, IndividualScoreService>();
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
