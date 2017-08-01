using System;
using System.Collections.Generic;

namespace ViolinShop.Models
{
    public partial class InstructorInstruments
    {
        public int Id { get; set; }
        public int InstructorId { get; set; }
        public int InstrumentId { get; set; }
    }
}
