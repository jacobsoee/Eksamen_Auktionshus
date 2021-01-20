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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Auktionshus_WPF.Model;

namespace Auktionshus_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            AccountCreateWindow ACW = new AccountCreateWindow();
            ACW.Show();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            Account account = Controller.FindAccount(Username.Text, Password.Password);
            if (account != null)
            {
                Application.Current.Properties["IsLoggedIn"] = true;
                Application.Current.Properties["Account"] = account;
                Username.Clear();
                Password.Clear();
                AuctionWindow AW = new AuctionWindow();
                this.Close();
                AW.Show();
            }
            else
            {
                MessageBox.Show("Wrong account");
                Username.Clear();
                Password.Clear();
            }
        }
    }
}
