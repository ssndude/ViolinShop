using System;
using System.Collections.Generic;

namespace ViolinShop.Models
{
    public partial class CartItems
    {
        public int Id { get; set; }
        public string CartId { get; set; }
        public int? Quantity { get; set; }
        public DateTime? DateCreated { get; set; }
        public int? ProductId { get; set; }

        public virtual Products IdNavigation { get; set; }
    }
}
