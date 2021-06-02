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
using Model;
using Controller;

namespace Hospital.View.Director
{

    public partial class MedicineAdd : Window
    {
        private readonly MedicineController medicineController = new MedicineController();
        public MedicineAdd()
        {
            InitializeComponent();
        }

        private void Prihvati_Click(object sender, RoutedEventArgs e)
        {
            medicineController.Save(name.Text, description.Text);
            MessageBox.Show("Uspesno ste dodali " + name.Text);
            name.Text = "";
            description.Text = "";
            floor.Text = "";
            type.Text = "";

        }
        private void Ponisti_Click(object sender, RoutedEventArgs e)
        {
            Medicines medicines = new Medicines();
            medicines.Show();
            this.Close();
        }
    }
}
