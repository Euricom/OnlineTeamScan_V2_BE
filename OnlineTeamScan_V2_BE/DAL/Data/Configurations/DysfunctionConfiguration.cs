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
    public class DysfunctionConfiguration : Profile, IEntityTypeConfiguration<Dysfunction>
    {
        public DysfunctionConfiguration()
        {

        }

        public void Configure(EntityTypeBuilder<Dysfunction> builder)
        {
            builder.ToTable("tbl_dysfunctions");
            builder.Property(d => d.Id).HasColumnName("id").ValueGeneratedOnAdd();

            builder.HasKey(t => t.Id).IsClustered();

            builder.HasData(
                new Dysfunction { Id = 1 },
                new Dysfunction { Id = 2 },
                new Dysfunction { Id = 3 },
                new Dysfunction { Id = 4 },
                new Dysfunction { Id = 5 }
                );
        }
    }
}
