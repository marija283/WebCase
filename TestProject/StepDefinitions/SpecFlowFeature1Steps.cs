using System;
using System.Threading.Tasks;
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
            caseRepo = new CaseRepoImpl();

            List<Case> result = caseRepo.GetAllCases();

            // List<Case> result = new List<Case>();

            result.ForEach(i => Console.WriteLine("{0}\t", i.ToString()));
          
        }
    }
}
