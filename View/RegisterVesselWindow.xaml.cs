using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using Sea_Transportation_Management_System.Model;
using Sea_Transportation_Management_System.Model.Interfaces;
using Sea_Transportation_Management_System.Model.Vessels;
using Sea_Transportation_Management_System.ViewModel;

namespace Sea_Transportation_Management_System.View
{
    /// <summary>
    /// Interaction logic for RegisterVesselWindow.xaml
    /// </summary>
    public partial class RegisterVesselWindow : Window
    {
        private static readonly ObservableCollection<Vessel> vessels = App.Vessels;
        private bool storagable;

        public RegisterVesselWindow()
        {
            InitializeComponent();
            DataContext = new RegisterVesselViewModel();
        }

        private void Submit(object sender, RoutedEventArgs e)
        {
            var type = typeBox.SelectedItem.ToString();
            Vessel vessel = type switch
            {
                "Tanker" => new Tanker(),
                "PassengerShip" => new PassengerShip(),
                "ContainerShip" => new ContainerShip(),
                _ => throw new Exception($"Unknown vessel {type}")
            };
            vessel.Name = nameBox.Text;
            vessel.Status = VesselStatus.WaitingInPort;
            vessel.CurrentPort = App.Ports.Where(port => port.Name == homePortBox.SelectedItem.ToString()).Select(port => port).First();
            vessel.FuelCapacity = (float)Convert.ToDouble(fuelBox.Text);
            if (storagable)
            {
                ICargo cargoVessel = (ICargo)vessel;
                cargoVessel.Storage = new Storage(Convert.ToDouble(capacityBox.Text), Convert.ToInt32(itemBox.Text));
                vessels.Add(cargoVessel as Vessel);
            }
            vessels.Add(vessel);
        }

        private void TypeChanged(object sender, SelectionChangedEventArgs e)
        {
            if (typeBox.SelectedItem.ToString() != "PassengerShip")
            {
                storageRow.Height = new GridLength(1, GridUnitType.Star);
                storagable = true;
            }
            else
            {
                storageRow.Height = new GridLength(0, GridUnitType.Pixel);
                storagable = false;
            }
        }
    }
}
