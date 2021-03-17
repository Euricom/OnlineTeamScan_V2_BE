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
    class RoleTranslationConfiguration : IEntityTypeConfiguration<RoleTranslation>
    {
        public void Configure(EntityTypeBuilder<RoleTranslation> builder)
        {
            builder.ToTable("tbl_role_translations");
            builder.HasKey(item => new { item.RoleId, item.LanguageId });
            builder.Property(item => item.RoleId).HasColumnName("role_id").IsRequired();
            builder.Property(item => item.LanguageId).HasColumnName("language_id").IsRequired();
            builder.Property(item => item.Translation).HasColumnName("translation").HasColumnType("varchar(30)").IsRequired();

            builder.HasOne(item => item.Role).WithMany().IsRequired();
            builder.HasOne(item => item.Language).WithMany().IsRequired();

            builder.HasData(
                // Dutch
                new RoleTranslation { LanguageId = 1, RoleId = 1, Translation = "Teamleider" }
            );
        }
    }
}
