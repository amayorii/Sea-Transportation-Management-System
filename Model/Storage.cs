using System.Collections.ObjectModel;
using Sea_Transportation_Management_System.Model.Interfaces;

namespace Sea_Transportation_Management_System.Model
{
    public class Storage
    {
        public ObservableCollection<ITransportable> Items { get; }
        public double MaxWeightCapacity { get; }
        public int MaxItemCount { get; }

        public double CurrentWeight => Items.Sum(i => i.Weight);
        public int CurrentItemCount => Items.Count;

        public Storage(double maxWeightCapacity, int maxItemCount)
        {
            MaxWeightCapacity = maxWeightCapacity;
            MaxItemCount = maxItemCount;
            Items = [];
        }

        public void AddItem(ITransportable item)
        {
            if (CurrentWeight + item.Weight <= MaxWeightCapacity && item != null)
            {
                Items.Add(item);
            }
        }

        public void RemoveItem(ITransportable item)
        {
            Items.Remove(item);
        }
    }
}
