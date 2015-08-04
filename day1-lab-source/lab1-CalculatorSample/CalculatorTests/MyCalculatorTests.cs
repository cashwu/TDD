using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Calculator;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace Calculator.Tests
{
	[TestClass()]
	public class MyCalculatorTests
	{
		[TestMethod()]
		public void 傳入1跟2然後回傳3()
		{
			//arrange
			var target = new MyCalculator();
			var first = 1;
			var second = 2;

			var expected = 3;
			//act
			var actual = target.Add(first, second);
			//assert

			Assert.AreEqual(expected, actual);
		}
	}
}
