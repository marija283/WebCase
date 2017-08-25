using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebCase.Models;
using WebCase.Services;

namespace WebCase.Controllers
{
    public class CasesController : ApiController
    {

        private ICaseRepo caseRepo;

        public CasesController()
        {
            this.caseRepo = new CaseRepoImpl();
        }

        public CasesController(ICaseRepo service)
        {
            this.caseRepo = service;
        }


        // GET api/cases
        public List<Case> Get()
        {
            return caseRepo.GetAllCases();
        }

        // GET api/values/5
        public Case Get(int id)
        {
            return caseRepo.GetCases(id);
            
        }

        // POST api/values
        [HttpPost]

        public void Post(Case myCase)
        {
            var result = this.caseRepo.SaveCase(myCase);
         
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
