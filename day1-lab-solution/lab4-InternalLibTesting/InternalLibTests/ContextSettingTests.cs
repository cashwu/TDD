using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InternalLib;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace InternalLib.Tests
{
    [TestClass()]
    public class ContextSettingTests
    {       
        [TestMethod()]
        public void GetConnectionStringTest()
        {
            var target = new ContextSetting();
            var expected = "my connection string";
            var actual = target.GetConnectionString();
            Assert.AreEqual(expected, actual);
        }
    }
}
