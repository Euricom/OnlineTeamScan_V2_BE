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
    public class QuestionConfiguration : Profile, IEntityTypeConfiguration<Question>
    {
        public QuestionConfiguration()
        {

        }

        public void Configure(EntityTypeBuilder<Question> builder)
        {
            builder.ToTable("tbl_questions");
            builder.Property(q => q.Id).HasColumnName("id").ValueGeneratedOnAdd();
            builder.Property(q => q.DysfunctionId).HasColumnName("dysfunction_id").IsRequired();
            builder.Property(d => d.Number).HasColumnName("number").HasColumnType("tinyint").IsRequired();

            builder.HasKey(q => q.Id).IsClustered();
            builder.HasOne(q => q.Dysfunction).WithMany().HasForeignKey(f => f.DysfunctionId).IsRequired();

            builder.HasData(
               new Question { Id = 1, DysfunctionId = 1, Number =  1},
               new Question { Id = 2, DysfunctionId = 2, Number = 2 },
               new Question { Id = 3, DysfunctionId = 5, Number = 3 },
               new Question { Id = 4, DysfunctionId = 2, Number = 4 },
               new Question { Id = 5, DysfunctionId = 2, Number = 5 },
               new Question { Id = 6, DysfunctionId = 1, Number = 6 },
               new Question { Id = 7, DysfunctionId = 2, Number = 7 },
               new Question { Id = 8, DysfunctionId = 4, Number = 8 },
               new Question { Id = 9, DysfunctionId = 5, Number = 9 },
               new Question { Id = 10, DysfunctionId = 1, Number = 10 },
               new Question { Id = 11, DysfunctionId = 3, Number = 11 },
               new Question { Id = 12, DysfunctionId = 2, Number = 12 },
               new Question { Id = 13, DysfunctionId = 1, Number = 13 },
               new Question { Id = 14, DysfunctionId = 5, Number = 14 },
               new Question { Id = 15, DysfunctionId = 5, Number = 15 },
               new Question { Id = 16, DysfunctionId = 4, Number = 16 },
               new Question { Id = 17, DysfunctionId = 1, Number = 17 },
               new Question { Id = 18, DysfunctionId = 2, Number = 18 },
               new Question { Id = 19, DysfunctionId = 3, Number = 19 },
               new Question { Id = 20, DysfunctionId = 4, Number = 20 },
               new Question { Id = 21, DysfunctionId = 4, Number = 21 },
               new Question { Id = 22, DysfunctionId = 1, Number = 22 },
               new Question { Id = 23, DysfunctionId = 2, Number = 23 },
               new Question { Id = 24, DysfunctionId = 3, Number = 24 },
               new Question { Id = 25, DysfunctionId = 5, Number = 25 },
               new Question { Id = 26, DysfunctionId = 4, Number = 26 },
               new Question { Id = 27, DysfunctionId = 2, Number = 27 },
               new Question { Id = 28, DysfunctionId = 3, Number = 28 },
               new Question { Id = 29, DysfunctionId = 5, Number = 29 },
               new Question { Id = 30, DysfunctionId = 3, Number = 30 },
               new Question { Id = 31, DysfunctionId = 5, Number = 31 },
               new Question { Id = 32, DysfunctionId = 1, Number = 32 },
               new Question { Id = 33, DysfunctionId = 1, Number = 33 },
               new Question { Id = 34, DysfunctionId = 3, Number = 34 },
               new Question { Id = 35, DysfunctionId = 4, Number = 35 },
               new Question { Id = 36, DysfunctionId = 4, Number = 36 },
               new Question { Id = 37, DysfunctionId = 5, Number = 37 },
               new Question { Id = 38, DysfunctionId = 3, Number = 38 }
               );
        }
    }
}
