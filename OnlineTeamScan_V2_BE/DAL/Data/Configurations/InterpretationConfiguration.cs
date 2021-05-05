using AutoMapper;
using Common.DTOs.InterpretationDTO;
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
    public class InterpretationConfiguration : Profile, IEntityTypeConfiguration<Interpretation>
    {
        public InterpretationConfiguration()
        {
            CreateMap<Interpretation, InterpretationReadDto>();
        }

        public void Configure(EntityTypeBuilder<Interpretation> builder)
        {
            builder.ToTable("tbl_interpretations");
            builder.Property(i => i.Id).HasColumnName("id").ValueGeneratedOnAdd();
            builder.Property(i => i.DysfunctionId).HasColumnName("dysfunction_id").IsRequired();
            builder.Property(i => i.LevelId).HasColumnName("level_id").IsRequired();

            builder.HasKey(i => i.Id).IsClustered();
            builder.HasOne(i => i.Dysfunction).WithMany().HasForeignKey(f => f.DysfunctionId).IsRequired();
            builder.HasOne(i => i.Level).WithMany().HasForeignKey(f => f.LevelId).IsRequired();

            builder.HasData(
                new Interpretation { Id = 1, DysfunctionId = 1, LevelId = 1},
                new Interpretation { Id = 2, DysfunctionId = 1, LevelId = 2},
                new Interpretation { Id = 3, DysfunctionId = 1, LevelId = 3},

                new Interpretation { Id = 4, DysfunctionId = 2, LevelId = 1 },
                new Interpretation { Id = 5, DysfunctionId = 2, LevelId = 2 },
                new Interpretation { Id = 6, DysfunctionId = 2, LevelId = 3 },

                new Interpretation { Id = 7, DysfunctionId = 3, LevelId = 1 },
                new Interpretation { Id = 8, DysfunctionId = 3, LevelId = 2 },
                new Interpretation { Id = 9, DysfunctionId = 3, LevelId = 3 },

                new Interpretation { Id = 10, DysfunctionId = 4, LevelId = 1 },
                new Interpretation { Id = 11, DysfunctionId = 4, LevelId = 2 },
                new Interpretation { Id = 12, DysfunctionId = 4, LevelId = 3 },

                new Interpretation { Id = 13, DysfunctionId = 5, LevelId = 1 },
                new Interpretation { Id = 14, DysfunctionId = 5, LevelId = 2 },
                new Interpretation { Id = 15, DysfunctionId = 5, LevelId = 3 }
                );
        }
    }
}
