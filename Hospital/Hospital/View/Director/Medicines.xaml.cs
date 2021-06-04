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
        {
            if (searchData.Text == "" || searchData.Text == " ")
            {
                searcError.Content = "Molim Vas ukucajte tekst pre pretrage";
            }
            else
            {
                medicineDataGrid.ItemsSource = medicineController.GetName(searchData.Text);
            }
        }

        private void Detail_Click(object sender, RoutedEventArgs e)
        {

            if ((Medicine)medicineDataGrid.SelectedItem == null)
            {
                detailError.Content = "Morate odabrati lek da bi ste prikazali detalje";
            }
            else
            {

                Medicine equipment = (Medicine)medicineDataGrid.SelectedItem;
                MedicineDetail staticDetail = new MedicineDetail(equipment.Name, equipment.Description);
                staticDetail.Show();
                Close();
            }
        }
    }
}
