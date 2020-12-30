using medical_common.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace medical_doctor_client.DataProviders
{
    class PatientDataProvider
    {
        private static string _url = "http://localhost:5000/api/doctor/";
        private static string _allpatientsurl = "getallpatients";
        public static IList<Patient> GetPatients()
        {
            using (var client = new HttpClient())
            {
                var response = client.GetAsync(_url + _allpatientsurl).Result;

                if (response.IsSuccessStatusCode)
                {
                    var rawData = response.Content.ReadAsStringAsync().Result;
                    var patients = JsonConvert.DeserializeObject<IList<Patient>>(rawData);
                    return patients;
                }
                else
                {
                    throw new InvalidOperationException(response.StatusCode.ToString());
                }
            }
        }

        public static void UpdatePatient(Patient patient)
        {
            using (var client = new HttpClient())
            {
                var rawData = JsonConvert.SerializeObject(patient);
                var content = new StringContent(rawData, Encoding.UTF8, "application/json");
                try
                {
                    var response = client.PutAsync(_url, content).Result;
                    if (!response.IsSuccessStatusCode)
                    {
                        throw new InvalidOperationException();
                    }
                }
                catch (AggregateException e)
                {

                }
            }
        }
        public static void DeletePatient(string taj,string problem)
        {
            using (var client = new HttpClient())
            {
                var response = client.DeleteAsync(_url + "?taj=" + taj+"&problem=" + problem).Result;
                if (!response.IsSuccessStatusCode)
                {
                    throw new InvalidOperationException(response.StatusCode.ToString());
                }
            }
        }
    }
}
