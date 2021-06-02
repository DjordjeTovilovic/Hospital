using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using Model;
using Controller;

namespace Hospital.View.Director
{

    public partial class Medicines : Window
    {
        private readonly MedicineController medicineController = new MedicineController();
        public Medicines()
        {
            InitializeComponent();
            medicineDataGrid.ItemsSource = medicineController.GetAll();
        }

        private void AddMedicine_Click(object sender, RoutedEventArgs e)
        {
            MedicineAdd medicineAdd = new MedicineAdd();
            medicineAdd.Show();
            this.Close();

        }
        private void Back_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            this.Close();

        }
        private void Sreach_Click(object sender, RoutedEventArgs e)
        { // ukoliko nema nista u searchu izbaci poruku ispod bara 
           // medicineDataGrid.ItemsSource = medicineController.GetByName(searchData.Text);
        }
    }
}
