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
    public class TeamMemberConfiguration : Profile, IEntityTypeConfiguration<Team>
    {
        public TeamMemberConfiguration()
        {

        }

        public void Configure(EntityTypeBuilder<Team> builder)
        {
            throw new NotImplementedException();
        }
    }
}
