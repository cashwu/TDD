using System.Threading;
using FluentAutomation;
using FluentAutomation.Exceptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PageObjectsSample.Tests.PageObjects;

namespace PageObjectsSample.Tests
{
    [TestClass]
    public class GoogleSearchTest : FluentTest
    {    
        public GoogleSearchTest()
        {
            SeleniumWebDriver.Bootstrap
                (SeleniumWebDriver.Browser.Chrome
                , SeleniumWebDriver.Browser.Firefox);
            
        }

        [TestMethod]
        public void Test_輸入關鍵字_skilltree_進行搜尋_搜尋結果第一頁應出現skilltree官網的連結()
        {
            
            //arrange
            //到google search首頁
            var googleSearchPage = new GoogleSearchPage(this);
            googleSearchPage.Go();
            
            //act
            //搜尋skilltree
            var keywords = "skilltree";
            googleSearchPage.Search(keywords);

            //assert
            //搜尋結果第一頁應存在"http://skilltree.my/"的連結
            var googleSearchResultsPage = new GoogleSearchResultsPage(this);
            var expectedLink = "http://skilltree.my/";
            googleSearchResultsPage.FindResults(expectedLink);
        }
    }
}