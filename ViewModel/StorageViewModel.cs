using Sea_Transportation_Management_System.Model;
using Sea_Transportation_Management_System.Model.Interfaces;
using Sea_Transportation_Management_System.Model.Vessels;

namespace Sea_Transportation_Management_System.ViewModel
{
    public class StorageViewModel
    {
        public object CurrentView { get; set; }
        public StorageViewModel(ICargo storagable)
        {
            if (storagable is Vessel)
                CurrentView = new VesselStorageViewModel(storagable);
            else if (storagable is Port)
                CurrentView = new PortStorageViewModel(storagable);
        }
    }
}
