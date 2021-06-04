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

namespace Hospital.View.Director
{
    /// <summary>
    /// Interaction logic for DynamicAdd.xaml
    /// </summary>
    public partial class DynamicAdd : Window
    {
        Controller.DynamicEquipmentController dynamicEquipmentController = new Controller.DynamicEquipmentController();
        public DynamicAdd()
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
            if(quantity.Text == "")
            {
                quaError.Content = "Popunite polje!";
                err++;
            }
            if(description.Text == "")
            {
                desError.Content = "Popunite polje!";
                err++;
            }
            if(err == 0)
            {
                Model.DynamicEquipment dynamicEquipment = new Model.DynamicEquipment(dynamicEquipmentController.GenerateNewId(), name.Text, Int32.Parse(quantity.Text), description.Text);
                dynamicEquipmentController.Save(dynamicEquipment);
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
