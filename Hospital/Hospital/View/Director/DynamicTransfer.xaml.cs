using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;


namespace Hospital.View.Director
{
    /// <summary>
    /// Interaction logic for DynamicTransfer.xaml
    /// </summary>
    public partial class DynamicTransfer : Window
    {
        private readonly Controller.DynamicEquipmentController equipmentController = new Controller.DynamicEquipmentController();
        public ObservableCollection<Model.DynamicEquipment> ListDynamic
        {
            get;
            set;
        }

        public ObservableCollection<Model.DynamicEquipment> ListUsed
        {
            get;
            set;
        }
        public DynamicTransfer()
        {
            InitializeComponent();
            DataContext = this;
            List<Model.DynamicEquipment> l = equipmentController.GetAll();
            ListDynamic = new ObservableCollection<Model.DynamicEquipment>(l);
            ListUsed = new ObservableCollection<Model.DynamicEquipment>();

        }

        Point startPoint = new Point();

        private void ListView_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            startPoint = e.GetPosition(null);
        }

        private void ListView_MouseMove(object sender, MouseEventArgs e)
        {
            Point mousePos = e.GetPosition(null);
            Vector diff = startPoint - mousePos;

            if (e.LeftButton == MouseButtonState.Pressed &&
                (Math.Abs(diff.X) > SystemParameters.MinimumHorizontalDragDistance ||
                Math.Abs(diff.Y) > SystemParameters.MinimumVerticalDragDistance))
            {
                // Get the dragged ListViewItem
                ListView listView = sender as ListView;
                ListViewItem listViewItem =
                    FindAncestor<ListViewItem>((DependencyObject)e.OriginalSource);

                if (listViewItem == null) return;

                // Find the data behind the ListViewItem
                Model.DynamicEquipment dynamic = (Model.DynamicEquipment)listView.ItemContainerGenerator.
                    ItemFromContainer(listViewItem);

                // Initialize the drag & drop operation
                DataObject dragData = new DataObject("myFormat", dynamic);
                DragDrop.DoDragDrop(listViewItem, dragData, DragDropEffects.Move);
            }
        }

        private static T FindAncestor<T>(DependencyObject current) where T : DependencyObject
        {
            do
            {
                if (current is T t)
                {
                    return t;
                }
                current = VisualTreeHelper.GetParent(current);
            }
            while (current != null);
            return null;
        }

        private void ListView_DragOver(object sender, DragEventArgs e)
        {
            if (!e.Data.GetDataPresent("myFormat") || e.Source == sender)
            {
                e.Effects = DragDropEffects.None;
            }
        }

        private void ListView_Drop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent("myFormat"))
            {
                Model.DynamicEquipment dynamic = e.Data.GetData("myFormat") as Model.DynamicEquipment;
                ListDynamic.Remove(dynamic);

                ListUsed.Add(dynamic);
                equipmentController.Delete(dynamic.Id);
                
            }
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            Dynamic dynamic = new Dynamic();
            dynamic.Show();
            Close();
        }

    }
}
