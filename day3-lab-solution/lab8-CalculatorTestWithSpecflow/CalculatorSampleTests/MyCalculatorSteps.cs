using System;
using TechTalk.SpecFlow;
using CalculatorSample;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CalculatorSampleTests
{
    [Binding]
    public class MyCalculatorSteps
    {
        private MyCalculator target;

        [BeforeScenario]
        public void BeforeScenario()
        {
            //arrange
            this.target = new MyCalculator();
        }

        [Given(@"在第一個輸入項輸入 (.*)")]
        public void Given在第一個輸入項輸入(int first)
        {
            //arrange
            ScenarioContext.Current.Set<int>(first, "first");
        }

        [Given(@"在第二個輸入項輸入 (.*)")]
        public void Given在第二個輸入項輸入(int second)
        {
            //arrange
            ScenarioContext.Current.Set<int>(second, "second");
        }

        [When(@"按下 Add 按鈕")]
        public void When按下Add按鈕()
        {
            //act
            var first = ScenarioContext.Current.Get<int>("first");
            var second = ScenarioContext.Current.Get<int>("second");

            var actual = this.target.Add(first, second);
            ScenarioContext.Current.Set<int>(actual, "result");
        }

        [Then(@"螢幕上的結果應為 (.*)")]
        public void Then螢幕上的結果應為(int expected)
        {
            //assert
            var actual = ScenarioContext.Current.Get<int>("result");
            Assert.AreEqual(expected, actual);
        }
    }
}
