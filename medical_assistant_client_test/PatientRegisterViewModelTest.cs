using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework.Internal;
using medical_assistant_client;
using medical_common.Models;

namespace medical_assistant_client_test
{
    [TestClass]
    public class PatientRegisterViewModelTest
    {
        [TestMethod]
        public void ValidatePatientData_WithValidPatientData()
        {
            //Arrange
            Patient patient0 = new Patient("Kiss B�la", null, "000 000 000", "Naponta k�tszer el�jul.");
            Patient patient1 = new Patient("Nagy Imre", null, "123 456 789", "H�rom hete folyamatosan f�j a feje.");
            Patient patient2 = new Patient("Lap�tos Ferenc", null, "111 111 111", "Kar�t nyelt.");
            Patient patient3 = new Patient("Nyilas J�zsef", null, "346 843 123", "Sz�d�l, h�nyingere van.");
            Patient patient4 = new Patient("Asztalos Istv�n", null, "435 234 214", "R�kos. Kontrollvizsg�latra j�tt.");
            Patient patient5 = new Patient("B�n B�la", null, "435 234 214", "R�kos. Kontrollvizsg�latra j�tt.");

            //Act + Assert
            Assert.IsTrue(PatientRegisterViewModel.ValidatePatientData(patient0));
            Assert.IsTrue(PatientRegisterViewModel.ValidatePatientData(patient1));
            Assert.IsTrue(PatientRegisterViewModel.ValidatePatientData(patient2));
            Assert.IsTrue(PatientRegisterViewModel.ValidatePatientData(patient3));
            Assert.IsTrue(PatientRegisterViewModel.ValidatePatientData(patient4));
            Assert.IsTrue(PatientRegisterViewModel.ValidatePatientData(patient5));
        }

        [TestMethod]
        public void ValidatePatientData_WithInvalidPatientData()
        {
            //Arrange
            Patient patient0 = new Patient(null, null, null, null);
            Patient patient1 = new Patient("Hu Lu", null, "111 111 111", "Kar�t nyelt.");
            Patient patient2 = new Patient("Hu Lu", null, "111 111 111", "Kar�t nyelt.");
            Patient patient3 = new Patient("Kun B�la", null, "111111 111", "Kar�t nyelt.");
            Patient patient4 = new Patient("Kun B�la", null, "111 111111 ", "Kar�t nyelt.");
            Patient patient5 = new Patient("Kun B�la", null, "111 111 111", "B�na");

            //Act + Assert
            Assert.IsFalse(PatientRegisterViewModel.ValidatePatientData(null));
            Assert.IsFalse(PatientRegisterViewModel.ValidatePatientData(patient0));
            Assert.IsFalse(PatientRegisterViewModel.ValidatePatientData(patient1));
            Assert.IsFalse(PatientRegisterViewModel.ValidatePatientData(patient2));
            Assert.IsFalse(PatientRegisterViewModel.ValidatePatientData(patient3));
            Assert.IsFalse(PatientRegisterViewModel.ValidatePatientData(patient4));
            Assert.IsFalse(PatientRegisterViewModel.ValidatePatientData(patient5));
        }

        [DataTestMethod]
        [DataRow("Magyarorsz�g", "Hajd�-Bihar", "Derecske", "R�vid", 5)]
        [DataRow("Magyarorsz�g", "Pest", "Budapest", "V�ci", 5)]
        [DataRow("Magyarorsz�g", "Borsod-Aba�j-Zempl�n", "Miskolc", "R�vid", 5)]
        [DataRow("Magyarorsz�g", "Hajd�-Bihar", "Derecske", "Kall�", 5)]
        [DataRow("Magyarorsz�g", "Hajd�-Bihar", "Hajd�b�sz�rm�ny", "Sz�kely", 5)]
        public void ValidateAddressData_WithValidAddressData(string country, string region, string city, string streetName, int streetNumber)
        {
            //Arrange
            Address address = new Address(country, region, city, streetName, streetNumber);

            //Act + Assert
            Assert.IsTrue(PatientRegisterViewModel.ValidateAddressData(address));
        }

        [DataTestMethod]
        [DataRow(null, null, null, null, null)]
        [DataRow(null, null, null, null, 0)]
        public void ValidateAddressData_WithInvalidAddressData(string country, string region, string city, string streetName, int streetNumber)
        {
            //Arrange
            Address address = new Address(country, region, city, streetName, streetNumber);

            //Act + Assert
            Assert.IsFalse(PatientRegisterViewModel.ValidateAddressData(address));
        }

        [TestMethod]
        public void ValidateAddressData_WithNull()
        {
            //Arrange

            //Act + Assert
            Assert.IsFalse(PatientRegisterViewModel.ValidateAddressData(null));
        }
    }
}
