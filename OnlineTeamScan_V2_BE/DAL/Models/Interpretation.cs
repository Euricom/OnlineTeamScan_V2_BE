using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Interpretation
    {
        public int Id { get; set; }
        public int DysfunctionId { get; set; }
        public int LevelId { get; set; }

        public Dysfunction Dysfunction { get; set; }
        public Level Level { get; set; }
    }
}
