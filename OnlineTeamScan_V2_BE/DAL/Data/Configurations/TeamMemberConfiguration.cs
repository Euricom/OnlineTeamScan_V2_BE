using AutoMapper;
using Common.DTOs.TeamMemberDTO;
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
    public class TeamMemberConfiguration : Profile, IEntityTypeConfiguration<TeamMember>
    {
        public TeamMemberConfiguration()
        {
            CreateMap<TeamMember, TeamMemberReadDto>();
            CreateMap<TeamMemberCreateDto, TeamMember>();
            CreateMap<TeamMemberUpdateDto, TeamMember>();
        }

        public void Configure(EntityTypeBuilder<TeamMember> builder)
        {
            builder.ToTable("tbl_teammembers");
            builder.Property(t => t.Id).HasColumnName("id").ValueGeneratedOnAdd();
            builder.Property(t => t.TeamId).HasColumnName("team_id").IsRequired();
            builder.Property(t => t.Email).HasColumnName("email").HasColumnType("varchar(100)").IsRequired();
            builder.Property(t => t.Firstname).HasColumnName("firstname").HasColumnType("varchar(70)").IsRequired();
            builder.Property(t => t.Lastname).HasColumnName("lastname").HasColumnType("varchar(70)").IsRequired();
            builder.Property(t => t.IsActive).HasColumnName("is_active").HasColumnType("bit").HasDefaultValue(true).IsRequired();

            builder.HasKey(t => t.Id).IsClustered();  
            builder.HasOne(t => t.Team).WithMany(c => c.TeamMembers).HasForeignKey(f => f.TeamId).IsRequired();
            builder.HasIndex(t => new { t.TeamId, t.Email }).IsUnique();
        }
    }
}
