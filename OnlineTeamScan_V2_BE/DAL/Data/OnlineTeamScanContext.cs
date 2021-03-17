using DAL.Data.Configurations;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Data
{
    public class OnlineTeamScanContext : DbContext
    {
        public OnlineTeamScanContext(DbContextOptions<OnlineTeamScanContext> opt) : base(opt)
        { }

        public DbSet<Team> Teams { get; set; }
        public DbSet<TeamMember> TeamMembers { get; set; }
        public DbSet<Teamscan> Teamscans { get; set; }
        public DbSet<TeamscanMember> TeamscanMembers { get; set; }
        public DbSet<IndividualScore> IndividualScores { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<RoleTranslation> RoleTranslations { get; set; }
        public DbSet<Dysfunction> Dysfunctions { get; set; }
        public DbSet<DysfunctionTranslation> DysfunctionTranslations { get; set; }
        public DbSet<Interpretation> Interpretations { get; set; }
        public DbSet<InterpretationTranslation> InterpretationTranslations { get; set; }
        public DbSet<Level> Levels { get; set; }
        public DbSet<LevelTranslation> LevelTranslations { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<QuestionTranslation> QuestionTranslations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new TeamConfiguration());
            modelBuilder.ApplyConfiguration(new TeamMemberConfiguration());
            modelBuilder.ApplyConfiguration(new TeamscanConfiguration());
            modelBuilder.ApplyConfiguration(new TeamscanMemberConfiguration());
            modelBuilder.ApplyConfiguration(new IndividualScoreConfiguration());
            modelBuilder.ApplyConfiguration(new LanguageConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            modelBuilder.ApplyConfiguration(new UserRoleConfiguration());
            modelBuilder.ApplyConfiguration(new RoleTranslationConfiguration());
            modelBuilder.ApplyConfiguration(new DysfunctionConfiguration());
            modelBuilder.ApplyConfiguration(new DysfunctionTranslationConfiguration());
            modelBuilder.ApplyConfiguration(new InterpretationConfiguration());
            modelBuilder.ApplyConfiguration(new InterpretationTranslationConfiguration());
            modelBuilder.ApplyConfiguration(new LevelConfiguration());
            modelBuilder.ApplyConfiguration(new LevelTranslationConfiguration());
            modelBuilder.ApplyConfiguration(new QuestionConfiguration());
            modelBuilder.ApplyConfiguration(new QuestionTranslationConfiguration());
        }
    }
}
