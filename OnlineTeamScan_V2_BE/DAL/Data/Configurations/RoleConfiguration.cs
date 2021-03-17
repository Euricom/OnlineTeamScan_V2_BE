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
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.ToTable("tbl_roles");
            builder.Property(item => item.Id).HasColumnName("id").ValueGeneratedOnAdd();
            builder.Property(item => item.Name).HasColumnName("name").HasColumnType("varchar(30)").IsRequired();
            builder.Property(item => item.DisplayLabel).HasColumnName("display_label").HasColumnType("varchar(30)").IsRequired();

            builder.HasIndex(item => item.Name).IsUnique();
 
            builder.HasData(
                new Role { Id = 1, Name = "Teamleader", DisplayLabel = "Teamleader" }
            );
        }
    }
}
