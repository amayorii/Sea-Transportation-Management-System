using System.Windows;
using System.Windows.Controls;
using Sea_Transportation_Management_System.Model;
using Sea_Transportation_Management_System.Model.Vessels;

namespace Sea_Transportation_Management_System.View
{
    /// <summary>
    /// Interaction logic for ViewStorageWindow.xaml
    /// </summary>
    public partial class ViewStorageWindow : Window
    {
        private Vessel vessel;
        private Port port;
        public ViewStorageWindow(object storagable) // TODO rework storage mechanic and use Storage class instead of object
        {
            InitializeComponent();
            if (storagable is Vessel vessel)
            {
                this.vessel = vessel;
                vesselStorage.Visibility = Visibility.Visible;
                portStorage.Visibility = Visibility.Hidden;
            }
            else if (storagable is Port port)
            {
                this.port = port;
                portStorage.Visibility = Visibility.Visible;
                vesselStorage.Visibility = Visibility.Hidden;
            }
            else Close();
        }

        private void VesselsStorage_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            unloadBtn.IsEnabled = vesselStorageList.SelectedItems != null;
        }

        private void PortStorage_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            loadBtn.IsEnabled = portStorageList.SelectedItems != null;
        }
    }
}
