using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MsTestIntroduction
{
	/// <summary>
	/// AssertSample 的摘要描述
	/// </summary>
	[TestClass]
	public class AssertSample
	{
		public AssertSample()
		{
			//
			// TODO:  在此加入建構函式的程式碼
			//
		}

		private TestContext testContextInstance;

		/// <summary>
		///取得或設定提供目前測試回合
		///的相關資訊與功能的測試內容。
		///</summary>
		public TestContext TestContext
		{
			get
			{
				return testContextInstance;
			}
			set
			{
				testContextInstance = value;
			}
		}

		#region 其他測試屬性

		//
		// 您可以使用下列其他屬性撰寫您的測試:
		//
		// 執行該類別中第一項測試前，使用 ClassInitialize 執行程式碼
		// [ClassInitialize()]
		// public static void MyClassInitialize(TestContext testContext) { }
		//
		// 在類別中的所有測試執行後，使用 ClassCleanup 執行程式碼
		// [ClassCleanup()]
		// public static void MyClassCleanup() { }
		//
		// 在執行每一項測試之前，先使用 TestInitialize 執行程式碼
		// [TestInitialize()]
		// public void MyTestInitialize() { }
		//
		// 在執行每一項測試之後，使用 TestCleanup 執行程式碼
		// [TestCleanup()]
		// public void MyTestCleanup() { }
		//

		#endregion 其他測試屬性

		[TestMethod]
		public void Test_Assert_AreSame_string()
		{
			//等同Assert.IsTrue(Object.RefrenceEquals(a,b))
			var i = 1;

			var a = i.ToString();
			var b = i.ToString();

			Assert.AreNotSame(a, b);
		}

		[TestMethod]
		public void Test_Assert_AreEqual_string()
		{
			//等同Assert.IsTrue(Object.Equals(a,b))
			var i = 1;

			var a = i.ToString();
			var b = i.ToString();

			Assert.AreEqual(a, b);
		}

		[TestMethod]
		public void Test_Assert_AreSame_value_type()
		{
			var a = 1;
			var b = 1;

			Assert.AreNotSame(a, b);
		}

		[TestMethod]
		public void Test_Assert_AreEqual_value_type()
		{
			var a = 1;
			var b = 1;

			Assert.AreEqual(a, b);
		}

		[TestMethod]
		public void Test_Assert_AreSame_reference_type()
		{
			var a = new Person { Id = 1 };
			var b = new Person { Id = 1 };

			Assert.AreNotSame(a, b);
		}

		[TestMethod]
		public void Test_Assert_AreEqual_reference_type()
		{
			var a = new Person { Id = 1 };
			var b = new Person { Id = 1 };

			Assert.AreEqual(a, b);
		}
	}

	//public class Person
	//{
	//	public int Id { get; set; }
	//}

	public class Person : IEquatable<Person>
	{
		public int Id { get; set; }

		public override bool Equals(object obj)
		{
			var p = obj as Person;
			if (p != null)
			{
				return this.Equals(p);
			}

			return false;
		}

		public override int GetHashCode()
		{
			return this.Id.GetHashCode();
		}

		public bool Equals(Person other)
		{
			if (other == null)
			{
				return false;
			}

			return this.Id == other.Id;
		}
	}
}