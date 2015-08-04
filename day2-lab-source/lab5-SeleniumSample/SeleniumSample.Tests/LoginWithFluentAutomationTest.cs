using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAutomation;
using FluentAutomation.Exceptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SeleniumSample.Tests
{
    [TestClass]
    public class LoginWithFluentAutomationTest : FluentTest
    {
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

        private string baseUrl = @"http://localhost:29021/";

        public LoginWithFluentAutomationTest()
        {
            // 要用多瀏覽器跑web測試時，只需要加入Bootstrap()中即可
            SeleniumWebDriver.Bootstrap(
                SeleniumWebDriver.Browser.Chrome
                //SeleniumWebDriver.Browser.Firefox
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

        [TestMethod]
        public void TestLoginSuccess_帳號輸入joey_密碼輸入1234_應導到首頁()
        {
            // 我打開 Login 的網頁 => Open
            // 在 id 裡面輸入 joey => Enter, In
            // 在 password 裡面輸入 1234 => Enter, In
            // 按下登入 => Click
            // 期望應該導到首頁   => Assert, Url       

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

            //I.TakeScreenshot("login failed");
        }
    }
}