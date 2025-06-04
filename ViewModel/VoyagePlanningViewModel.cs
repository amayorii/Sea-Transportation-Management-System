using Sea_Transportation_Management_System.Model;
using Sea_Transportation_Management_System.Model.Vessels;

namespace Sea_Transportation_Management_System.ViewModel
{
    public class VoyagePlanningViewModel : ViewModelBase
    {
        private string _selectedVessel;
        private Port _fromPort;

        public string SelectedVessel
        {
            get => _selectedVessel;
            set
            {
                _selectedVessel = value;
                OnPropertyChanged(nameof(SelectedVessel));

                if (value != null)
                {
                    Vessel vessel = App.Vessels.First(x => x.Name == value);
                    FromPort = vessel.CurrentPort;
                    Ports = [.. App.Ports.Where(x => x != FromPort).Select(x => x.Name)];
                    OnPropertyChanged(nameof(Ports));
                }
            }
        }

        public Port FromPort
        {
            get => _fromPort;
            set
            {
                _fromPort = value;
                OnPropertyChanged(nameof(FromPort));
                OnPropertyChanged(nameof(FromPortName));
            }
        }
        public string FromPortName => FromPort.Name;

        public List<string> Vessels { get; } = [.. App.Vessels.Where(x => x.Status == VesselStatus.WaitingInPort).Select(x => x.Name)];
        public List<string> Ports { get; private set; } = [];
    }

}
