using System.Collections.ObjectModel;
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
        }
        private void Loaded()
        {
            Container cont = new Container(1, "Sand", 100);
            cont.AddContent("Nigger");
            cont.AddContent("Stefan");
            cont.AddContent("Aria");
            Container cont1 = new Container(2, "German", 150);
            cont.AddContent("Africa");
            cont.AddContent("Mae");
            cont.AddContent("Au");
            Container cont2 = new Container(3, "Pizza", 150);
            cont.AddContent("arbaiten");
            cont.AddContent("mk");
            cont.AddContent("haze");
            Port port = new Port(1, "Black Pearl", new Location(44.6500, 33.5200), 700, 1500, 50);
            port.Storage.AddItem(cont);
            port.Storage.AddItem(cont2);
            port.Storage.AddItem(new Barrel(1, new Water(75)));
            port.Storage.AddItem(new Barrel(2, new Fuel(100)));
            port.Storage.AddItem(new Barrel(3, new Water(29)));
            Ports.Add(port);

            ContainerShip c1 = new ContainerShip(1, "Sea Queen", 320, port, 600, 30);
            Tanker t1 = new Tanker(2, "Red Serpent", 600, port, 1500, 30);
            PassengerShip p1 = new PassengerShip(3, "Human being", 1350, port);
            c1.Refuel(500);
            c1.LoadCargo(cont);
            c1.LoadCargo(cont1);
            c1.LoadCargo(cont);
            t1.LoadCargo(new Barrel(1, new Oil(10)));
            t1.LoadCargo(new Barrel(2, new Water(500)));
            t1.LoadCargo(new Barrel(3, new Fuel(260)));
            p1.Refuel(996);
            Vessels.Add(c1);
            Vessels.Add(t1);
            Vessels.Add(p1);
        }
    }
}
