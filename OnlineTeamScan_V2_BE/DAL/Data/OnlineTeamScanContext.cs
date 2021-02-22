using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Data
{
    public class OnlineTeamScanContext : DbContext
    {
        public OnlineTeamScanContext(DbContextOptions<OnlineTeamScanContext> opt) : base(opt)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
        }
    }
}
