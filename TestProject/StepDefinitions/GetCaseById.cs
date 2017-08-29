using System;
using TechTalk.SpecFlow;
using WebCase.Controllers;
using WebCase.Models;
using WebCase.Services;
using NUnit.Framework;

namespace TestProject.StepDefinitions
{
   
    [Binding]
    public class GetCaseById

    {
        private ICaseRepo caseRepo;

        private Case myCase;

        [Given(@"Started the test")]
        public void GivenStartedTheTest()
        {
         //   ScenarioContext.Current.Pending();
        }

        [Then(@"Get case by (.*)")]
        public void ThenGetCaseBy(int caseId)
        {
            //   ScenarioContext.Current.Pending();
            caseRepo = new CaseRepoImpl();
            myCase = caseRepo.GetCaseById(caseId);
            CasesController controller = new CasesController();
            var case2 = controller.Get(myCase.ID);
            Assert.AreEqual(case2.ID, myCase.ID, "id not match.");
        }
    }
}
