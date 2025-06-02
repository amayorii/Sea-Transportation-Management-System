namespace Sea_Transportation_Management_System.ViewModel
{
    public class VoyagePlanningViewModel : ViewModelBase
    {
        public List<string> Vessels { get; set; } = [.. App.Vessels.Select(x => x.Name)];
        public List<string> Ports { get; set; } = [.. App.Ports.Select(x => x.Name)];
    }
}
