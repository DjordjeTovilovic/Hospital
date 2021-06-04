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
    
    public partial class DynamicDetail : Window
    {
        private readonly Controller.DynamicEquipmentController dynamicEquipmentController = new Controller.DynamicEquipmentController();
        private Model.DynamicEquipment dynamicEquipment;
        public DynamicDetail(string name, int qunatity, string description)
        {
            InitializeComponent();
            ime.Content = name;
            kolicina.Content = qunatity;
            opis.Content = description;
            dynamicEquipment = dynamicEquipmentController.GetByName(name)[0];
        }
        private void Delete_Click(object sender, RoutedEventArgs e)
        {


            dynamicEquipmentController.Delete(dynamicEquipment.Id);
            MessageBox.Show("Uspesno ste obrisali " + dynamicEquipment.Name);
            Back_Click(sender, e);
        }
        private void Back_Click(object sender, RoutedEventArgs e)
        {
            Dynamic dynamic = new Dynamic();
            dynamic.Show();
            this.Close();
        }
        private void ShowUpdate_Click(object sender, RoutedEventArgs e)
        {
            ime.Visibility = Visibility.Collapsed;
            kolicina.Visibility = Visibility.Collapsed;
            opis.Visibility = Visibility.Collapsed;

            updateName.Visibility = Visibility.Visible;
            updateQuantity.Visibility = Visibility.Visible;
            updateDescription.Visibility = Visibility.Visible;

            updateName.Text = ime.Content.ToString();
            updateQuantity.Text = kolicina.Content.ToString();
            updateDescription.Text = opis.Content.ToString();


            deleteButton.Visibility = Visibility.Collapsed;
            updateButton.Visibility = Visibility.Collapsed;
            prihvatiButton.Visibility = Visibility.Visible;
            odustaniButton.Visibility = Visibility.Visible;

        }

        private void Prihvati_Click(object sender, RoutedEventArgs e)
        {
            int err = 0;
            nameError.Content = "";
            quaError.Content = "";
            descError.Content = "";
            if (updateName.Text == "")
            {
                nameError.Content = "Popunite polje!";
                err++;
            }
            if (updateQuantity.Text == "")
            {
                quaError.Content = "Popunite polje!";
                err++;
            }
            if (updateDescription.Text == "")
            {
                descError.Content = "Popunite polje!";
                err++;
            }
            if (err == 0)
            {

                dynamicEquipment.Name = updateName.Text;
                dynamicEquipment.Description = updateDescription.Text;
                dynamicEquipment.Quantity = Int32.Parse(updateQuantity.Text);

                dynamicEquipmentController.Update(dynamicEquipment);
                MessageBox.Show("Uspesno ste azurirali " + updateName.Text);

                nameError.Content = "";
                quaError.Content = "";
                descError.Content = "";
                ime.Content = dynamicEquipment.Name;
                kolicina.Content = dynamicEquipment.Quantity;
                opis.Content = dynamicEquipment.Description;

                Ponisti_Click(sender, e);
            }

        }
        private void Ponisti_Click(object sender, RoutedEventArgs e)
        {
            ime.Visibility = Visibility.Visible;
            kolicina.Visibility = Visibility.Visible;
            opis.Visibility = Visibility.Visible;

            updateName.Visibility = Visibility.Collapsed;
            updateQuantity.Visibility = Visibility.Collapsed;
            updateDescription.Visibility = Visibility.Collapsed;

            deleteButton.Visibility = Visibility.Visible;
            updateButton.Visibility = Visibility.Visible;
            prihvatiButton.Visibility = Visibility.Collapsed;
            odustaniButton.Visibility = Visibility.Collapsed;
        }
    }
}
