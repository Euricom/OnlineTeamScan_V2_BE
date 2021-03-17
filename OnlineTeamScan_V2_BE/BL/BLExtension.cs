﻿using BL.Services.DysfunctionTranslationServices;
using BL.Services.IndividualScoreServices;
using BL.Services.LevelServices;
using BL.Services.TeamscanServices;
using BL.Services.TeamServices;
using BL.Services.UserServices;
using DAL;
using Microsoft.Extensions.DependencyInjection;

namespace BL
{
    public static class BLExtension
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddTransient<ITeamService, TeamService>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<ITeamscanService, TeamscanService>();
            services.AddTransient<IIndividualScoreService, IndividualScoreService>();
            services.AddTransient<ILevelService, LevelService>();
            services.AddTransient<IDysfunctionTranslationService, DysfunctionTranslationService>();
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
