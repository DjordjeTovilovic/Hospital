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
using Controller;

namespace Hospital.View.Director
{

    public partial class StaticAdd : Window
    {
        private readonly StaticEquipmentController staticEquipmentController = new StaticEquipmentController();
        public StaticAdd()
        {
            InitializeComponent();
        }
        private void Prihvati_Click(object sender, RoutedEventArgs e)
        {
            int err = 0;
            nameError.Content = "";
            quaError.Content = "";
            desError.Content = "";
            if (name.Text == "")
            {
                nameError.Content = "Popunite polje!";
                err++;
            }
            if (quantity.Text == "")
            {
                quaError.Content = "Popunite polje!";
                err++;
            }
            if (description.Text == "")
            {
                desError.Content = "Popunite polje!";
                err++;
            }
            if (err == 0)
            {
                staticEquipmentController.Save(name.Text, 0, Int32.Parse(quantity.Text), description.Text);
                MessageBox.Show("Uspesno ste dodali " + name.Text);
                nameError.Content = "";
                quaError.Content = "";
                desError.Content = "";
                name.Text = "";
                quantity.Text = "";
                description.Text = "";
            }

        }
        private void Ponisti_Click(object sender, RoutedEventArgs e)
        {
            Static roomWindow = new Static();
            roomWindow.Show();
            this.Close();
        }
    }
}
