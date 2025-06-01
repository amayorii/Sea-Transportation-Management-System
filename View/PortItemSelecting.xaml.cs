using System.Windows;
using System.Windows.Controls;
using Sea_Transportation_Management_System.Model;
using Sea_Transportation_Management_System.Model.Interfaces;
using Sea_Transportation_Management_System.Model.Vessels;

namespace Sea_Transportation_Management_System.View
{
    /// <summary>
    /// Interaction logic for PortItemSelectingWindow.xaml
    /// </summary>
    public partial class PortItemSelecting : Window
    {
        private readonly Port port;
        private readonly Vessel vessel;
        public PortItemSelecting(Vessel vessel)
        {
            InitializeComponent();
            port = vessel.CurrentPort;
            this.vessel = vessel;
            Type targetType = vessel.TypeOfTransportable;

            if (targetType != null)
            {
                StorageList.ItemsSource = port.Storage.Items
                    .Where(item => item.GetType() == targetType)
                    .ToList();
            }
        }

        private void Storage_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Submit.IsEnabled = StorageList.SelectedItems != null;
        }

        private void SubmitClick(object sender, RoutedEventArgs e)
        {
            foreach (var _item in StorageList.SelectedItems.Cast<object>().ToList())
            {
                try
                {
                    var item = (ITransportable)_item;
                    (vessel as ICargo)!.LoadCargo(item);
                    port.Storage.RemoveItem(item);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            Close();
        }
    }
}
