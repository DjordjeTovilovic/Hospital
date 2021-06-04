using System.Windows;

namespace Hospital.View.Director
{

    public partial class MedicineNaruci : Window
    {

        public MedicineNaruci(string name, string opis)
        {
            InitializeComponent();
            this.name.Content = name;
            description.Content = opis;

        }
        private void Back_Click(object sender, RoutedEventArgs e)
        {
            Medicines dynamic = new Medicines();
            dynamic.Show();
            this.Close();
        }
        private void Prihvati_Click(object sender, RoutedEventArgs e)
        {

            Medicines dynamic = new Medicines();
            dynamic.Show();
            this.Close();
        }
    }
}
