using System.Windows;
using Service;
using System;
using Model;
using System.Collections.Generic;
using Hospital.View.Director;

namespace Hospital
{
    public partial class MainWindow : Window
    {
        private readonly RenovationService _renovationService = new RenovationService();
        private readonly RoomService _roomService = new RoomService();
        private readonly MovingStaticService _movingStaticService = new MovingStaticService();
        public MainWindow()
        {
            InitializeComponent();
            RenovationTime();
            //premestanje opreme
            MoviStaticEquipment();
                
        }

        private void RenovationTime()
        {
            List<RenovationAppointment> renovations = _renovationService.GetAll();
            foreach (RenovationAppointment renovation in renovations)
            {
                if (renovation.StartTime.Ticks <= DateTime.Now.Ticks)
                {
                    if (renovation.Type == 0)
                    {
                        _roomService.AttachRooms(renovation.RoomId, renovation.RoomBId);
                        _renovationService.Delete(renovation.Id);
                    }
                    else
                    {
                        _roomService.DettachRooms(renovation.RoomId);
                        _renovationService.Delete(renovation.Id);
                    }
                }

            }
        }

        private void MoviStaticEquipment()
        {
            List<MovingStatic> listOfStatic = _movingStaticService.GetAll();
            foreach (MovingStatic staticToMove in listOfStatic )
            {
                if (staticToMove.DateTime.Ticks <= DateTime.Now.Ticks)
                {
                    _roomService.MoveStaticEquipment(staticToMove.StaticId, staticToMove.RoomId);
                    _movingStaticService.Delete(staticToMove.Id);
                }

            }

        }

        private void ViewRooms_Click(object sender, RoutedEventArgs e)
        {
            Rooms rooms = new Rooms();
            rooms.Show();
            this.Close();
        }
        private void ViewDynamic_Click(object sender, RoutedEventArgs e)
        {
            Dynamic dynamic = new Dynamic();
            dynamic.Show();
            this.Close();
        }
        private void ViewStatic_Click(object sender, RoutedEventArgs e)
        {
            Static equipment = new Static();
            equipment.Show();
            this.Close();
        }

        private void ViewMedicine_Click(object sender, RoutedEventArgs e)
        {
            Medicines rooms = new Medicines();
            rooms.Show();
            this.Close();
        }


    }
}
