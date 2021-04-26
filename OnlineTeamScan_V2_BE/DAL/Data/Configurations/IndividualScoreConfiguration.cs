using AutoMapper;
using Common.DTOs.IndividualScoreDTO;
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
    public class IndividualScoreConfiguration : Profile, IEntityTypeConfiguration<IndividualScore>
    {
        public IndividualScoreConfiguration()
        {
            CreateMap<IndividualScore, IndividualScoreReadDto>();
            CreateMap<IndividualScoreCreateDto, IndividualScore>();
            CreateMap<IndividualScoreUpdateDto, IndividualScore>();
        }

        public void Configure(EntityTypeBuilder<IndividualScore> builder)
        {
            builder.ToTable("tbl_individualscores");
            builder.Property(i => i.Id).HasColumnName("id");
            builder.Property(i => i.TeamMemberId).HasColumnName("teammember_id").IsRequired();
            builder.Property(i => i.TeamscanId).HasColumnName("teamscan_id").IsRequired();
            builder.Property(i => i.ScoreTrust).HasColumnName("score_trust").HasColumnType("decimal(3,2)").HasDefaultValue(0).IsRequired();
            builder.Property(i => i.ScoreConflict).HasColumnName("score_conflict").HasColumnType("decimal(3,2)").HasDefaultValue(0).IsRequired();
            builder.Property(i => i.ScoreCommitment).HasColumnName("score_commitment").HasColumnType("decimal(3,2)").HasDefaultValue(0).IsRequired();
            builder.Property(i => i.ScoreAccountability).HasColumnName("score_accountability").HasColumnType("decimal(3,2)").HasDefaultValue(0).IsRequired();
            builder.Property(i => i.ScoreResults).HasColumnName("score_results").HasColumnType("decimal(3,2)").HasDefaultValue(0).IsRequired();
            builder.Property(t => t.HasAnswered).HasColumnName("has_answered").HasColumnType("bit").HasDefaultValue(false).IsRequired();

            builder.HasKey(i => i.Id).IsClustered();
            builder.HasOne(i => i.TeamMember).WithMany().HasForeignKey(f => f.TeamMemberId).IsRequired();
            builder.HasOne(i => i.Teamscan).WithMany().HasForeignKey(f => f.TeamscanId).OnDelete(DeleteBehavior.Restrict).IsRequired();
            builder.HasIndex(i => new { i.TeamMemberId, i.TeamscanId }).IsUnique();
        }
    }
}
