namespace Sea_Transportation_Management_System.Model.Interfaces
{
    public interface ICargo
    {
        Storage Storage { get; }
        public void LoadCargo(ITransportable transportable);
        public void UnloadCargo(ITransportable transportable);
        public void ViewCargo();
    }
}
