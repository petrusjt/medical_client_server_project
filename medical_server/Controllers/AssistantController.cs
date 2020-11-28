using medical_common.Models;
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
			if(patients.Contains(patient))
            {
				return Conflict();
            }
			else
            {
				patients.Add(patient);
				PatientRepository.WritePatients(patients);
				return Ok();
			}
        }
	}
}
