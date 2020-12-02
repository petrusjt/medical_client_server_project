using medical_assistant_client.Exceptions;
using medical_common.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;

namespace medical_assistant_client.DataProviders
{
	class PatientDataProvider
	{
		private const string _baseURL = "http://localhost:5000/api/assistant/";
		private const string _registerPatientRoute = "addpatient";

		public static void RegisterPatient(Patient patient)
		{
			using(var client = new HttpClient())
			{
				var rawData = JsonConvert.SerializeObject(patient);
				var content = new StringContent(rawData, Encoding.UTF8, "application/json");

				try
				{
					var response = client.PostAsync(_baseURL + _registerPatientRoute, content).Result;
					if (!response.IsSuccessStatusCode)
					{
						if (response.StatusCode == HttpStatusCode.Conflict)
						{
							throw new PatientAlreadyRegisteredException();
						}
						else
						{
							throw new InvalidOperationException();
						}
					}
				}
				catch(AggregateException e)
				{
					throw;
				}
			}
		}

	}
}
