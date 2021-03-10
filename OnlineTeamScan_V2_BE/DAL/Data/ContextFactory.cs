using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Data
{
    public class ContextFactory : IDesignTimeDbContextFactory<OnlineTeamScanContext>
    {
        public OnlineTeamScanContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile(@Directory.GetCurrentDirectory() + "/../API/appsettings.json").Build();
            var builder = new DbContextOptionsBuilder<OnlineTeamScanContext>();
            var connectionString = configuration.GetConnectionString("OnlineTeamScanConnectionString");
            builder.UseSqlServer(connectionString);
            return new OnlineTeamScanContext(builder.Options);
        }
    }
}
