using System.Windows;
using Sea_Transportation_Management_System.Model.Interfaces;

namespace Sea_Transportation_Management_System.Model.Vessels
{
    class ContainerShip : Vessel, ICargo
    {
        public double ContainersWeight
        {
            get { return ContainersWeight; }
            set
            {
                if (ContainersWeight < 0)
                {
                    MessageBox.Show("Weight cannot be negative!");
                    return;
                }
            }
        }
        public ContainerShip(int id, string? name, double cargoCapacity, float fuelCapacity) : base(id, name, cargoCapacity, fuelCapacity)
        {

        }

        public override double CalculateFuelConsumption(double distance)
        {
            if (ContainersWeight == default)
            {
                MessageBox.Show("Input a containers weight!");
                return 0;
            }
            else if (ContainersWeight == 0)
                return distance * 0.9;

            return distance * (0.9 + ContainersWeight / Capacity / 4);
        }

        // зробить так, щоб були окремі об'єкти грузів, і щоб можна було подивитись що в кожному знаходиться
        public void LoadCargo(double weight)
        {
            throw new NotImplementedException();
        }

        public void UnloadCargo(double weight)
        {
            throw new NotImplementedException();
        }
    }
}
