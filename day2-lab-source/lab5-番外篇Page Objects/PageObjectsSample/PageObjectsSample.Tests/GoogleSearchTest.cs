using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PageObjectsSample.Tests
{
    [TestClass]
    public class GoogleSearchTest
    {
        [TestMethod]
        public void Test_輸入關鍵字_skilltree_進行搜尋_搜尋結果第一頁應出現skilltree官網的連結()
        {
            //arrange
            //到google search首頁

            //act
            //搜尋skilltree

            //assert
            //搜尋結果第一頁應存在"http://skilltree.my/"的連結
        }
    }
}