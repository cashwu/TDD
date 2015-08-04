using System;
using TechTalk.SpecFlow;
using MyLib;
using SpecFlowWithEf.Tests.ModelInTest;
using System.Collections.Generic;
using TechTalk.SpecFlow.Assist;

namespace SpecFlowWithEf.Tests
{
    [Binding]
    [Scope(Feature = "OrderQuery")]
    public class OrderQuerySteps
    {
        private OrderService target;
        private NorthwindEntitiesInTest dbContext;
        [BeforeScenario]
        public void BeforeScenario()
        {
            this.target = new OrderService();
            using (dbContext = new NorthwindEntitiesInTest())
            {
                dbContext.Database.ExecuteSqlCommand("Delete [Orders] Where CustomerID IN ('Joey','JoeyTest')");
                dbContext.Database.ExecuteSqlCommand("Delete [Customers] Where CustomerID IN('Joey','JoeyTest')");
            }
        }

        [AfterScenario]
        public void AfterScenario()
        {
            using (dbContext = new NorthwindEntitiesInTest())
            {
                dbContext.Database.ExecuteSqlCommand("Delete [Orders] Where CustomerID IN ('Joey','JoeyTest')");
                dbContext.Database.ExecuteSqlCommand("Delete [Customers] Where CustomerID IN('Joey','JoeyTest')");
            }
        }

        [Given(@"查詢條件為")]
        public void Given查詢條件為(Table table)
        {
            var condition = table.CreateInstance<OrderQueryCondition>();
            ScenarioContext.Current.Set<OrderQueryCondition>(condition);

        }

        [Given(@"預計Customers資料應有")]
        public void Given預計Customers資料應有(Table table)
        {
            var customers = table.CreateSet<SpecFlowWithEf.Tests.ModelInTest.Customers>();

            using (dbContext = new NorthwindEntitiesInTest())
            {
                foreach (var customer in customers)
                {
                    dbContext.Customers.Add(customer);
                }
                dbContext.SaveChanges();
            }
        }


        [Given(@"預計Orders資料應有")]
        public void Given預計Orders資料應有(Table table)
        {
            var orders = table.CreateSet<SpecFlowWithEf.Tests.ModelInTest.Orders>();

            using (dbContext = new NorthwindEntitiesInTest())
            {
                foreach (var order in orders)
                {
                    dbContext.Orders.Add(order);
                }
                dbContext.SaveChanges();
            }
        }

        [When(@"呼叫Query方法")]
        public void When呼叫Query方法()
        {
            var condition = ScenarioContext.Current.Get<OrderQueryCondition>();

            //service回傳的，不一定需要是 dbContext 中 EF 產生的 model 型別
            IEnumerable<MyOrder> actual = this.target.Query(condition);

            ScenarioContext.Current.Set<IEnumerable<MyOrder>>(actual);
        }

        [Then(@"查詢結果應為")]
        public void Then查詢結果應為(Table table)
        {
            var actual = ScenarioContext.Current.Get<IEnumerable<MyOrder>>();

            table.CompareToSet<MyOrder>(actual);
        }
    }
}
