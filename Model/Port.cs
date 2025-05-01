using System.Windows;
using Sea_Transportation_Management_System.Model.Interfaces;

namespace Sea_Transportation_Management_System.Model
{
    class Port : IRefuelable
    {
        public Port(int id, string? name, Point? point, float fuelStock)
        {
            Id = id;
            Name = name;
            Point = point;
            FuelStock = fuelStock;
        }

        public int Id
        {
            get { return Id; }
            protected set
            {
                if (Id < 0)
                {
                    MessageBox.Show("Id cannot be negative!");
                    return;
                }
            }
        }
        public string? Name { get; set; }
        public Point? Point { get; private set; }
        public float FuelStock { get; set; }
        public double CalculateDistanceTo(Port port)
        {
            return Math.Sqrt(Math.Pow(port.Point.Value.X - Point.Value.X, 2) + Math.Pow(port.Point.Value.Y - Point.Value.Y, 2));
        }
        public void Refuel(float amount)
        {
            throw new NotImplementedException();
        }
    }
}
