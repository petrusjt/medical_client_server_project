using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace medical_assistant_client.Exceptions
{
	class PatientAlreadyRegisteredException : Exception
	{
		public PatientAlreadyRegisteredException()
		{

		}

		public PatientAlreadyRegisteredException(string message) : base(message)
		{

		}

		public PatientAlreadyRegisteredException(string message, Exception inner) : base(message, inner)
		{

		}
	}
}
