using System.Text;
using System.Windows;
using Sea_Transportation_Management_System.Model.Interfaces;
using Sea_Transportation_Management_System.Model.Transportable;

namespace Sea_Transportation_Management_System.Model.Vessels
{
    class ContainerShip : Vessel, ICargo
    {
        private readonly List<Container> _containerList = new List<Container>();
        private double _containersWeight;
        public List<Container> ContainerList
        {
            get { return _containerList; }
        }
        public double ContainersWeight
        {
            get { return _containersWeight; }
            set
            {
                if (value < 0)
                {
                    MessageBox.Show("Weight cannot be negative!");
                    return;
                }
                _containersWeight = value;
            }
        }
        public ContainerShip(int id, string? name, double cargoCapacity, float fuelCapacity) : base(id, name, cargoCapacity, fuelCapacity)
        {

        }

        public override double CalculateFuelConsumption(double distance)
        {
            if (_containersWeight == default)
            {
                MessageBox.Show("Input a containers weight!");
                return 0;
            }
            else if (ContainersWeight == 0)
                return distance * 0.9;

            return distance * (0.9 + ContainersWeight / Capacity / 4);
        }

        // зробить так, щоб були окремі об'єкти грузів, і щоб можна було подивитись що в кожному знаходиться
        public void LoadCargo(ITransportable cont)
        {
            if (cont is not Container container)
            {
                MessageBox.Show("You can only load containers on this type of vessel");
                return;
            }

            if (ContainersWeight + container.Weight > Capacity)
            {
                MessageBox.Show($"Weight of container \"{container.ContainerSign}\" exceeds the capacity limit");
                return;
            }

            ContainersWeight += container.Weight;
            ContainerList.Add(container);
        }

        public void UnloadCargo(ITransportable cont)
        {
            throw new NotImplementedException();
        }
        public void ViewCargo()
        {
            if (ContainerList.Count == 0)
                MessageBox.Show("The ship is empty.");

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Cargo of \"{Name}\":");

            foreach (var container in ContainerList)
            {
                sb.AppendLine(container.ToString());
            }

            sb.AppendLine($"Total weight: {ContainersWeight} / {Capacity}");

            MessageBox.Show(sb.ToString(), "Cargo", MessageBoxButton.OK, MessageBoxImage.Information);

        }
    }
}
