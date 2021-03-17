using AutoMapper;
using Common.DTOs.DysfunctionTranslationDTO;
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
    public class DysfunctionTranslationConfiguration : Profile, IEntityTypeConfiguration<DysfunctionTranslation>
    {
        public DysfunctionTranslationConfiguration()
        {
            CreateMap<DysfunctionTranslation, DysfunctionTranslationReadDto>();
        }

        public void Configure(EntityTypeBuilder<DysfunctionTranslation> builder)
        {
            builder.ToTable("tbl_dysfunction_translations");
            builder.Property(d => d.DysfunctionId).HasColumnName("dysfunction_id").IsRequired();
            builder.Property(d => d.LanguageId).HasColumnName("language_id").IsRequired();
            builder.Property(d => d.Name).HasColumnName("name").HasColumnType("varchar(50)").IsRequired();

            builder.HasKey(d => new { d.DysfunctionId, d.LanguageId });
            builder.HasOne(d => d.Dysfunction).WithMany().HasForeignKey(f => f.DysfunctionId).IsRequired();
            builder.HasOne(d => d.Language).WithMany().HasForeignKey(f => f.LanguageId).IsRequired();

            builder.HasData(
                new DysfunctionTranslation { DysfunctionId = 1, LanguageId = 1, Name = "Vertrouwen" },
                new DysfunctionTranslation { DysfunctionId = 2, LanguageId = 1, Name = "Conflict" },
                new DysfunctionTranslation { DysfunctionId = 3, LanguageId = 1, Name = "Commitment" },
                new DysfunctionTranslation { DysfunctionId = 4, LanguageId = 1, Name = "Aanspreekbaarheid" },
                new DysfunctionTranslation { DysfunctionId = 5, LanguageId = 1, Name = "Resultaat" },

                new DysfunctionTranslation { DysfunctionId = 1, LanguageId = 2, Name = "Trust" },
                new DysfunctionTranslation { DysfunctionId = 2, LanguageId = 2, Name = "Conflict" },
                new DysfunctionTranslation { DysfunctionId = 3, LanguageId = 2, Name = "Commitment" },
                new DysfunctionTranslation { DysfunctionId = 4, LanguageId = 2, Name = "Accountability" },
                new DysfunctionTranslation { DysfunctionId = 5, LanguageId = 2, Name = "Results" }
                );
        }
    }
}
