using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using WebCase.Models;
using WebCase.Services;

namespace WebCase.Controllers
{
    public class CasesController : ApiController
    {

        private ICaseRepo _caseRepo;

        public CasesController()
        {
            this._caseRepo = new CaseRepoImpl();
        }

        public CasesController(ICaseRepo service)
        {
            this._caseRepo = service;
        }


        // GET api/cases
        public List<Case> Get()
        {
            return _caseRepo.GetAllCases();
        }

        // GET api/values/5
        public Case Get(int id)
        {
            return _caseRepo.GetCases(id);

        }

        // POST api/values
        //[HttpPost]
        //public void Post(Case myCase)
        //{
        //    var result = this.caseRepo.SaveCase(myCase);

        //}



        [HttpPost]
        public async Task<HttpResponseMessage> PostFormData(int id)
        {
            try
            {
                // Check if the request contains multipart/form-data.
                if (!Request.Content.IsMimeMultipartContent())
                {
                    throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
                }

                Case theCase = _caseRepo.GetCases(id);

                if (theCase == null)
                {
                    throw new Exception("No such case");
                }

                //check if folder exist if not create it...
                var pathToAttachments = "~/attachments/";
                string root = HttpContext.Current.Server.MapPath(pathToAttachments);

                bool exists = Directory.Exists(root);
                if (!exists)
                    Directory.CreateDirectory(root);

                var provider = new MultipartFormDataStreamProvider(root);


                // Read the form data. and save it
                await Request.Content.ReadAsMultipartAsync(provider);

                
                foreach (MultipartFileData file in provider.FileData)
                {
                    if (string.IsNullOrEmpty(file.Headers.ContentDisposition.FileName))
                    {
                        return Request.CreateResponse(HttpStatusCode.NotAcceptable, "This request is not properly formatted");
                    }

                    string fileName = file.Headers.ContentDisposition.FileName;
                    if (fileName.StartsWith("\"") && fileName.EndsWith("\""))
                    {
                        fileName = fileName.Trim('"');
                    }
                    if (fileName.Contains(@"/") || fileName.Contains(@"\"))
                    {
                        fileName = Path.GetFileName(fileName);
                    }

                    string extension = Path.GetExtension(fileName);
                    if (extension != ".pdf")
                        throw new Exception("Not supported format");
                    fileName = id + extension;


                    File.Move(file.LocalFileName, Path.Combine(root, fileName));


                    var filePath = ("attachments/" + fileName);
                    // file is uploaded


                    theCase.attachment = filePath;


                    _caseRepo.UpdateContact(theCase);



                    //return Request.CreateResponse(HttpStatusCode.OK);
                }
            }
            catch (System.Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e);
            }
            return Request.CreateResponse(HttpStatusCode.OK);
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
