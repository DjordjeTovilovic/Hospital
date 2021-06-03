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
    /// Interaction logic for StaticDetail.xaml
    /// </summary>
    public partial class StaticDetail : Window
    {
        private string pomocnoIme;
        private readonly StaticEquipmentController staticEquipmentController = new StaticEquipmentController();
        public StaticDetail(string name, int quantity, string description)
        {
            InitializeComponent();
            ime.Content = name;
            kolicina.Content = quantity;
            opis.Content = description;
            pomocnoIme = name;

        }


        private void Delete_Click(object sender, RoutedEventArgs e)
        {

            Model.StaticEquipment staticEquipment = staticEquipmentController.GetName(pomocnoIme);
            staticEquipmentController.Delete(staticEquipment.Id);
            MessageBox.Show("Uspesno ste obrisali sobu " + pomocnoIme);
            pomocnoIme = "";
            Back_Click(sender, e);
        }
        private void Back_Click(object sender, RoutedEventArgs e)
        {
            Static stat = new Static();
            stat.Show();
            this.Close();
        }
    }
}
