using BL.Mail;
using BL.Services.DysfunctionTranslationServices;
using BL.Services.IndividualScoreServices;
using BL.Services.InterpretationTranslationServices;
using BL.Services.LevelServices;
using BL.Services.QuestionTranslationServices;
using BL.Services.RecommendationTranslationServices;
using BL.Services.TeamMemberServices;
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
            services.AddTransient<IInterpretationTranslationService, InterpretationTranslationService>();
            services.AddTransient<ITeamMemberService, TeamMemberService>();
            services.AddTransient<IQuestionTranslationService, QuestionTranslationService>();
            services.AddTransient<IRecommendationTranslationService, RecommendationTranslationService>();
            services.AddTransient<Mailer>();
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
