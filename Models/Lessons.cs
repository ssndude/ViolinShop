using System;
using System.Collections.Generic;

namespace ViolinShop.Models
{
    public partial class Lessons
    {
        public int Id { get; set; }
        public int CalendarId { get; set; }
        public int CustomerId { get; set; }
        public int InstructorId { get; set; }
        public int InsturmentId { get; set; }
        public DateTime Lessondatetime { get; set; }
        public int MusicId { get; set; }
    }
}
