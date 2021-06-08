﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using Model;
using Controller;

namespace Hospital.View.Director
{

    public partial class RoomCrud : Window
    {
        App app = (App)Application.Current;

        private readonly RenovationController renovationController = new RenovationController();
        private int id; 
       

        public RoomCrud()
        {
            InitializeComponent();
            RenovationTime();
            List<Room> roomsToShow = app.roomController.GetAll();
            roomsDataGrid.ItemsSource = roomsToShow;
        }
        private void RenovationTime()
        {
            List<RenovationAppointment> renovations = renovationController.GetAll();

            foreach (RenovationAppointment renovation in renovations)
            {
                if (renovation.StartTime.Ticks <= DateTime.Now.Ticks)
                {
                    DoRenovation(renovation);
                }

            }
        }
        private void DoRenovation(RenovationAppointment renovation)
        {
            if (renovation.Type == 0)
            {
                app.roomController.AttachRooms(renovation.RoomId, renovation.RoomBId);
            }
            else
            {
                app.roomController.DettachRooms(renovation.RoomId);
            }
            renovationController.Delete(renovation.Id);
        }
        private Room CreateRoom()
        {
            int id = app.roomController.GenerateNewId();
            string textname = name.Text;
            Enum.TryParse(type.Text, out RoomType myStatus);
            string roomdetail = detail.Text;
            int roomfloor = Int32.Parse(floor.Text);
            app.roomController.Save(textname, myStatus, roomfloor, roomdetail);
            return new Room(id, textname, myStatus, roomfloor, roomdetail, true);
        }

        private void New_Room_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Room room = CreateRoom();
            }
            catch
            {
                MessageBox.Show("You have to fill in all input boxes!");
            }
        }
        private void Delete_Room_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Room room = (Room)roomsDataGrid.SelectedItems[0];
                app.roomController.Delete(room.Id);
            }
            catch
            {
                MessageBox.Show("You have to select a room to delete!");
            }
        }

        private void updateRoomButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Room room = (Room)roomsDataGrid.SelectedItems[0];
                id = room.Id;
                createRoom.Visibility = Visibility.Collapsed;
                updateRoomButton.Visibility = Visibility.Visible;
                cancelupdateRoomButton.Visibility = Visibility.Visible;
                title.Content = "Edit room";


                name.Text = room.Name;
                floor.Text = room.Floor.ToString();
                detail.Text = room.Detail;
                type.Text = room.RoomType.ToString();


            }
            catch
            {
                MessageBox.Show("You have to fill in all input boxes!");
            }
        }

        private void update_Room_Click(object sender, RoutedEventArgs e)
        {
            string textname = name.Text;
            Enum.TryParse(type.Text, out RoomType myStatus);
            string roomdetail = detail.Text;
            int roomfloor = Int32.Parse(floor.Text);
            Room room = new Room(id, textname, myStatus, roomfloor, roomdetail, true);
            app.roomController.Update(room);
            id = -1;
        }

        private void cancelupdateRoomButton_Click(object sender, RoutedEventArgs e)
        {
            name.Text = "";
            floor.Text = "";
            detail.Text = "";
            type.Text = "";

            createRoom.Visibility = Visibility.Visible;
            updateRoomButton.Visibility = Visibility.Collapsed;
            cancelupdateRoomButton.Visibility = Visibility.Collapsed;
            title.Content = "Create new room";
        }

        private void Renovation_Click(object sender, RoutedEventArgs e)
        {
            Renovation renovation = new Renovation();
            renovation.Show();
            
        }

        private void HardRenovation_Click(object sender, RoutedEventArgs e)
        {
            HardRenovation hardRenovation = new HardRenovation();
            hardRenovation.Show();
        }
    }
}