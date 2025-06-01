using System.Windows;
using System.Windows.Controls;
using Sea_Transportation_Management_System.Model;
using Sea_Transportation_Management_System.Model.Interfaces;

namespace Sea_Transportation_Management_System.View
{
    /// <summary>
    /// Interaction logic for VesselSelecting.xaml
    /// </summary>
    public partial class VesselSelecting : Window
    {
        private readonly Port port;
        private readonly List<ITransportable> selectedItems;
        public VesselSelecting(Port port, List<ITransportable> selectedItems)
        {
            InitializeComponent();
            this.port = port;
            Vessels.ItemsSource = port.VesselsInPort.OfType<ICargo>().ToList();
            this.selectedItems = selectedItems;
        }

        private void Vessels_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectBtn.IsEnabled = Vessels.SelectedItem != null;
        }

        private void SelectClick(object sender, RoutedEventArgs e)
        {
            foreach (var item in selectedItems)
            {
                try
                {
                    (Vessels.SelectedItem as ICargo).LoadCargo(item);
                    port.Storage.RemoveItem(item);
                }
                catch (NullReferenceException)
                {
                    MessageBox.Show("Selected vessel is not storagable");
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
