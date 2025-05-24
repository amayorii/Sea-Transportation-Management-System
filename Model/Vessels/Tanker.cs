using System.Text;
using System.Windows;
using Sea_Transportation_Management_System.Model.Interfaces;
using Sea_Transportation_Management_System.Model.Transportable;

namespace Sea_Transportation_Management_System.Model.Vessels
{
    class Tanker : Vessel, ICargo
    {
        public Storage Storage { get; }
        public Tanker(int id, string? name, float fuelCapacity, double maxWeight, int maxItems) : base(id, name, fuelCapacity)
        {
            Storage = new Storage(maxWeight, maxItems);
        }

        public override double CalculateFuelConsumption(double distance)
        {
            if (Storage.CurrentWeight == 0)
                return distance * 1.1;

            return distance * (1.1 + Storage.CurrentWeight / Storage.MaxWeightCapacity / 4);
        }

        public void LoadCargo(ITransportable transportable)
        {
            if (transportable is not Barrel barrel)
            {
                MessageBox.Show("You can only load barrels on this type of vessel");
                return;
            }

            if (Storage.CurrentWeight + barrel.Weight > Storage.MaxWeightCapacity)
            {
                MessageBox.Show($"Weight of barrel \"{barrel.Id}\" exceeds the capacity limit");
                return;
            }
            Storage.AddItem(barrel);
        }

        public void UnloadCargo(ITransportable transportable)
        {
            throw new NotImplementedException();
        }

        public void ViewCargo()
        {
            if (Storage.CurrentItemCount == 0)
                MessageBox.Show("The ship is empty.");

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Cargo of \"{Name}\":");

            foreach (var barrel in Storage.Items)
            {
                sb.AppendLine(barrel.ToString());
            }

            sb.AppendLine($"Total weight: {Storage.CurrentWeight} / {Storage.MaxWeightCapacity}");

            MessageBox.Show(sb.ToString(), "Cargo", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
