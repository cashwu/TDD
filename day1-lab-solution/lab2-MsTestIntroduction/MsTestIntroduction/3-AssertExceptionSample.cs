using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MsTestIntroduction
{
    /// <summary>
    /// AssertExceptionSample 的摘要描述
    /// </summary>
    [TestClass]
    public class AssertExceptionSample
    {
        public AssertExceptionSample()
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
        #endregion

        [TestMethod()]
        // 標記忽略
        [Ignore]
        public void 驗證Exception千萬別這樣幹()
        {
            var expected = "Attempted to divide by zero.";
            var actual = "";
            try
            {
                var zero = 0;
                var result = 1 / zero;
            }
            catch (DivideByZeroException ex)
            {
                actual = ex.Message;
            }

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(DivideByZeroException))]
        public void 該怎麼驗證Exception()
        {
            // 應使用[ExpectedException(type)]來判斷是否有拋出預期的例外
            // 當沒有發生例外時，會 Assert Failed
            var zero = 0;
            var result = 1 / zero;
        }
    }
}
