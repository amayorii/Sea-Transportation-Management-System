using System.Windows;
using Sea_Transportation_Management_System.Model.Interfaces;
using Sea_Transportation_Management_System.Model.Vessels;

namespace Sea_Transportation_Management_System.Model
{
    public class Port : IRefuelable
    {
        public Port(int id, string? name, Point? point, float fuelStock)
        {
            Id = id;
            Name = name;
            Point = point;
            FuelStock = fuelStock;
        }

        public int Id { get; protected set; }
        public string? Name { get; set; }
        public Point? Point { get; private set; }
        public float FuelStock { get; protected set; }
        public double CalculateDistanceTo(Port port)
        {
            return Math.Sqrt(Math.Pow(port.Point.Value.X - Point.Value.X, 2) + Math.Pow(port.Point.Value.Y - Point.Value.Y, 2));
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
    }
}
