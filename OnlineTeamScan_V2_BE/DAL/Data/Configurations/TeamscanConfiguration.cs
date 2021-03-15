using AutoMapper;
using Common.DTOs.TeamscanDTO;
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
    public class TeamscanConfiguration : Profile, IEntityTypeConfiguration<Teamscan>
    {
        public TeamscanConfiguration()
        {
            CreateMap<Teamscan, TeamscanReadDto>();
            CreateMap<TeamscanUpdateDto, Teamscan>();
        }
        public void Configure(EntityTypeBuilder<Teamscan> builder)
        {
            builder.ToTable("tbl_teamscans");
            builder.Property(t => t.Id).HasColumnName("id").ValueGeneratedOnAdd();
            builder.Property(t => t.StartedById).HasColumnName("startedby_id").IsRequired();
            builder.Property(t => t.TeamId).HasColumnName("team_id").IsRequired();
            builder.Property(t => t.Title).HasColumnName("title").HasColumnType("varchar(50)").IsRequired();
            builder.Property(t => t.StartDate).HasColumnName("start_date").HasColumnType("date").IsRequired();
            builder.Property(t => t.EndDate).HasColumnName("end_date").HasColumnType("date");
            builder.Property(t => t.ScoreTrust).HasColumnName("score_trust").HasColumnType("decimal(3,2)").HasDefaultValue(0).IsRequired();
            builder.Property(t => t.ScoreConflict).HasColumnName("score_conflict").HasColumnType("decimal(3,2)").HasDefaultValue(0).IsRequired();
            builder.Property(t => t.ScoreCommitment).HasColumnName("score_commitment").HasColumnType("decimal(3,2)").HasDefaultValue(0).IsRequired();
            builder.Property(t => t.ScoreAccountability).HasColumnName("score_accountability").HasColumnType("decimal(3,2)").HasDefaultValue(0).IsRequired();
            builder.Property(t => t.ScoreResults).HasColumnName("score_results").HasColumnType("decimal(3,2)").HasDefaultValue(0).IsRequired();

            builder.HasKey(t => t.Id).IsClustered();
            builder.HasOne(t => t.Team).WithMany().HasForeignKey(f => f.TeamId).IsRequired();
            builder.HasOne(t => t.StartedBy).WithMany().HasForeignKey(f => f.StartedById).OnDelete(DeleteBehavior.Restrict).IsRequired();
            builder.HasIndex(t => new { t.TeamId, t.Title }).IsUnique();
        }
    }
}
