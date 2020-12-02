using medical_common.Models;
using medical_doctor_client.Authentication;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace medical_doctor_client
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AuthenticationRequestBase request = new AuthenticationRequestBase();
            request.Username = UserNameBox.Text;
            request.Password = PasswordBox.Password;
            try
            {
                DoctorAuthenticatorClient authenticatorClient = new DoctorAuthenticatorClient();
                authenticatorClient.Authenticate(request);

                DiagnosisWindow diagnosis = new DiagnosisWindow();
                diagnosis.Show();
                diagnosis.Closing += new CancelEventHandler((object sender2, CancelEventArgs e2) => this.Show());
                this.Hide();
            }
            catch (AggregateException)
            {
                MessageBox.Show("A szerverrel nem sikerült kapcsolatot létesíteni.");
            }
            catch (Exception)
            {
                MessageBox.Show("A bejelentkezés sikertelen.");
            }
        }
    }
}
