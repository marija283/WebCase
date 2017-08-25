using System;
using TechTalk.SpecFlow;
using WebCase.Services;
using WebCase.Models;
using System.Collections.Generic;

namespace TestProject
{
    [Binding]

    public class SpecFlowFeature1Steps
    {
        private ICaseRepo caseRepo;

        [When(@"I make a request, I want to get a list of all cases")]
        public void WhenIMakeARequestIWantToGetAListOfAllCases()
        {
            //this.caseRepo = new CaseRepoImpl();
            //List<Case> result =  caseRepo.GetAllCases();
        }
    }
}
