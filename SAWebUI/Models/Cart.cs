using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SAWebUI.Models
{
    public class Cart
    {
        public int Productid { get; set; }
        public string Productname { get; set; }
        public double Price { get; set; }
        public int Qty { get; set; }
        public double Bill { get; set; }
    }
}
