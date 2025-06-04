namespace Sea_Transportation_Management_System.Model.Interfaces
{
    public interface ICargo : IStoragable
    {
        public void LoadCargo(ITransportable transportable);
        public void UnloadCargo(ITransportable transportable);
    }
}
