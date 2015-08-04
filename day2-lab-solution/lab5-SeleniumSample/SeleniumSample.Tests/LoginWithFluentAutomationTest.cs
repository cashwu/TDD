using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAutomation;
using System.IO;

namespace SeleniumSample.Tests
{
    /// <summary>
    /// LoginWithFluentAutomationTest 的摘要描述
    /// </summary>
    [TestClass]
    public class LoginWithFluentAutomationTest : FluentTest
    {
        private string baseUrl = @"http://localhost:29021/";

        public LoginWithFluentAutomationTest()
        {
            // 要用多瀏覽器跑web測試時，只需要加入Bootstrap()中即可
            SeleniumWebDriver.Bootstrap(
                //SeleniumWebDriver.Browser.Chrome
                SeleniumWebDriver.Browser.Firefox
                //SeleniumWebDriver.Browser.InternetExplorer
            );

            var path = @"C:\SkillTreeScreenShot";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            Config.ScreenshotOnFailedAction(true)
                .ScreenshotPath(path);
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

        [TestMethod]
        public void TestLoginSuccess_帳號輸入joey_密碼輸入1234_應導到首頁()
        {
            // 我打開 Login 的網頁 => Open
            // 在 id 裡面輸入 joey => Enter, In
            // 在 password 裡面輸入 1234 => Enter, In
            // 按下登入 => Click
            // 期望應該導到首頁   => Assert, Url    

            I.Open(baseUrl + "login")
                .Enter("joey").In("#id")
                .Enter("1234").In("#password")
                .Click("input[type=\"submit\"]")
                .Assert.Url(baseUrl);

            //I.TakeScreenshot("login success");
        }

        [TestMethod]
        public void TestLoginFailed_帳號輸入joey_密碼輸入abc_應出現訊息為_帳號或密碼有誤()
        {
            // 我打開 Login 的網頁 => Open
            // 在 id 裡面輸入 joey => Enter, In
            // 在 password 裡面輸入 abc => Enter, In
            // 按下登入 => Click
            // 期望畫面應該出現 "帳號或密碼有誤" 的訊息 => Assert, Text, In
            I.Open(baseUrl + "login")
                .Enter("joey").In("#id")
                .Enter("abc").In("#password")
                .Click("input[type=\"submit\"]")
                .Assert.Text("帳號或密碼有誤").In("#message");

            //I.TakeScreenshot("login failed");
        }
    }
}
