using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechTalk.SpecFlow;

namespace PartimeSalaryWithTdd.Tests
{
    [Binding]
    public class ParttimeSalarySteps
    {
        private SalaryCard target;

        [BeforeScenario]
        public void BeforeScenario()
        {
            this.target = new SalaryCard();
        }

        [Given(@"正常上班一小時薪資為 (.*)")]
        public void Given正常上班一小時薪資為(int hourlySalary)
        {
            target.HourlySalary = hourlySalary;
        }

        [Given(@"上班時間為 ""(.*)""")]
        public void Given上班時間時間為(DateTime startTime)
        {
            target.StartTime = startTime;

        }

        [Given(@"下班時間為 ""(.*)""")]
        public void Given下班時間為(DateTime endTime)
        {
            target.EndTime = endTime;
        }

        [When(@"呼叫CalculateSalary方法")]
        public void When呼叫CalculateSalary方法()
        {
            var actual = target.CalculateSalary();
            ScenarioContext.Current.Set<double>(actual);
        }

        [Then(@"薪資計算結果應為 (.*)")]
        public void Then薪資計算結果應為(double expected)
        {
            var actual = ScenarioContext.Current.Get<double>();
            Assert.AreEqual(expected, actual);
        }

        [Given(@"加班薪資頭2小時，時薪比例為 (.*)")]
        public void Given加班薪資頭小時時薪比例為(double firstOvertimeRatio)
        {
            target.FirstOverTimeRatio = firstOvertimeRatio;
        }

    }
}