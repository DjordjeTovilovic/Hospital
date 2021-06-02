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

    public partial class Rooms : Window
    {
        private readonly RoomController roomController = new RoomController();

        
        public Rooms()
        {
            InitializeComponent();
            roomsDataGrid.ItemsSource = roomController.GetAll();
        }

        private void AddRoom_Click(object sender, RoutedEventArgs e)
        {
            RoomAdd roomAdd = new RoomAdd();
            roomAdd.Show();
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
            //roomsDataGrid.ItemsSource = roomController.GetByName(searchData.Text);   
        }
        private void Detail_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Model.Room room = (Room)roomsDataGrid.SelectedItem;
                RoomDetail roomDetail = new RoomDetail(room.Name, room.Floor, room.Detail);
                roomDetail.Show();
                Close();
            }
            catch
            {
                MessageBox.Show("Morate odabrati sobu da bi ste prikazali detalje");
            }
        }
    }
}
