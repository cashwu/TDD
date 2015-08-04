using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyLib
{
    public class MyOrder
    {
        public string CustomerID { get; set; }

        public DateTime? OrderDate { get; set; }

        public string ShipCity { get; set; }
    }
}
