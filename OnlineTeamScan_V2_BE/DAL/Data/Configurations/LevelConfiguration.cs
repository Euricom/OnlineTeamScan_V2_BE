using AutoMapper;
using Common.DTOs.LevelDTO;
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
    public class LevelConfiguration : Profile, IEntityTypeConfiguration<Level>
    {
        public LevelConfiguration()
        {
            CreateMap<Level, LevelReadDto>();
        }

        public void Configure(EntityTypeBuilder<Level> builder)
        {
            builder.ToTable("tbl_levels");
            builder.Property(l => l.Id).HasColumnName("id").ValueGeneratedOnAdd();
            builder.Property(l => l.LowerLimit).HasColumnName("lower_limit").HasColumnType("decimal(3,2)").IsRequired();
            builder.Property(l => l.UpperLimit).HasColumnName("upper_limit").HasColumnType("decimal(3,2)").IsRequired();
            builder.Property(l => l.Color).HasColumnName("color").HasColumnType("char(7)").IsRequired();

            builder.HasKey(l => l.Id).IsClustered();

            builder.HasData(
                new Level { Id = 1, LowerLimit = 1m, UpperLimit = 3.24m, Color = "#F95656" },
                new Level { Id = 2, LowerLimit = 3.25m, UpperLimit = 3.74m, Color = "#FFD54A" },
                new Level { Id = 3, LowerLimit = 3.75m, UpperLimit = 5m, Color = "#93EB5F" },
                new Level { Id = 4, LowerLimit = 0m, UpperLimit = 0m, Color = "#D8D8D8" }
                );
        }
    }
}
