using AutoMapper;
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
    public class TeamscanMemberConfiguration : Profile, IEntityTypeConfiguration<TeamscanMember>
    {
        public TeamscanMemberConfiguration()
        {

        }

        public void Configure(EntityTypeBuilder<TeamscanMember> builder)
        {
            builder.ToTable("tbl_teamscan_members");
            builder.Property(t => t.TeamMemberId).HasColumnName("teammember_id").IsRequired();
            builder.Property(t => t.TeamscanId).HasColumnName("teamscan_id").IsRequired();
            builder.Property(t => t.HasAnswered).HasColumnName("has_answered").HasColumnType("bit").HasDefaultValue(false).IsRequired();

            builder.HasKey(t => new { t.TeamMemberId, t.TeamscanId });
            builder.HasOne(t => t.TeamMember).WithMany().HasForeignKey(f => f.TeamMemberId).IsRequired();
            builder.HasOne(t => t.Teamscan).WithMany().HasForeignKey(f => f.TeamscanId).IsRequired();
        }
    }
}
