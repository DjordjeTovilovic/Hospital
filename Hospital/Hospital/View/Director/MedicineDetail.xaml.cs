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
    /// Interaction logic for MedicineDetail.xaml
    /// </summary>
    public partial class MedicineDetail : Window
    {
        private readonly Controller.MedicineController medicineController = new Controller.MedicineController();
        private Model.Medicine medicine;
        public MedicineDetail(string name, string description)
        {
            InitializeComponent();
            ime.Content = name;

            opis.Content = description;

            medicine = medicineController.GetByName(name);

        }


        private void Delete_Click(object sender, RoutedEventArgs e)
        {


            medicineController.Delete(medicine.Id);
            MessageBox.Show("Uspesno ste obrisali sobu " + medicine.Name);

            Back_Click(sender, e);
        }
        private void Back_Click(object sender, RoutedEventArgs e)
        {
            Medicines stat = new Medicines();
            stat.Show();
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
            naruciButton.Visibility = Visibility.Collapsed;

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
                nameError.Content = "";
                quaError.Content = "";
                descError.Content = "";
                medicine.Name = updateName.Text;
                medicine.Description = updateDescription.Text;

                medicineController.Update(medicine);
                MessageBox.Show("Uspesno ste azurirali " + updateName.Text);

                ime.Content = medicine.Name;
                opis.Content = medicine.Description;

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
            naruciButton.Visibility = Visibility.Visible;
        }

        private void Naruci_Click(object sender, RoutedEventArgs e)
        {
            MedicineNaruci staticRoomTransfer = new MedicineNaruci(medicine.Name, medicine.Description);
            staticRoomTransfer.Show();
            Close();
        }
    }
}
