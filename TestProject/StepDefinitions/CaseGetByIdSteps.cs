using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechTalk.SpecFlow;
using CaseDatabase;
using WebCase.Services;
using WebCase.Models;
using WebCase.Controllers;
using System.Web.Mvc;

namespace TestProject
{
    [Binding]
    public class CaseGetByIdSteps
    {
        private ICaseRepo caseRepo;

        private CaseContext _caseContext;

        private Case myCase;

        [Given(@"the following cases")]
        public void GivenTheFollowingCases(Table table)
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"I search for cases by the '(.*)'")]
        public void WhenISearchForCasesByThe(int caseId)
        {
            // ScenarioContext.Current.Pending();
            // var book = _caseContext.GetById(p0));
            // var controller = new CatalogController();
            // actionResult = controller.Details(book.Id);

            caseRepo = new CaseRepoImpl();
            var book2 = caseRepo.GetCaseById(caseId);
            CasesController controller = new CasesController();
            Case myCase = controller.Get(caseId);

        }

        [Then(@"the list of found books should be:")]
        public void ThenTheListOfFoundBooksShouldBe(Table table)
        {
            //ScenarioContext.Current.Pending();
            var caseDetails = myCase;

            var row = table.Rows.Single();
            Assert.AreEqual(row["caseNumber"], caseDetails.caseNumber, "caseNumber.");
            Assert.AreEqual(row["kind"], caseDetails.kind, "kind.");
            Assert.AreEqual(Convert.ToDecimal(row["customerNumber"]), caseDetails.customerNumber, "customerNumber.");
        }
    }
}
