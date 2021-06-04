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
            int err = 0;
            nameError.Content = "";
            quaError.Content = "";
            desError.Content = "";
            if (name.Text == "")
            {
                nameError.Content = "Popunite polje!";
                err++;
            }
            if (floor.Text == "")
            {
                quaError.Content = "Popunite polje!";
                err++;
            }
            if (description.Text == "")
            {
                desError.Content = "Popunite polje!";
                err++;
            }
            if (err == 0)
            {
                roomController.Save(name.Text, 0, Int32.Parse(floor.Text), description.Text);
                MessageBox.Show("Uspesno ste dodali " + name.Text);
                nameError.Content = "";
                quaError.Content = "";
                desError.Content = "";
                name.Text = "";
                floor.Text = "";
                description.Text = "";
            }
        }
        private void Ponisti_Click(object sender, RoutedEventArgs e)
        {
            Rooms roomWindow = new Rooms();
            roomWindow.Show();
            this.Close();
        }
        
    }
}
