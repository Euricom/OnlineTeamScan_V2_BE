using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Recommendation
    {
        public int Id { get; set; }
        public int DysfunctionId { get; set; }
        public string Link { get; set; }

        public Dysfunction Dysfunction { get; set; }
    }
}
