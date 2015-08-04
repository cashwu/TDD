using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MsTestIntroduction
{
    /// <summary>
    /// CollectionAssertSample 的摘要描述
    /// </summary>
    [TestClass]
    public class CollectionAssertSample
    {
        public CollectionAssertSample()
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

        [TestMethod()]
        public void 驗證Collection_集合內按照順序_每個項目是否相等()
        {
            var actual = new int[] { 1, 3, 5 };
            var expected = new int[] { 1, 3, 5 };

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void 驗證Collection_集合內容是否相等_不管順序()
        {
            // 兩個集合個數一樣，順序不一樣
            var actual = new int[] { 1, 3, 5 };
            var expected = new int[] { 3, 5, 1 };

            CollectionAssert.AreEquivalent(expected, actual);
        }

        [TestMethod()]
        public void 驗證Collection_是否為子集合()
        {            
            var superset = new int[] { 1, 3, 5 };
            var subset = new int[] { 5, 3 };

	        CollectionAssert.IsSubsetOf(subset, superset);
        }

        [TestMethod()]
        public void 驗證Collection_集合內項目是否唯一()
        {
			//var actual = new int[] { 1, 1, 3, 5 };
			var actual = new int[] { 1, 3, 5 };

            CollectionAssert.AllItemsAreUnique(actual);
        }
    }
}