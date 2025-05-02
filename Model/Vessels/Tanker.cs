using System.Text;
using System.Windows;
using Sea_Transportation_Management_System.Model.Interfaces;
using Sea_Transportation_Management_System.Model.Transportable;

namespace Sea_Transportation_Management_System.Model.Vessels
{
    class Tanker : Vessel, ICargo
    {
        private readonly List<Barrel> _barrelList = new List<Barrel>();
        private double _fluidWeight;

        public List<Barrel> BarrelList
        {
            get { return _barrelList; }
        }

        public double FluidWeight
        {
            get { return _fluidWeight; }
            set
            {
                if (value < 0)
                {
                    MessageBox.Show("Weight cannot be negative!");
                    return;
                }
                _fluidWeight = value;
            }
        }
        public Tanker(int id, string? name, double cargoCapacity, float fuelCapacity) : base(id, name, cargoCapacity, fuelCapacity)
        {

        }

        public override double CalculateFuelConsumption(double distance)
        {
            if (_fluidWeight == default)
            {
                MessageBox.Show("Input a fluid weight!");
                return 0;
            }
            else if (FluidWeight == 0)
                return distance * 1.3;

            return distance * (1.3 + FluidWeight / Capacity / 4);
        }

        public void LoadCargo(ITransportable transportable)
        {
            if (transportable is not Barrel barrel)
            {
                MessageBox.Show("You can only load barrels on this type of vessel");
                return;
            }

            if (FluidWeight + barrel.Weight > Capacity)
            {
                MessageBox.Show($"Weight of barrel \"{barrel.Id}\" exceeds the capacity limit");
                return;
            }

            FluidWeight += barrel.Weight;
            BarrelList.Add(barrel);
        }

        public void UnloadCargo(ITransportable transportable)
        {
            throw new NotImplementedException();
        }

        public void ViewCargo()
        {
            if (BarrelList.Count == 0)
                MessageBox.Show("The ship is empty.");

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Cargo of \"{Name}\":");

            foreach (var barrel in BarrelList)
            {
                sb.AppendLine(barrel.ToString());
            }

            sb.AppendLine($"Total weight: {FluidWeight} / {Capacity}");

            MessageBox.Show(sb.ToString(), "Cargo", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
