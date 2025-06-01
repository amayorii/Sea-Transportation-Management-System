using System.Windows.Controls;
using Sea_Transportation_Management_System.Model.Interfaces;
using Sea_Transportation_Management_System.Model.Vessels;
using Sea_Transportation_Management_System.ViewModel;

namespace Sea_Transportation_Management_System.View
{
    /// <summary>
    /// Interaction logic for VesselStorageView.xaml
    /// </summary>
    public partial class VesselStorageView : UserControl
    {
        private Vessel vessel;
        public VesselStorageView()
        {
            InitializeComponent();
        }
        private void UserControl_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            vessel = (DataContext as VesselStorageViewModel)!.Vessel;
        }

        private void Storage_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            bool inPort = vessel.Status == VesselStatus.WaitingInPort;
            unloadBtn.IsEnabled = StorageList.SelectedItems != null && inPort;
        }

        private void LoadFromWarehouse_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            PortItemSelecting selectingWindow = new PortItemSelecting(vessel);
            selectingWindow.ShowDialog();
        }

        private void Unload_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            foreach (var _item in StorageList.SelectedItems.Cast<object>().ToList())
            {
                var item = (ITransportable)_item;
                (vessel as ICargo)!.UnloadCargo(item);
                vessel.CurrentPort.Storage.AddItem(item);
            }
        }
    }
}
