using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodayIsMyDay;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace TodayIsMyDay.Tests
{
    [TestClass()]
    public class HolidayTests
    {
        [TestMethod()]
        public void IsTodayXmasTest_假如今天是聖誕節_應回傳MerryXmas()
        {
            var holiday = new Holiday(new DateTime(2015,12,25));

            var expected = "Merry Xmas!!";

            var actual = holiday.IsTodayXmas();

            // 請想辦法通過測試，今天是聖誕節的情境
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void IsTodayXmasTest_假如今天不是聖誕節_應回傳Today_is_not_Xmas()
        {
            var holiday = new Holiday(DateTime.Now);

            var expected = "Today is not Xmas";

            var actual = holiday.IsTodayXmas();
            
            Assert.AreEqual(expected, actual);
        }
    }
}
