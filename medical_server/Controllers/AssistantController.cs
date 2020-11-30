using medical_common.Models;
using medical_server.Authentication;
using medical_server.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace medical_server.Controllers
{
	[Route("api/assistant")]
	[ApiController]
	public class AssistantController : ControllerBase
	{
		[HttpGet]
		public ActionResult<string> HelloWorld()
		{
			return Ok("Hello World!");
		}
		[Route("getallpatients")]
		[HttpGet]
		public ActionResult<List<Patient>> GetAllPatients()
        {
			return Ok(PatientRepository.LoadPatients());
        }

		[Route("addpatient")]
		[HttpPost]
		public ActionResult AddPatient([FromBody]Patient patient)
        {
			var patients = PatientRepository.LoadPatients();
            if (!patients.Contains(patient))
            {
                patients.Add(patient);
                PatientRepository.WritePatients(patients);
                return Ok();
            }
            else
            {
                return Conflict();
            }
        }

		[Route("auth")]
		[HttpGet]
		public ActionResult<AuthenticationRequestBase> PrintAuthRequest()
        {
			var a = new AuthenticationRequestBase();
			a.Password = "Password";
			a.Username = "Assistant";
			return Ok(a);
        }

		[Route("auth")]
		[HttpPost]
		public ActionResult AuthenticateAssistant([FromBody] AuthenticationRequestBase authenticationRequest)
        {
			AssistantAuthenticator assistantAuthenticator = new AssistantAuthenticator();
			return assistantAuthenticator.Authenticate(authenticationRequest.Username, authenticationRequest.Password);
        }
	}
}
