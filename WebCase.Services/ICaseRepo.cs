using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using WebCase.Models;

namespace WebCase.Services
{
    public interface ICaseRepo
    {
        Case GetCases(int id);

        HttpStatusCode SaveContact(Case contact);

        //HttpStatusCode UpdateContact(Case contact);

        HttpStatusCode DeleteContact(int id);
    }
}

