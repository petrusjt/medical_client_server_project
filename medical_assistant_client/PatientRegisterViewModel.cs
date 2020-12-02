using medical_assistant_client.DataProviders;
using medical_common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Configuration;
using System.Text.RegularExpressions;
using System.Net.Http;
using medical_assistant_client.Exceptions;

namespace medical_assistant_client
{
	class PatientRegisterViewModel
	{
		static List<string> ErrorList;
		public static void SendPatientToServer(Patient patient)
        {
			ErrorList = new List<string>();
			if(IsPatientDataValid(patient))
			{
				try
				{
					PatientDataProvider.RegisterPatient(patient);
				}
				catch(HttpRequestException e)
				{
					MessageBox.Show("A szerverrel nem sikerült kapcsolatot létesíteni.");
				}
				catch(AggregateException e)
				{
					MessageBox.Show("A szerverrel nem sikerült kapcsolatot létesíteni.");
				}
				catch(PatientAlreadyRegisteredException e)
				{
					MessageBox.Show("A páciens már szerepel a rendszerben a megadott adatokkal.");
				}
			}
			else
			{
				string errorString = "";
				foreach(string error in ErrorList)
				{
					errorString = errorString + error + "\n";
				}
				MessageBox.Show(errorString);
			}
        }

		private static bool IsPatientDataValid(Patient patient)
		{
			bool isPatientDataValid = ValidatePatientData(patient);
			bool isAddressValid = ValidateAddressData(patient.Address);
			return isPatientDataValid && isAddressValid;
		}

		public static bool ValidatePatientData(Patient patient)
		{
			string TAJRegex = @"^[0-9]{3} [0-9]{3} [0-9]{3}$";
			bool isPatientDataValid = true;
			if(!Regex.IsMatch(patient.TAJ, TAJRegex))
			{
				ErrorList.Add("A TAJ formátumának 'XXX XXX XXX' kell lennie.");
				isPatientDataValid = false;
			}
			if(string.IsNullOrWhiteSpace(patient.Problem) || patient.Problem.Length < 10)
			{
				ErrorList.Add("A páciens problémájának leírása nem lehet rövidebb 10 karakternél.");
				isPatientDataValid = false;
			}
			if (string.IsNullOrWhiteSpace(patient.Name) || patient.Name.Length < 9)
			{
				ErrorList.Add("A páciens neve legalább 9 karakterből kell, hogy álljon(szóközzel együtt).");
				isPatientDataValid = false;
			}

			return isPatientDataValid;
		}

		public static bool ValidateAddressData(Address address)
		{
			bool isAddressValid = true;

			if(string.IsNullOrWhiteSpace(address.Country))
			{
				ErrorList.Add("Az országot kötelező megadni.");
				isAddressValid = false;
			}
			if (string.IsNullOrWhiteSpace(address.Region))
			{
				ErrorList.Add("A megyét kötelező megadni.");
				isAddressValid = false;
			}
			if (string.IsNullOrWhiteSpace(address.City))
			{
				ErrorList.Add("A várost kötelező megadni.");
				isAddressValid = false;
			}
			if (string.IsNullOrWhiteSpace(address.StreetName))
			{
				ErrorList.Add("Az utcanevet kötelező megadni.");
				isAddressValid = false;
			}
			if (address.StreetNumber == 0)
			{
				ErrorList.Add("A házszámot kötelező megadni és nem lehet 0.");
				isAddressValid = false;
			}

			return isAddressValid;
		}
	}
}
