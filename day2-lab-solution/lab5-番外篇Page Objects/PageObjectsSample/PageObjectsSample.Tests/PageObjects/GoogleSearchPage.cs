using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentAutomation;

namespace PageObjectsSample.Tests.PageObjects
{
    public class GoogleSearchPage : PageObject<GoogleSearchPage>
    {
        //#lst-ib
        private const string keywordContainer = "input[name='q']";
        public GoogleSearchPage(FluentTest test)
            : base(test)
        {
            Url = "https://www.google.com";
        }

        internal void Search(string keywords)
        {
            I.Enter(keywords)
                .In(keywordContainer)
                //.Press("{ENTER}");  // 不支援多瀏覽器模式
                //.Click("input[type='submit']"); //chrome可能會被auto-complete影響而點錯位置
                .Append(OpenQA.Selenium.Keys.Enter).To(keywordContainer);
        }
    }
}
