using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;

namespace ViolinShop.Models
{
    public class Calendars
    {
        public int ID { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        public int InstructorID { get; set; }
        public string Period { get; set; }
    }
}
