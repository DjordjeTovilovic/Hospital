using System;
using System.Collections.Generic;
using System.Windows;


namespace Hospital.View.Director
{
    /// <summary>
    /// Interaction logic for StaticRoomTransfer.xaml
    /// </summary>
    public partial class StaticRoomTransfer : Window
    {
        Controller.RoomController roomController = new Controller.RoomController();
        Model.StaticEquipment staticEquipmentP;
        public StaticRoomTransfer(Model.StaticEquipment staticEquipment)
        {
            InitializeComponent();
            this.kolicina.Content = staticEquipment.Quantity;
            this.ime.Content = staticEquipment.Name;
            Model.Room room = roomController.GetById(staticEquipment.RoomId);
            this.opis.Content = staticEquipment.Description;
            soba.Content += room.Name;
            staticEquipmentP = staticEquipment;

        }
        private void Back_Click(object sender, RoutedEventArgs e)
        {
            StaticDetail stat = new StaticDetail(staticEquipmentP.Name, staticEquipmentP.Quantity, staticEquipmentP.Description);
            stat.Show();
            Close();
        }

        private void Prihvati_Click(object sender, RoutedEventArgs e)
        {
            StaticDetail stat = new StaticDetail(staticEquipmentP.Name, staticEquipmentP.Quantity, staticEquipmentP.Description);
            stat.Show();
            Close();
        }

    }
}
