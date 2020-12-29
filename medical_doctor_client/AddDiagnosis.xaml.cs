using medical_common.Models;
using medical_doctor_client.DataProviders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace medical_doctor_client
{
    /// <summary>
    /// Interaction logic for AddDiagnosis.xaml
    /// </summary>
    public partial class AddDiagnosis : Window
    {
        private readonly Patient _patient;
        public AddDiagnosis(Patient patient)
        {
            InitializeComponent();
            if (patient != null)
            {
                _patient = patient;
                NameTextBox.Text = _patient.Name;
                TajTextBox.Text = _patient.TAJ;
                RegisteredTextBox.Text = _patient.TimeRegistered.ToString();
                CountryTextBox.Text = _patient.Address.Country;
                RegionTextBox.Text = _patient.Address.Region;
                CityTextBox.Text = _patient.Address.City;
                StreetNameTextBox.Text = _patient.Address.StreetName;
                StreetNumberTextBox.Text = _patient.Address.StreetNumber.ToString();
                StaircaseRefTextBox.Text = _patient.Address.StaircaseRef.ToString();
                FloorTextBox.Text = _patient.Address.Floor.ToString();
                ApartmentNumberTextBox.Text = _patient.Address.ApartmentNumber.ToString();
                ProblemBox.Text = _patient.Problem;
                DiagnosisTextBox.Text = _patient.Diagnosis;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            _patient.Diagnosis = DiagnosisTextBox.Text;
            PatientDataProvider.UpdatePatient(_patient);
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();

        }
    }
}
