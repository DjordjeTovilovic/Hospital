using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Hospital
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {

            if (userName.Text == "cveta@gmail.com" && password.Password == "cveta123")
            {
                MainWindow mainWindow = new MainWindow();
                this.Close();
                mainWindow.Show();
            }
            else if (userName.Text != "elena@gmail.com")
            {
                MessageBox.Show("The username you entered is incorrect, try again!");
            }
            else if (password.Password != "elena123")
            {
                MessageBox.Show("The password you entered is incorrect, try again!");
            }
            else
            {
                MessageBox.Show("Both username and password you entered are incorrect, try again!");
            }
        }
    }
}
