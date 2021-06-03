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
    /// Interaction logic for Dynamic.xaml
    /// </summary>
    public partial class Dynamic : Window
    {
        private readonly Controller.DynamicEquipmentController equipmentController = new Controller.DynamicEquipmentController();
        public Dynamic()
        {
            InitializeComponent();
            dynamicDataGrid.ItemsSource = equipmentController.GetAll();
        }
        private void AddDynamic_Click(object sender, RoutedEventArgs e)
        {
            DynamicAdd roomAdd = new DynamicAdd();
            roomAdd.Show();
            this.Close();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            this.Close();
        }

        private void Transfer_Click(object sender, RoutedEventArgs e)
        {
            DynamicTransfer main = new DynamicTransfer();
            main.Show();
            this.Close();
        }

        private void Sreach_Click(object sender, RoutedEventArgs e)
        { // ukoliko nema nista u searchu izbaci poruku ispod bara 
            //roomsDataGrid.ItemsSource = roomController.GetByName(searchData.Text);   
        }
        private void Detail_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Model.DynamicEquipment equipment = (Model.DynamicEquipment)dynamicDataGrid.SelectedItem;
                DynamicDetail dynamicDetail = new DynamicDetail(equipment.Name, equipment.Quantity, equipment.Description);
                dynamicDetail.Show();
                Close();
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Morate odabrati sobu da bi ste prikazali detalje");
            }
        }
    }
}
