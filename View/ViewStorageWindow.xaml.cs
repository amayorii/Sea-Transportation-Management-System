using System.Windows;
using System.Windows.Controls;
using Sea_Transportation_Management_System.Model;
using Sea_Transportation_Management_System.Model.Interfaces;
using Sea_Transportation_Management_System.Model.Vessels;
using Sea_Transportation_Management_System.ViewModel;

namespace Sea_Transportation_Management_System.View
{
    /// <summary>
    /// Interaction logic for ViewStorageWindow.xaml
    /// </summary>
    public partial class ViewStorageWindow : Window
    {
        private Vessel vessel;
        private Port port;
        public ViewStorageWindow(ICargo storagable)
        {
            InitializeComponent();
            DataContext = new ViewStorageViewModel(storagable.Storage);
            if (storagable is Port port)
            {
                this.port = port;
                portStackpanel.Visibility = Visibility.Visible;
                vesselStackpanel.Visibility = Visibility.Hidden;

            }
            else
            {
                this.vessel = (Vessel)storagable;
                vesselStackpanel.Visibility = Visibility.Visible;
                portStackpanel.Visibility = Visibility.Hidden;
            }
        }

        private void Storage_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            unloadBtn.IsEnabled = storage.SelectedItems != null;
            loadBtn.IsEnabled = storage.SelectedItems != null;
        }
    }
}
