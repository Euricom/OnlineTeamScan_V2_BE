using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Team : IModel
    {
        public int Id { get; set; }
        public string TeamName { get; set; }
        public DateTime LastTeamScan { get; set; }
    }
}
