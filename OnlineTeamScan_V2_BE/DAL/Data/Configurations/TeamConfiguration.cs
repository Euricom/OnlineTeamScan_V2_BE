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
            builder.Property(t => t.Id).HasColumnName("id").ValueGeneratedOnAdd();

            builder.Property(t => t.Name).HasColumnName("name").HasColumnType("varchar(50)").IsRequired();
            builder.Property(t => t.LastTeamScan).HasColumnName("last_teamscan").HasColumnType("date");

            builder.HasKey(t => t.Id).IsClustered();
            builder.HasIndex(t => t.Name).IsUnique();
        }
    }
}
