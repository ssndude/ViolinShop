using System.IO;
using System.Numerics;

namespace ViolinShop.Models
{
    public class Instruments
    {
        public int ID { get; set; }
        public int TypeID { get; set; }
        public bool ForSale { get; set; }
        public bool ForRent { get; set; }
        public float Price { get; set; }
        public float Rent { get; set; }
        public bool Available { get; set; }
        public string Image { get; set; }
        public int ProductID { get; set; }

        // extension method
    }

}
