using System.Windows;
using System.Windows.Controls;
using Sea_Transportation_Management_System.Model;
using Sea_Transportation_Management_System.Model.Interfaces;
using Sea_Transportation_Management_System.ViewModel;

namespace Sea_Transportation_Management_System.View
{
    /// <summary>
    /// Interaction logic for PortStorageView.xaml
    /// </summary>
    public partial class PortStorageView : UserControl
    {
        private Port port;
        public PortStorageView()
        {
            InitializeComponent();
        }
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            port = (DataContext as PortStorageViewModel)!.Port;
        }

        private void Storage_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            loadBtn.IsEnabled = StorageList.SelectedItems != null && port.VesselsInPort.Count > 0;
        }

        private void LoadClick(object sender, RoutedEventArgs e)
        {
            VesselSelecting selectedVessel = new VesselSelecting(port, [.. StorageList.SelectedItems.Cast<ITransportable>()]);
            selectedVessel.ShowDialog();
        }
    }
}
