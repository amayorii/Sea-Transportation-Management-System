using System.Text;
using System.Windows;
using Sea_Transportation_Management_System.Model.Interfaces;
using Sea_Transportation_Management_System.Model.Transportable;

namespace Sea_Transportation_Management_System.Model.Vessels
{
    public class ContainerShip : Vessel, ICargo
    {
        public Storage Storage { get; }

        public ContainerShip(int id, string? name, float fuelCapacity, double maxWeight, int maxItems) : base(id, name, fuelCapacity)
        {
            Storage = new Storage(maxWeight, maxItems);
        }

        public override double CalculateFuelConsumption(double distance)
        {
            if (Storage.CurrentWeight == 0)
                return distance * 0.9;

            return distance * (0.9 + Storage.CurrentWeight / Storage.MaxWeightCapacity / 4);
        }

        public void LoadCargo(ITransportable cont)
        {
            if (cont is not Container container)
            {
                MessageBox.Show("You can only load containers on this type of vessel");
                return;
            }

            if (Storage.CurrentWeight + container.Weight > Storage.MaxWeightCapacity)
            {
                MessageBox.Show($"Weight of container \"{container.ContainerSign}\" exceeds the capacity limit");
                return;
            }
            else if (Storage.CurrentItemCount == Storage.MaxItemCount)
            {
                MessageBox.Show($"Container \"{container.ContainerSign}\" is full");
                return;
            }
            Storage.AddItem(container);
        }

        public void UnloadCargo(ITransportable cont)
        {
            Storage.RemoveItem(cont);
        }
        public void ViewCargo()
        {
            if (Storage.CurrentItemCount == 0)
                MessageBox.Show("The ship is empty.");

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Cargo of \"{Name}\":");

            foreach (var container in Storage.Items)
            {
                sb.AppendLine(container.ToString());
            }

            sb.AppendLine($"Total weight: {Storage.CurrentWeight} / {Storage.MaxWeightCapacity}");

            MessageBox.Show(sb.ToString(), "Cargo", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
