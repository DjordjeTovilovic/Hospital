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
            try // promeniti samo ime sobe kad se spajaju 
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

        private void Attach(string roomAName, string roomBName)
        {
            Model.Room roomA = roomController.GetByName(roomAName);
            Model.Room roomB = roomController.GetByName(roomBName);

            DateTime renovationDateTime = SelectedDate();

            renovationController.AttachRooms(roomA.Id, roomB.Id, renovationDateTime, Double.Parse(duration.Text));
        }

        private void Dettach(string roomName)
        {
            Model.Room room = roomController.GetByName(roomName);
            DateTime renovationDateTime = SelectedDate();

            renovationController.DettachRooms(room.Id, renovationDateTime, Double.Parse(duration.Text));
        }
        private DateTime SelectedDate()
        {
            DateTime pickedDate = date.SelectedDate.Value;
            int hours = Int32.Parse(startTime.Text.Split(':')[0]);
            int minutes = Int32.Parse(startTime.Text.Split(':')[1]);
            DateTime renovationDateTime = new DateTime(pickedDate.Year, pickedDate.Month, pickedDate.Day, hours, minutes, 00);
            return renovationDateTime;
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            Dynamic dynamic = new Dynamic();
            dynamic.Show();
            this.Close();
        }
    }
}
