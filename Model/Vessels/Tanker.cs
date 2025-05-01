using System.Windows;

namespace Sea_Transportation_Management_System.Model.Vessels
{
    class Tanker : Vessel
    {
        public double FluidWeight
        {
            get { return FluidWeight; }
            set
            {
                if (FluidWeight < 0)
                {
                    MessageBox.Show("Weight cannot be negative!");
                    return;
                }
            }
        }
        public Tanker(int id, string? name, double cargoCapacity, float fuelCapacity) : base(id, name, cargoCapacity, fuelCapacity)
        {

        }

        public override double CalculateFuelConsumption(double distance)
        {
            if (FluidWeight == default)
            {
                MessageBox.Show("Input a fluid weight!");
                return 0;
            }
            else if (FluidWeight == 0)
                return distance * 1.3;

            return distance * (1.3 + FluidWeight / Capacity / 4);
        }
    }
}
