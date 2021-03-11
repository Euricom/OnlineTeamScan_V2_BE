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
    public class LevelTranslationConfiguration : Profile, IEntityTypeConfiguration<LevelTranslation>
    {
        public LevelTranslationConfiguration()
        {

        }

        public void Configure(EntityTypeBuilder<LevelTranslation> builder)
        {
            builder.ToTable("tbl_level_translations");
            builder.Property(l => l.LevelId).HasColumnName("level_id").IsRequired();
            builder.Property(l => l.LanguageId).HasColumnName("language_id").IsRequired();
            builder.Property(l => l.Name).HasColumnName("name").HasColumnType("varchar(30)").IsRequired();

            builder.HasKey(l => new { l.LevelId, l.LanguageId });
            builder.HasOne(l => l.Level).WithMany().HasForeignKey(f => f.LevelId).IsRequired();
            builder.HasOne(l => l.Language).WithMany().HasForeignKey(f => f.LanguageId).IsRequired();

            builder.HasData(
                new LevelTranslation { LevelId = 1, LanguageId = 1, Name = "Laag" },
                new LevelTranslation { LevelId = 2, LanguageId = 1, Name = "Gemiddeld" },
                new LevelTranslation { LevelId = 3, LanguageId = 1, Name = "Hoog" },

                new LevelTranslation { LevelId = 1, LanguageId = 2, Name = "Low" },
                new LevelTranslation { LevelId = 2, LanguageId = 2, Name = "Medium" },
                new LevelTranslation { LevelId = 3, LanguageId = 2, Name = "High" }
                );
        }
    }
}
