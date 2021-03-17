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
    public class UserConfiguration : Profile, IEntityTypeConfiguration<User>
    {
        public UserConfiguration()
        {

        }

        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("tbl_users");
            builder.Property(u => u.Id).HasColumnName("id").ValueGeneratedOnAdd();
            builder.Property(u => u.PreferredLanguageId).HasColumnName("preferred_language_id").HasDefaultValue(1).IsRequired();
            builder.Property(u => u.Email).HasColumnName("email").HasColumnType("varchar(100)").IsRequired();
            builder.Property(u => u.Firstname).HasColumnName("firstname").HasColumnType("varchar(70)").IsRequired();
            builder.Property(u => u.Lastname).HasColumnName("lastname").HasColumnType("varchar(70)").IsRequired();
            builder.Property(u => u.Password).HasColumnName("password").HasColumnType("varchar(50)").IsRequired();

            builder.HasKey(u => u.Id).IsClustered();
            builder.HasOne(u => u.PreferredLanguage).WithMany().HasForeignKey(f => f.PreferredLanguageId).IsRequired();
            builder.HasIndex(u => u.Email).IsUnique();
        }
    }
}
