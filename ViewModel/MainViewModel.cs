using System.Collections.ObjectModel;
using Sea_Transportation_Management_System.Model;
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
            ContainerShip c1 = new ContainerShip(1, "Sea Queen", 320, 600, 30);
            c1.Location = new Location(46.4825, 30.7233);
            Tanker t1 = new Tanker(2, "Red Serpent", 600, 1500, 30);
            t1.Location = new Location(32.4144, 5.6555);
            PassengerShip p1 = new PassengerShip(3, "Human being", 1350);
            p1.Location = new Location(31.4144, 8.6555);
            c1.Refuel(500);

            p1.Refuel(1350);
            Vessels.Add(c1);
            Vessels.Add(t1);
            Vessels.Add(p1);

            Port port = new Port(1, "Black Pearl", new Location(44.6500, 33.5200), 700, 1500, 50);
            Ports.Add(port);
        }
    }
}
