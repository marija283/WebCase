using System;
using TechTalk.SpecFlow;

namespace TestProject.StepDefinitions
{
    [Binding]
    public class GetCaseById
    {
        [Given(@"Started the test")]
        public void GivenStartedTheTest()
        {
         //   ScenarioContext.Current.Pending();
        }
        
        [Then(@"Get case (.*)")]
        public void ThenGetCase(string p0)
        {
        //    ScenarioContext.Current.Pending();
        }
    }
}
