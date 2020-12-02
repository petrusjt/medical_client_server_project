using medical_assistant_client.Authentication;
using medical_common.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using System.Xaml;

namespace medical_assistant_client
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AuthenticationRequestBase request = new AuthenticationRequestBase();
            request.Username = UsernameTextBox.Text;
            request.Password = PasswordPasswordBox.Password;
			try
			{
                AssistantAuthenticatorClient authenticatorClient = new AssistantAuthenticatorClient();
                authenticatorClient.Authenticate(request);

                PatientRegistrationWindow patientRegistration = new PatientRegistrationWindow();
                patientRegistration.Show();
                patientRegistration.Closing += new CancelEventHandler((object sender2, CancelEventArgs e2) => this.Show());
                this.Hide();
            }
            catch(AggregateException)
			{
                MessageBox.Show("A szerverrel nem sikerült kapcsolatot létesíteni.");
			}
            catch(Exception)
			{
                MessageBox.Show("A bejelentkezés sikertelen.");
			}
            
        }
    }
}
