namespace Sea_Transportation_Management_System.Model.Interfaces
{
    interface ICargo
    {
        public void LoadCargo(ITransportable weight);
        public void UnloadCargo(ITransportable weight);
        public void ViewCargo();
    }
}
