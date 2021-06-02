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
    /// <summary>
    /// Interaction logic for StaticAdd.xaml
    /// </summary>
    public partial class StaticAdd : Window
    {
        private readonly StaticEquipmentController staticEquipmentController = new StaticEquipmentController();
        public StaticAdd()
        {
            InitializeComponent();
        }
        private void Prihvati_Click(object sender, RoutedEventArgs e)
        {
            staticEquipmentController.Save(name.Text, 0, Int32.Parse(quantity.Text), description.Text);
            MessageBox.Show("Uspesno ste dodali " + name.Text);
            name.Text = "";
            quantity.Text = "";
            description.Text = "";

        }
        private void Ponisti_Click(object sender, RoutedEventArgs e)
        {
            Static roomWindow = new Static();
            roomWindow.Show();
            this.Close();
        }
    }
}
