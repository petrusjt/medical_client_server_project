using medical_common.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace medical_doctor_client.Authentication
{
	class DoctorAuthenticatorClient
	{

		const string _url = "http://localhost:5000/api/doctor/authdoctor";
		public void Authenticate(AuthenticationRequestBase request)
		{
			using (var client = new HttpClient())
			{
				var rawData = JsonConvert.SerializeObject(request);
				var content = new StringContent(rawData, Encoding.UTF8, "application/json");
				try
				{
					var response = client.PostAsync(_url, content).Result;
					if (!response.IsSuccessStatusCode)
					{
						if (response.StatusCode == HttpStatusCode.Unauthorized)
						{
							throw new Exception("Login failed");
						}
					}
				}
				catch (AggregateException)
				{
					throw;
				}
			}
		}
	}
}