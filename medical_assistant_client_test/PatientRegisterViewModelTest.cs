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
            Patient patient0 = new Patient("Kiss Béla", null, "000 000 000", "Naponta kétszer elájul.");
            Patient patient1 = new Patient("Nagy Imre", null, "123 456 789", "Három hete folyamatosan fáj a feje.");
            Patient patient2 = new Patient("Lapátos Ferenc", null, "111 111 111", "Karót nyelt.");
            Patient patient3 = new Patient("Nyilas József", null, "346 843 123", "Szédül, hányingere van.");
            Patient patient4 = new Patient("Asztalos István", null, "435 234 214", "Rákos. Kontrollvizsgálatra jött.");
            Patient patient5 = new Patient("Bán Béla", null, "435 234 214", "Rákos. Kontrollvizsgálatra jött.");

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
            Patient patient1 = new Patient("Hu Lu", null, "111 111 111", "Karót nyelt.");
            Patient patient2 = new Patient("Hu Lu", null, "111 111 111", "Karót nyelt.");
            Patient patient3 = new Patient("Kun Béla", null, "111111 111", "Karót nyelt.");
            Patient patient4 = new Patient("Kun Béla", null, "111 111111 ", "Karót nyelt.");
            Patient patient5 = new Patient("Kun Béla", null, "111 111 111", "Béna");

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
        [DataRow("Magyarország", "Hajdú-Bihar", "Derecske", "Rövid", 5)]
        [DataRow("Magyarország", "Pest", "Budapest", "Váci", 5)]
        [DataRow("Magyarország", "Borsod-Abaúj-Zemplén", "Miskolc", "Rövid", 5)]
        [DataRow("Magyarország", "Hajdú-Bihar", "Derecske", "Kalló", 5)]
        [DataRow("Magyarország", "Hajdú-Bihar", "Hajdúböszörmény", "Székely", 5)]
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
