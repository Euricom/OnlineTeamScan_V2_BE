﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Team
    {
        public int Id { get; set; }
        public int TeamleaderId { get; set; }
        public string Name { get; set; }
        public DateTime? LastTeamScan { get; set; }

        public User Teamleader { get; set; }
    }
}
