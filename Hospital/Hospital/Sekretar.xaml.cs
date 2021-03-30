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
    /// Interaction logic for Sekretar.xaml
    /// </summary>
    public partial class Sekretar : Window
    {
        public Sekretar()
        {
            InitializeComponent();
        }

        private void submit(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Pacijent je uspesno dodat");
        }

        private void cancel(object sender, RoutedEventArgs e)
        {
            Id.Text = "";
            FirstName.Text = "";
            LastName.Text = "";
            Password.Text = "";
            Username.Text = "";
            MessageBox.Show("Pacijent nije dodat");
        }
    }
}
