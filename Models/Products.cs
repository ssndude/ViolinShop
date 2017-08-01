using System;
using System.Collections.Generic;

namespace ViolinShop.Models
{
    public partial class Products
    {
        public Products()
        {
            LineItem = new HashSet<LineItems>();
        }

        public int Id { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public float Price { get; set; }

        public virtual CartItems CartItems { get; set; }
        public virtual ICollection<LineItems> LineItem { get; set; }
    }
}
