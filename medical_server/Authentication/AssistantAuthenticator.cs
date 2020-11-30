using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace medical_server.Authentication
{
    public class AssistantAuthenticator : IAuthenticator
    {
        public ActionResult Authenticate(string username, string password)
        {
            if(username == "Assistant" && password=="Password")
            {
                return new OkResult();
            }
            else 
            {
                return new UnauthorizedResult();
            }
        }
    }
}
