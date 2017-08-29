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
    public interface ICaseRepo
    {
        Case GetCaseById(int id);

        List<Case>  GetAllCases();
        HttpStatusCode SaveCase(Case myCase);

        HttpStatusCode UpdateCase(Case myCase);

        HttpStatusCode DeleteCase(int id);
    }
}

