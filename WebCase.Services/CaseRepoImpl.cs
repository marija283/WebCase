using CaseDatabase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using WebCase.Models;
using System.Collections;


namespace WebCase.Services
{
    public class CaseRepoImpl : ICaseRepo
    {
        public List<Case>  GetAllCases()
        {
            using (var context = new CaseContext())
            {

                List<Case> cases = context.Cases.ToList();
               
                return cases;
            }

        }

        public Case GetCaseById(int id)
        {
            using (var context = new CaseContext())
            {
                var cases = context.Cases.Find(id);
                if (cases == null)
                {
                    throw new KeyNotFoundException();
                }
                return cases;
            }

        }

        public HttpStatusCode SaveCase(Case cases)
        {

            using (var context = new CaseContext())
            {
                try
                {
                    context.Cases.Add(cases);
                    context.SaveChanges();
                    return HttpStatusCode.Created;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return HttpStatusCode.BadRequest;

                }
            }
        }

        public HttpStatusCode UpdateContact(Case cases)
        {
            using (var context = new CaseContext())
            {
                try
                {
                    var original = context.Cases.Find(cases.ID);
                    original.attachment = cases.attachment;
                    context.SaveChanges();
                    return System.Net.HttpStatusCode.OK;

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return System.Net.HttpStatusCode.NotFound;
                }
            }
        }

        public HttpStatusCode DeleteCase(int id)
        {
            using (var context = new CaseContext())
            {
                try
                {
                    var cases = context.Cases.Find(id);
                    context.Cases.Remove(cases);
                    context.SaveChanges();
                    return HttpStatusCode.OK;
                }
                catch (Exception ex)
                {
                    return HttpStatusCode.NotFound;
                }
            }
        }
    }
}

