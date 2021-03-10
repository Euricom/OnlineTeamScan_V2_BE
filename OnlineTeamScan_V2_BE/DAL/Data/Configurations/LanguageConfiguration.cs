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
    public class LanguageConfiguration : Profile, IEntityTypeConfiguration<Language>
    {
        public LanguageConfiguration()
        {

        }

        public void Configure(EntityTypeBuilder<Language> builder)
        {
            builder.ToTable("tbl_languages");
            builder.Property(l => l.Id).HasColumnName("id").ValueGeneratedOnAdd();
            builder.Property(l => l.Name).HasColumnName("name").HasColumnType("varchar(30)").IsRequired();
            builder.Property(l => l.Code).HasColumnName("code").HasColumnType("varchar(3)").IsRequired();

            builder.HasKey(l => l.Id).IsClustered();
            builder.HasIndex(l => new { l.Name, l.Code }).IsUnique();

            builder.HasData(
                new Language { Id = 1, Name = "Nederlands", Code = "nl" }
                );
        }
    }
}
