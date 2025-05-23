using System.ComponentModel;
using System.Windows;
using MapControl;
using Sea_Transportation_Management_System.Model.Interfaces;
using Sea_Transportation_Management_System.Model.Vessels;

namespace Sea_Transportation_Management_System.Model
{
    public class Port : IRefuelable, INotifyPropertyChanged
    {
        private int _id;
        private string _name;
        private Location _location;
        private float _fuelStock;
        private float _currentCapacity;
        private float _warehouseCapacity;
        public Port(int id, string? name, Location location, float fuelStock, float warehouseCapacity)
        {
            Id = id;
            Name = name;
            Location = location;
            FuelStock = fuelStock;
            CurrentCapacity = 0;
            WarehouseCapacity = warehouseCapacity;
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
        public float CurrentCapacity
        {
            get { return _currentCapacity; }
            set
            {
                _currentCapacity = value;
                OnPropertyChanged(nameof(CurrentCapacity));
            }
        }
        public float WarehouseCapacity
        {
            get { return _warehouseCapacity; }
            set
            {
                _warehouseCapacity = value;
                OnPropertyChanged(nameof(WarehouseCapacity));
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
            return Math.Sqrt(Math.Pow(port.Location.Latitude - Location.Latitude, 2) + Math.Pow(port.Location.Longitude - Location.Longitude, 2));
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
        public void RefuelVessel(Vessel vessel, float amount)
        {
            if (FuelStock - amount < 0)
            {
                MessageBox.Show($"Cannot refuel {typeof(Vessel).Name} for {amount}. Fuel stock: {FuelStock}l");
            }
            FuelStock -= amount;
            vessel.Refuel(amount);
        }
        public override string ToString()
        {
            return $"Id: {Id}\n{"Name:",-7}{Name.Length switch
            {
                > 15 => $"{Name}\t",
                < 3 => $"{Name,-20}\t\t",
                _ => $"{Name,-10}\t\t"
            }}Fuel stock: {FuelStock}\nWarehouse capacity: {WarehouseCapacity}\nLocation: {Location.Latitude}  {Location.Longitude}";
        }
    }
}
