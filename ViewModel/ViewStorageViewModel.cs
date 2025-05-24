using System.Collections.ObjectModel;
using Sea_Transportation_Management_System.Model.Interfaces;

namespace Sea_Transportation_Management_System.ViewModel
{
    public class ViewStorageViewModel : ViewModelBase
    {
        public Storage Storage { get; }
        public ObservableCollection<ITransportable> StorageItems { get; }
        public string WeightState { get; }
        public string ItemCountState { get; }
        public ViewStorageViewModel(Storage storage)
        {
            Storage = storage;
            StorageItems = Storage.Items;
            WeightState = $"Weight: {Storage.CurrentWeight}/{Storage.MaxWeightCapacity}";
            ItemCountState = $"Items: {Storage.CurrentItemCount}/{Storage.MaxItemCount}";
        }
    }
}
