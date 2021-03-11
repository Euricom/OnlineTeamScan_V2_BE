using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Question
    {
        public int Id { get; set; }
        public int DysfunctionId { get; set; }
        public byte Number { get; set; }

        public Dysfunction Dysfunction { get; set; }
    }
}
