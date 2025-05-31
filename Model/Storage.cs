using System.Collections.ObjectModel;
using System.ComponentModel;
using Sea_Transportation_Management_System.Model.Interfaces;

namespace Sea_Transportation_Management_System.Model
{
    public class Storage : INotifyPropertyChanged
    {
        private readonly ObservableCollection<ITransportable> _items;

        public event PropertyChangedEventHandler? PropertyChanged;

        public ReadOnlyObservableCollection<ITransportable> Items { get; }
        public double MaxWeightCapacity { get; }
        public int MaxItemCount { get; }

        public double CurrentWeight => Items.Sum(i => i.Weight);
        public int CurrentItemCount => Items.Count;

        public Storage(double maxWeightCapacity, int maxItemCount)
        {
            MaxWeightCapacity = maxWeightCapacity;
            MaxItemCount = maxItemCount;
            _items = [];
            Items = new ReadOnlyObservableCollection<ITransportable>(_items);
        }

        public void AddItem(ITransportable item)
        {
            if (CurrentWeight + item.Weight <= MaxWeightCapacity && item != null)
            {
                _items.Add(item);
                OnPropertyChanged(nameof(CurrentWeight));
                OnPropertyChanged(nameof(CurrentItemCount));
            }
        }

        public void RemoveItem(ITransportable item)
        {
            _items.Remove(item);
            OnPropertyChanged(nameof(CurrentWeight));
            OnPropertyChanged(nameof(CurrentItemCount));
        }
        protected void OnPropertyChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Items)));
        }
    }
}
