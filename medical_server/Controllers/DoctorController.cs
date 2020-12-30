using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using medical_common.Models;
using medical_server.Authentication;
using medical_server.Repositories;
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


        [HttpPut]
        public ActionResult UpdatePatient(Patient patient)
        {
            var patients = PatientRepository.LoadPatients();
            var oldPatient = patients.FirstOrDefault(x => x.Equals(patient));
            if (oldPatient != null)
            {
                oldPatient.Diagnosis = patient.Diagnosis;
            }
            else
            {
                patients.Add(patient);
            }
            PatientRepository.WritePatients(patients);
            return Ok();
        }

        [HttpDelete]
        public ActionResult DeletePatient(string taj,string problem)
        {
            var patients = PatientRepository.LoadPatients();
            var patient = patients.FirstOrDefault(x => x.TAJ==taj && x.Problem==problem);
            if (patient != null)
            {
                patients.Remove(patient);
                PatientRepository.WritePatients(patients);
                return Ok();
            }
            return NotFound(taj + " " + problem);
        }

        [Route("getallpatients")]
        [HttpGet]
        public ActionResult<List<Patient>> GetAllPatients()
        {
            return Ok(PatientRepository.LoadPatients());
        }

    }
}
