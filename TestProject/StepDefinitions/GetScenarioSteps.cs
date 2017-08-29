using CaseDatabase;
using NUnit.Framework;
using System;
using TechTalk.SpecFlow;
using WebCase.Controllers;
using WebCase.Models;
using WebCase.Services;

namespace TestProject.StepDefinitions
{
    [Binding]
    public class GetScenarioSteps
    {

        private ICaseRepo caseRepo;

        private CaseContext _caseContext;

        private Case myCase;

        [Given(@"Stated the test")]
        public void GivenStatedTheTest()
        {
            //ScenarioContext.Current.Pending();
        }
        
        [Then(@"I create case with caseName ""(.*)"" and kind ""(.*)""")]
        public void ThenICreateCaseWithCaseNameAndKind(string p0, string p1)
        {
            caseRepo = new CaseRepoImpl();

            myCase = new Case
            {
                caseNumber = p0,
                kind = p1
            };
            caseRepo.SaveCase(myCase);
            
        }
        
        [Then(@"Get created user with")]
        public void ThenGetCreatedUserWith()
        {
            CasesController controller = new CasesController();
            var case2 = controller.Get(myCase.ID);
            Assert.AreEqual(case2.ID, myCase.ID, "id not match.");

        }

        //    [Then(@"Modify contact")]
        //    public void ThenModifyContact()
        //    {

        //    }

        //    [Then(@"Get modified contact")]
        //    public void ThenGetModifiedContact()
        //    {

        //    }
        //
    }
}
