using Sea_Transportation_Management_System.Model;
using Sea_Transportation_Management_System.Model.Interfaces;

namespace Sea_Transportation_Management_System.ViewModel;

public class VesselStorageViewModel : ViewModelBase
{
    public Storage Storage { get; set; }
    public VesselStorageViewModel() { }
    public VesselStorageViewModel(ICargo storagable)
    {
        Storage = storagable.Storage;
    }
}
