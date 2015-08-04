using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MsTestIntroduction
{
    /// <summary>
    /// UnitTest1 的摘要描述
    /// </summary>
    [TestClass]
    public class UnitTestEventHook
    {
        public UnitTestEventHook()
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

        [AssemblyInitialize()]
        public static void MyAssemblyInitialize(TestContext testContext)
        {
            Console.WriteLine("AssemblyInitialize: {0}", counter.ToString());
            counter++;
        }

        [AssemblyCleanup()]
        public static void MyAssemblyCleanup()
        {
            Console.WriteLine("AssemblyCleanup: {0}", counter.ToString());
            counter++;
        }

        // 執行該類別中第一項測試前，使用 ClassInitialize 執行程式碼
        [ClassInitialize()]
        public static void MyClassInitialize(TestContext testContext)
        {
            Console.WriteLine("ClassInitialize: {0}", counter.ToString());
            counter++;
        }

        // 在類別中的所有測試執行後，使用 ClassCleanup 執行程式碼
        [ClassCleanup()]
        public static void MyClassCleanup()
        {
            Console.WriteLine("ClassCleanup: {0}", counter.ToString());
            counter++;
        }

        // 在執行每一項測試之前，先使用 TestInitialize 執行程式碼
        [TestInitialize()]
        public void MyTestInitialize()
        {
            Console.WriteLine("TestInitialize: {0}", counter.ToString());
            counter++;
        }

        // 在執行每一項測試之後，使用 TestCleanup 執行程式碼
        [TestCleanup()]
        public void MyTestCleanup()
        {
            Console.WriteLine("TestCleanup: {0}", counter.ToString());
            counter++;
        }

        #endregion 其他測試屬性

        // 將測試總管裡面的群組依據，選成類別，針對UnitTestEventHook執行偵錯測試
        // 請針對每一個 event hook 下中斷點去觀察事件順序
        // 最後觀察TestMethod1跟TestMethod2兩個測試結果的輸出，可以看到各 event 記錄的值
        private static int counter = 0;

        [TestMethod]
        public void TestMethod1()
        {
            Console.WriteLine("TestMethod1: {0}", counter.ToString());
            counter++;
        }

        [TestMethod]
        public void TestMethod2()
        {
            Console.WriteLine("TestMethod2: {0}", counter.ToString());
            counter++;
        }
    }
}