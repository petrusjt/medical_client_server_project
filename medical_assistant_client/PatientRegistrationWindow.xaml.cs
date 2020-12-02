using medical_common.Models;
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

namespace medical_assistant_client
{
	/// <summary>
	/// Interaction logic for PatientRegistrationWindow.xaml
	/// </summary>
	public partial class PatientRegistrationWindow : Window
	{
		public PatientRegistrationWindow()
		{
			InitializeComponent();
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			string country = CountryTextBox.Text;
			string region = RegionTextBox.Text;
			string city = CityTextBox.Text;
			string streetName = StreetTextBox.Text;
			if(!int.TryParse(StreetNumberTextBox.Text, out int streetNumber))
			{
				streetNumber = 0;
			}

			Address address = new Address(country, region, city, streetName, streetNumber);
			if(!string.IsNullOrWhiteSpace(StaircaseRefTextBox.Text))
			{
				address.StaircaseRef = StaircaseRefTextBox.Text[0];
			}
			if(!string.IsNullOrWhiteSpace(FloorTextBox.Text))
			{
				int.TryParse(FloorTextBox.Text, out int floor);
				address.Floor = floor;
			}
			if(!string.IsNullOrWhiteSpace(ApartmentNumberTextBox.Text))
			{
				int.TryParse(ApartmentNumberTextBox.Text, out int apartmentNumber);
				address.ApartmentNumber = apartmentNumber;
			}

			string name = NameTextBox.Text;
			string TAJ = TAJTextBox.Text;
			string problem = ProblemTextBox.Text;

			Patient patient = new Patient(name, address, TAJ, problem);

			PatientRegisterViewModel.SendPatientToServer(patient);

		}

		private void Button_Click_1(object sender, RoutedEventArgs e)
		{

		}
	}
}
