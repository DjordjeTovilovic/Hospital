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
        Model.Room room;

        public RoomDetail(string name, int floor, string description)
        {
            InitializeComponent();
            ime.Content = name;
            sprat.Content = floor;
            opis.Content = description;
            room = roomController.GetByName(name);

        }

        //ikonicu za krecenje + picker da se pojavljuje i nestaje 

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            
            roomController.Delete(room.Id);
            MessageBox.Show("Uspesno ste obrisali sobu " + room.Name);
            Back_Click(sender, e);
        }
        private void Back_Click(object sender, RoutedEventArgs e)
        {
            Rooms rooms = new Rooms();
            rooms.Show();
            this.Close();
        }
        //placeholder za posle
        private void ShowKrecenje_Click(object sender, RoutedEventArgs e)
        {
            deleteButton.Visibility = Visibility.Collapsed;
            date.Visibility = Visibility.Visible;
            startTime.Visibility = Visibility.Visible;
            duration.Visibility = Visibility.Visible;
            dateLabel.Visibility = Visibility.Visible;
            startLabel.Visibility = Visibility.Visible;
            durationLabel.Visibility = Visibility.Visible;
            prihvatiButton.Visibility = Visibility.Visible;
            odustaniButton.Visibility = Visibility.Visible;


        }
        private void Ponisti_Click(object sender, RoutedEventArgs e)
        {
            deleteButton.Visibility = Visibility.Visible;
            date.Visibility = Visibility.Collapsed;
            startTime.Visibility = Visibility.Collapsed;
            duration.Visibility = Visibility.Collapsed;
            dateLabel.Visibility = Visibility.Collapsed;
            startLabel.Visibility = Visibility.Collapsed;
            durationLabel.Visibility = Visibility.Collapsed;
            prihvatiButton.Visibility = Visibility.Collapsed;
            odustaniButton.Visibility = Visibility.Collapsed;

        }

        private void AcceptRenovation_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DateTime renovationDate = SelectedDate();
                bool goodDate = roomController.Renovation(room.Id, renovationDate, Double.Parse(duration.Text));

                if (!goodDate)
                {
                    MessageBox.Show("Ponovo zauzmite datum");
                }
                else
                {
                    MessageBox.Show("Uspesno ste zakazali renoviranje");
                    Ponisti_Click(sender, e);
                }
            }
            catch
            {
                MessageBox.Show("Niste zauzeli datum");
            }

        }
        private DateTime SelectedDate()
        {
            DateTime pickedDate = date.SelectedDate.Value;
            int hours = Int32.Parse(startTime.Text.Split(':')[0]);
            int minutes = Int32.Parse(startTime.Text.Split(':')[1]);
            DateTime renovationDateTime = new DateTime(pickedDate.Year, pickedDate.Month, pickedDate.Day, hours, minutes, 00);
            return renovationDateTime;
        }
    }
}
