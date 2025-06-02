namespace Sea_Transportation_Management_System.ViewModel
{
    public class RegisterVesselViewModel : ViewModelBase
    {
        public List<string> Ports { get; set; } = [.. App.Ports.Select(x => x.Name)];
        public List<string> Types { get; } = ["ContainerShip", "Tanker", "PassengerShip"];

        public RegisterVesselViewModel() { }
    }
}
