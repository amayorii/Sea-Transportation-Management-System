using System.Collections.ObjectModel;
using Sea_Transportation_Management_System.Model;
using Sea_Transportation_Management_System.Model.Interfaces;
using Sea_Transportation_Management_System.Model.Vessels;

namespace Sea_Transportation_Management_System.ViewModel;

public class VesselStorageViewModel : ViewModelBase
{
    public Storage Storage { get; set; }
    public Vessel Vessel { get; set; }
    public bool InPort => Vessel.Status == VesselStatus.WaitingInPort;
    public ReadOnlyObservableCollection<ITransportable> StorageItems => Storage.Items;
    public double CurrentWeight => Storage.CurrentWeight;
    public int CurrentItemCount => Storage.CurrentItemCount;
    public VesselStorageViewModel() { }
    public VesselStorageViewModel(IStoragable storagable)
    {
        Vessel = storagable as Vessel;
        Storage = storagable.Storage;
        Vessel.PropertyChanged += (s, e) =>
        {
            if (e.PropertyName == nameof(Vessel.Status))
                OnPropertyChanged(nameof(InPort));
        };
    }
}
