using System.ComponentModel;
using System.Windows;
using Sea_Transportation_Management_System.Model.Interfaces;
using Sea_Transportation_Management_System.Model.Vessels;

namespace Sea_Transportation_Management_System.Model
{
    public class Port : IRefuelable, IStoragable, INotifyPropertyChanged
    {
        private int _id;
        private string _name;
        private Location _location;
        private List<Vessel> _vessels;
        private float _fuelStock;
        private Storage _storage;

        public Port(int id, string? name, Location location, float fuelStock, double warehouseCapacity, int maxItems)
        {
            Id = id;
            Name = name;
            Location = location;
            FuelStock = fuelStock;
            Storage = new Storage(warehouseCapacity, maxItems);
            _vessels = [];
            Storage.PropertyChanged += (s, e) =>
            {
                OnPropertyChanged(nameof(Info));
            };
        }

        public int Id
        {
            get { return _id; }
            set
            {
                _id = value;
                OnPropertyChanged(nameof(Id));
            }
        }
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }
        public Location Location
        {
            get { return _location; }
            set
            {
                _location = value;
                OnPropertyChanged(nameof(Location));
            }
        }
        public float FuelStock
        {
            get { return _fuelStock; }
            set
            {
                _fuelStock = value;
                OnPropertyChanged(nameof(FuelStock));
            }
        }
        public List<Vessel> VesselsInPort
        {
            get { return _vessels; }
            set
            {
                _vessels = value;
                OnPropertyChanged(nameof(VesselsInPort));
            }
        }
        public Storage Storage
        {
            get { return _storage; }
            set
            {
                _storage = value;
                OnPropertyChanged(nameof(Storage));
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        public string Info => ToString();
        private void OnPropertyChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Info)));
        }

        public double CalculateDistanceTo(Port port)
        {
            double R = 6371; // earth радіус в км
            double latDiff = DegToRad(port.Location.Latitude - this.Location.Latitude);
            double lonDiff = DegToRad(port.Location.Longitude - this.Location.Longitude);

            double haversine = Math.Sin(latDiff / 2) * Math.Sin(latDiff / 2) +
                       Math.Cos(DegToRad(this.Location.Latitude)) * Math.Cos(DegToRad(port.Location.Latitude)) *
                       Math.Sin(lonDiff / 2) * Math.Sin(lonDiff / 2);

            double c = 2 * Math.Atan2(Math.Sqrt(haversine), Math.Sqrt(1 - haversine));
            double distance = R * c;

            return distance;
        }

        private static double DegToRad(double deg)
        {
            return deg * (Math.PI / 180);
        }

        public void Refuel(float amount)
        {
            if (amount < 0)
            {
                if (amount < 0)
                {
                    MessageBox.Show("Cannot refuel for a negative value!");
                    return;
                }
            }
            FuelStock += amount;
        }
        public void AttachVessel(Vessel vessel)
        {
            VesselsInPort.Add(vessel);
            OnPropertyChanged(nameof(VesselsInPort));
        }
        public void DetachVessel(Vessel vessel)
        {
            VesselsInPort.Remove(vessel);
            OnPropertyChanged(nameof(VesselsInPort));
        }
        public override string ToString()
        {
            return $"Id: {Id}\n{"Name:",-7}{Name.Length switch
            {
                > 15 => $"{Name}\t",
                < 6 => $"{Name,-20}\t\t",
                _ => $"{Name,-10}\t\t"
            }}Fuel stock: {FuelStock}\nVessels in port: {VesselsInPort.Count}\nWarehouse capacity: {Storage.CurrentWeight}\nLocation: {Location.Latitude}  {Location.Longitude}";
        }
    }
}
