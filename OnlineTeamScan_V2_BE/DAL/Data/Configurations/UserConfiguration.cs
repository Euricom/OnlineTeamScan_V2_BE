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
            builder.Property(t => t.Id).ValueGeneratedOnAdd();

            builder.HasKey(t => t.Id).IsClustered();
        }
    }
}
