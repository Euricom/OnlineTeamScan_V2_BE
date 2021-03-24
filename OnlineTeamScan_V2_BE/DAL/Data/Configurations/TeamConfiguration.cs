using AutoMapper;
using Common.DTOs.TeamDTO;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Data.Configurations
{
    public class TeamConfiguration : Profile, IEntityTypeConfiguration<Team>
    {
        public TeamConfiguration()
        {
            CreateMap<Team, TeamReadDto>();
            CreateMap<TeamCreateDto, Team>();
            CreateMap<TeamUpdateDto, Team>();
        }

        public void Configure(EntityTypeBuilder<Team> builder)
        {
            builder.ToTable("tbl_teams");
            builder.Property(t => t.Id).HasColumnName("id").ValueGeneratedOnAdd();
            builder.Property(t => t.TeamleaderId).HasColumnName("teamleader_id").IsRequired();
            builder.Property(t => t.Name).HasColumnName("name").HasColumnType("varchar(50)").IsRequired();
            builder.Property(t => t.LastTeamScan).HasColumnName("last_teamscan").HasColumnType("date");
            builder.Property(t => t.IsTeamscanActive).HasColumnName("is_teamscan_active").HasColumnType("bit").HasDefaultValue(false).IsRequired();

            builder.HasKey(t => t.Id).IsClustered();
            builder.HasOne(t => t.Teamleader).WithMany().HasForeignKey(f => f.TeamleaderId).IsRequired();
            builder.HasIndex(t => t.Name).IsUnique();
        }
    }
}
