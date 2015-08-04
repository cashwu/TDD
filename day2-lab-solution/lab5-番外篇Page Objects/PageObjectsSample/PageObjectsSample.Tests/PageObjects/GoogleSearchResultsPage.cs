using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentAutomation;

namespace PageObjectsSample.Tests.PageObjects
{
    public class GoogleSearchResultsPage : PageObject<GoogleSearchResultsPage>
    {
        private const string linkContainer = "a[href='{0}']";
        public GoogleSearchResultsPage(FluentTest test)
            : base(test)
        {

        }

        internal void FindResults(string expectedLink)
        {
            I.Assert
                .Exists(string.Format(linkContainer, expectedLink));
        }
    }
}
