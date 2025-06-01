using System.Collections.ObjectModel;
using Sea_Transportation_Management_System.Model;
using Sea_Transportation_Management_System.Model.Interfaces;

namespace Sea_Transportation_Management_System.ViewModel;

public class PortStorageViewModel : ViewModelBase
{
    public Storage Storage { get; set; }
    public Port Port { get; set; }
    public ReadOnlyObservableCollection<ITransportable> StorageItems => Storage.Items;
    public double CurrentWeight => Storage.CurrentWeight;
    public int CurrentItemCount => Storage.CurrentItemCount;
    public PortStorageViewModel() { }
    public PortStorageViewModel(IStoragable storagable)
    {
        Port = (Port)storagable;
        Storage = storagable.Storage;
    }
}
