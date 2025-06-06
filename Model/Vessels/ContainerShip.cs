﻿using Sea_Transportation_Management_System.Model.Interfaces;
using Sea_Transportation_Management_System.Model.Transportable;

namespace Sea_Transportation_Management_System.Model.Vessels
{
    public class ContainerShip : Vessel, ICargo
    {
        public Storage Storage { get; set; } = new Storage(700, 30);

        public ContainerShip() : base()
        {
            _typeOfTransportable = typeof(Container);
        }
        public ContainerShip(int id, string? name, float fuelCapacity, Port currentPort, double maxWeight, int maxItems) : base(id, name, fuelCapacity, currentPort)
        {
            Storage = new Storage(maxWeight, maxItems);
            _typeOfTransportable = typeof(Container);
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
                throw new Exception("You can only load containers on this type of vessel");
            }

            if (Storage.CurrentWeight + container.Weight > Storage.MaxWeightCapacity)
            {
                throw new Exception($"Weight of container \"{container.ContainerSign}\" exceeds the capacity limit");
            }
            else if (Storage.CurrentItemCount == Storage.MaxItemCount)
            {
                throw new Exception($"Container \"{container.ContainerSign}\" is full");
            }
            Storage.AddItem(container);
        }

        public void UnloadCargo(ITransportable cont)
        {
            Storage.RemoveItem(cont);
            OnPropertyChanged(nameof(Storage));
        }
    }
}
