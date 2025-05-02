namespace Sea_Transportation_Management_System.Model.Interfaces
{
    interface ICargo
    {
        public void LoadCargo(ITransportable transportable);
        public void UnloadCargo(ITransportable transportable);
        public void ViewCargo();
    }
}
