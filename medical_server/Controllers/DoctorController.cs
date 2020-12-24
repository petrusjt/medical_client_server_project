using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using medical_common.Models;
using medical_server.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace medical_server.Controllers
{
    [Route("api/doctor")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        [HttpGet]
        public ActionResult<string> HelloWorld()
        {
            return Ok("Hello World!");
        }

        
        [Route("authdoctor")]
        [HttpPost]
        public ActionResult AuthenticateDoctor([FromBody] AuthenticationRequestBase authenticationRequest)
        {
            DoctorAuthenticator doctorAuthenticator = new DoctorAuthenticator();
            return doctorAuthenticator.Authenticate(authenticationRequest.Username, authenticationRequest.Password);
        }

    }
}
