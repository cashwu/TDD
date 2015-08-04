using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LogisticLib
{
    public class Blackcat : IShipper
    {
        public void CalculateFee(ShippingProduct product)
        {
            var weight = product.Weight;
            if (weight > 20)
            {
                product.ShippingFee = 500;
            }
            else
            {
                product.ShippingFee = 100 + weight * 10;
            }
        }

        public string Name
        {
            get { return "黑貓"; }
        }
    }
}