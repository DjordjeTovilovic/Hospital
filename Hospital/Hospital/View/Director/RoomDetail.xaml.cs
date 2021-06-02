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
    /// <summary>
    /// Interaction logic for RoomDetail.xaml
    /// </summary>
    public partial class RoomDetail : Window
    {
        private readonly RoomController roomController = new RoomController();
        string pomocnoIme;

        public RoomDetail(string name, int floor, string description)
        {
            InitializeComponent();
            ime.Content = name;
            sprat.Content = floor;
            opis.Content = description;
            pomocnoIme = name;

        }


        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            
            Room room = roomController.GetByName(pomocnoIme);
            roomController.Delete(room.Id);
            MessageBox.Show("Uspesno ste obrisali sobu " + pomocnoIme);
            pomocnoIme = "";
            Back_Click(sender, e);
        }
        private void Back_Click(object sender, RoutedEventArgs e)
        {
            Rooms rooms = new Rooms();
            rooms.Show();
            this.Close();
        }
    }
}
