using System.Collections.ObjectModel;
using System.Windows;
using Sea_Transportation_Management_System.Model;

namespace Sea_Transportation_Management_System.View
{
    /// <summary>
    /// Interaction logic for RegisterPortWindow.xaml
    /// </summary>
    public partial class RegisterPortWindow : Window
    {
        private static readonly ObservableCollection<Port> ports = App.Ports;
        public RegisterPortWindow()
        {
            InitializeComponent();
        }

        private void Submit(object sender, RoutedEventArgs e)
        {
            int id = ports.Last() == null ? 0 : ports.Last().Id + 1;
            string name = nameBox.Text;
            Location location = new Location(Convert.ToDouble(latitude.Text), Convert.ToDouble(longitude.Text));
            float fuelStock = (float)Convert.ToDouble(fuelStockBox.Text);
            double capacity = (float)Convert.ToDouble(capacityBox.Text);
            int items = Convert.ToInt32(itemBox.Text);
            ports.Add(new Port(id, name, location, fuelStock, capacity, items));
        }
    }
}
