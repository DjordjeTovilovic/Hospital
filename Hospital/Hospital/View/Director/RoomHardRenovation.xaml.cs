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
    /// Interaction logic for RoomHardRenovation.xaml
    /// </summary>
    public partial class RoomHardRenovation : Window
    {
        private readonly Controller.RoomController roomController = new Controller.RoomController();
        private readonly Controller.RenovationController renovationController = new Controller.RenovationController();
        private List<Model.Room> rooms;
        public RoomHardRenovation()
        {
            InitializeComponent();
            rooms = roomController.GetAll();
            foreach (Model.Room room in rooms)
            {
                roomA.Items.Add(room.Name);
                roomB.Items.Add(room.Name);
                dettachRoom.Items.Add(room.Name);
            }
        }
        private void AcceptRenovation_Click(object sender, RoutedEventArgs e)
        {
            if(roomA.Text == roomB.Text)
            {
                MessageBox.Show("Ne mozete da odaberet iste sobe za spajanje"); //kao validaciju napraviti 

            }
            else
            {
                try
                {
                    if ((bool)attach.IsChecked)
                    {
                        Attach(roomA.Text, roomB.Text);
                    }
                    else
                    {
                        Dettach(dettachRoom.Text);
                    }
                }
                catch
                {
                    MessageBox.Show("Molim Vas da popunite sva polja");
                }
            }

        }

        private void Attach(string roomAName, string roomBName)
        {
            Model.Room roomA = roomController.GetByName(roomAName);
            Model.Room roomB = roomController.GetByName(roomBName);

            DateTime renovationDateTime = SelectedDate();

            bool goodDate = renovationController.AttachRooms(roomA.Id, roomB.Id, renovationDateTime, Double.Parse(duration.Text));
            Greska(goodDate);

        }

        private void Dettach(string roomName)
        {
            Model.Room room = roomController.GetByName(roomName);
            DateTime renovationDateTime = SelectedDate();

            bool goodDate = renovationController.DettachRooms(room.Id, renovationDateTime, Double.Parse(duration.Text));
            Greska(goodDate);
        }
        private DateTime SelectedDate()
        {
            DateTime pickedDate = date.SelectedDate.Value;
            int hours = Int32.Parse(startTime.Text.Split(':')[0]);
            int minutes = Int32.Parse(startTime.Text.Split(':')[1]);
            DateTime renovationDateTime = new DateTime(pickedDate.Year, pickedDate.Month, pickedDate.Day, hours, minutes, 00);
            return renovationDateTime;
        }

        private void Greska(bool goodDate)
        {
            if (!goodDate)
            {
                MessageBox.Show("Datum je vec zauzet, odaberite drugi");
            }
            else
            {
                MessageBox.Show("Uspesno ste zakazali renoviranje");
            }
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            Rooms dynamic = new Rooms();
            dynamic.Show();
            this.Close();
        }
    }
}
