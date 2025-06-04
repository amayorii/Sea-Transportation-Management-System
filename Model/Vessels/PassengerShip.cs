using System.Windows;

namespace Sea_Transportation_Management_System.Model.Vessels
{
    class PassengerShip : Vessel
    {
        private int _passengers;
        public int Passengers
        {
            get { return _passengers; }
            set
            {
                if (value < 0)
                {
                    MessageBox.Show("Amount of passengers cannot be negative!");
                    return;
                }
                _passengers = value;
            }
        }
        public PassengerShip() : base() { }
        public PassengerShip(int id, string? name, float fuelCapacity, Port currentPort) : base(id, name, fuelCapacity, currentPort)
        {

        }

        public override double CalculateFuelConsumption(double distance)
        {
            if (_passengers == default)
            {
                return distance;
            }
            return distance * (1 + _passengers * 0.005);
        }
    }
}
