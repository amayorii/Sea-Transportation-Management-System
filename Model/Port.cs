using System.Windows;
using MapControl;
using Sea_Transportation_Management_System.Model.Interfaces;
using Sea_Transportation_Management_System.Model.Vessels;

namespace Sea_Transportation_Management_System.Model
{
    public class Port : IRefuelable
    {
        public Port(int id, string? name, Location location, float fuelStock, float warehouseCapacity)
        {
            Id = id;
            Name = name;
            Location = location;
            FuelStock = fuelStock;
            CurrentCapacity = 0;
            WarehouseCapacity = warehouseCapacity;
        }

        public int Id { get; protected set; }
        public string? Name { get; set; }
        public Location Location { get; private set; }
        public float FuelStock { get; protected set; }
        public float CurrentCapacity { get; protected set; }
        public float WarehouseCapacity { get; protected set; }
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
