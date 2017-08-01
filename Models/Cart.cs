using System;
using System.Collections.Generic;

namespace ViolinShop.Models
{
    public partial class Cart
    {
        public int CartId { get; set; }
        public byte[] CartContents { get; set; }
    }
}
