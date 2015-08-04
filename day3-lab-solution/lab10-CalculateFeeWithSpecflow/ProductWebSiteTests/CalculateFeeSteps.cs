using System;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using TechTalk.SpecFlow;

namespace ProductWebSiteTests
{
    [Binding]
    public class CalculateFeeSteps
    {
        private IWebDriver driver;
        private StringBuilder verificationErrors;
        private string baseURL;
        private bool acceptNextAlert = true;

        [BeforeScenario]
        public void BeforeScenario()
        {
            driver = new FirefoxDriver();
            baseURL = "http://localhost:16207/";
            verificationErrors = new StringBuilder();
        }

        [AfterScenario]
        public void AfterScenario()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
            Assert.AreEqual("", verificationErrors.ToString());
        }

        [Given(@"在商品頁面")]
        public void Given在商品頁面()
        {
            driver.Navigate().GoToUrl(baseURL + "/Product.aspx");
        }

        [Given(@"商品名稱輸入 (.*)")]
        public void Given商品名稱輸入(string name)
        {
            driver.FindElement(By.Id("MainContent_txtProductName")).Clear();
            driver.FindElement(By.Id("MainContent_txtProductName")).SendKeys(name);
        }

        [Given(@"重量輸入 (.*)")]
        public void Given重量輸入(int weight)
        {
            driver.FindElement(By.Id("MainContent_txtProductWeight")).Clear();
            driver.FindElement(By.Id("MainContent_txtProductWeight")).SendKeys(weight.ToString());
        }

        [Given(@"長輸入 (.*)")]
        public void Given長輸入(int length)
        {
            driver.FindElement(By.Id("MainContent_txtProductLength")).Clear();
            driver.FindElement(By.Id("MainContent_txtProductLength")).SendKeys(length.ToString());
        }

        [Given(@"寬輸入 (.*)")]
        public void Given寬輸入(int width)
        {
            driver.FindElement(By.Id("MainContent_txtProductWidth")).Clear();
            driver.FindElement(By.Id("MainContent_txtProductWidth")).SendKeys(width.ToString());
        }

        [Given(@"高輸入 (.*)")]
        public void Given高輸入(int height)
        {
            driver.FindElement(By.Id("MainContent_txtProductHeight")).Clear();
            driver.FindElement(By.Id("MainContent_txtProductHeight")).SendKeys(height.ToString());
        }

        [Given(@"物流商選擇 (.*)")]
        public void Given物流商選擇(string shipper)
        {
            new SelectElement(driver.FindElement(By.Id("MainContent_drpCompany"))).SelectByText(shipper);
        }

        [When(@"按下計算運費的按鈕")]
        public void When按下計算運費的按鈕()
        {
            driver.FindElement(By.Id("MainContent_btnCalculate")).Click();
        }

        [Then(@"物流商名稱應為 (.*)")]
        public void Then物流商名稱應為(string shipperName)
        {
            Assert.AreEqual(shipperName, driver.FindElement(By.Id("MainContent_lblCompany")).Text);
        }

        [Then(@"運費結果應為 (.*)")]
        public void Then運費結果應為(double fee)
        {
            Assert.AreEqual(fee.ToString(), driver.FindElement(By.Id("MainContent_lblCharge")).Text);
        }
    }
}