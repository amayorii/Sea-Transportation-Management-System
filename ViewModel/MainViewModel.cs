using System.Collections.ObjectModel;
using MapControl;
using Sea_Transportation_Management_System.Model;
using Sea_Transportation_Management_System.Model.Transportable;
using Sea_Transportation_Management_System.Model.Transportable.Fluids;
using Sea_Transportation_Management_System.Model.Vessels;

namespace Sea_Transportation_Management_System.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        public ObservableCollection<Vessel> Vessels { get; set; }
        public ObservableCollection<Port> Ports { get; set; }
        public MainViewModel(ObservableCollection<Vessel> vessels, ObservableCollection<Port> ports)
        {
            Vessels = vessels;
            Ports = ports;
            Loaded();
            foreach (var vessel in Vessels) vessel.UpdateStatus(Ports);
        }
        private void Loaded()
        {
            Port port = new Port(1, "Black Pearl", new Location(44.6500, 33.5200), 700, 1500, 50);
            ContainerShip c1 = new ContainerShip(1, "Sea Queen", port, 320, 600, 30);
            c1.LoadCargo(new Container(1, "Grechka", 321));
            c1.LoadCargo(new Container(2, "Sand", 230) { Contents = { "nigga", "ada", "ps", "53232", "40 pachok grechki" } });
            Tanker t1 = new Tanker(2, "Red Serpent", port, 600, 1500, 30);
            t1.LoadCargo(new Barrel(1, new Oil(40)));
            t1.LoadCargo(new Barrel(2, new Water(10)));
            t1.LoadCargo(new Barrel(3, new Fuel(5.1)));

            PassengerShip p1 = new PassengerShip(3, "Human being", port, 1350);
            c1.Refuel(100);

            p1.Refuel(120);

            Vessels.Add(c1);
            Vessels.Add(t1);
            Vessels.Add(p1);

            port.Storage.AddItem(new Container(1, "Grechka", 321));
            port.Storage.AddItem(new Barrel(1, new Oil(40)));
            port.Storage.AddItem(new Barrel(2, new Water(10)));
            port.Storage.AddItem(new Barrel(3, new Fuel(5.1)));

            Ports.Add(port);
        }
    }
}
