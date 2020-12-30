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
    /// Interaction logic for DiagnosisWindow.xaml
    /// </summary>
    public partial class DiagnosisWindow : Window
    {
        private IList<Patient> _patients;
        public DiagnosisWindow()
        {
            InitializeComponent();
            UpdateTable();
        }

        private void UpdateTable()
        {
            _patients = PatientDataProvider.GetPatients();
            PatientsDataGrid.ItemsSource = _patients;
            
        }

        private void PatientsDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedPatient = PatientsDataGrid.SelectedItem as Patient;

            if (selectedPatient != null)
            {
                var window = new AddDiagnosis(selectedPatient);
                if (window.ShowDialog() ?? true)
                {
                    UpdateTable();
                }
                PatientsDataGrid.UnselectAll();
            }
        }
    }
}
