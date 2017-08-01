using System;
using System.Collections.Generic;

namespace ViolinShop.Models
{
    public partial class RentalHistory
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public DateTime InDate { get; set; }
        public int InsturmentId { get; set; }
        public DateTime OutDate { get; set; }
        public float Rent { get; set; }
        public float TotalRentPaid { get; set; }
    }
}
