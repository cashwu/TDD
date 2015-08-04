using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyLib
{
    public class OrderService
    {

        private MyLibNorthwind dbContext;

        public IEnumerable<MyOrder> Query(OrderQueryCondition condition)
        {
            throw new NotImplementedException();
            //using (dbContext = new MyLibNorthwind())
            //{
            //    var orders = dbContext.Orders.Where(x => x.CustomerID == condition.CustomerId);

            //    if (condition.OrderDateStart != null)
            //    {
            //        orders = orders.Where(x => x.OrderDate >= condition.OrderDateStart);
            //    }

            //    if (condition.OrderDateEnd != null)
            //    {
            //        orders = orders.Where(x => x.OrderDate <= condition.OrderDateEnd);
            //    }

            //    return orders.Select(x => new MyOrder
            //        {
            //            CustomerID = x.CustomerID.Trim(),
            //            OrderDate = x.OrderDate,
            //            ShipCity = x.ShipCity
            //        }).ToList();
            //}
        }
    }
}
