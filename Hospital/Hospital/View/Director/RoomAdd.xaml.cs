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
    /// Interaction logic for RoomAdd.xaml
    /// </summary>
    public partial class RoomAdd : Window
    {
        private readonly RoomController roomController = new RoomController();

        public RoomAdd()
        {
            InitializeComponent();
        }

        private void Prihvati_Click(object sender, RoutedEventArgs e)
        {
            roomController.Save(name.Text, 0, Int32.Parse(floor.Text), description.Text);
            MessageBox.Show("Uspesno ste dodali " + name.Text);
            name.Text = "";
            floor.Text = "";
            description.Text = "";

        }
        private void Ponisti_Click(object sender, RoutedEventArgs e)
        {
            Rooms roomWindow = new Rooms();
            roomWindow.Show();
            this.Close();
        }
        
    }
}
