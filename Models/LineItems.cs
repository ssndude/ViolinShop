using System;
using System.Collections.Generic;

namespace ViolinShop.Models
{
    public partial class LineItems
    {
        public LineItems(int ID)
        {
            Id = ID;
        }

        public int Id { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }

        public virtual Products Product { get; set; }
    }
}
