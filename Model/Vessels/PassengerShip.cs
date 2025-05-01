using System.Windows;

namespace Sea_Transportation_Management_System.Model.Vessels
{
    class PassengerShip : Vessel
    {
        public double Passengers
        {
            get { return Passengers; }
            set
            {
                if (Passengers < 0)
                {
                    MessageBox.Show("Amount of passengers cannot be negative!");
                    return;
                }
            }
        }
        public PassengerShip(int id, string? name, double cargoCapacity, float fuelCapacity) : base(id, name, cargoCapacity, fuelCapacity)
        {

        }

        public override double CalculateFuelConsumption(double distance)
        {
            if (Passengers == default)
            {
                MessageBox.Show("Input amount of passengers!");
                return 0;
            }
            return distance;
        }
    }
}
