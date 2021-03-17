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
    class UserRoleConfiguration : IEntityTypeConfiguration<UserRole>
    {
        public void Configure(EntityTypeBuilder<UserRole> builder)
        {
            builder.ToTable("tbl_user_roles");
            builder.Property(item => item.UserId).HasColumnName("user_id").IsRequired();
            builder.Property(item => item.RoleId).HasColumnName("role_id").IsRequired();

            builder.HasOne(item => item.User).WithMany().IsRequired();
            builder.HasOne(item => item.Role).WithMany().IsRequired();

            builder.HasKey(item => new { item.UserId, item.RoleId });
        }
    }
}
