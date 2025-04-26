namespace Sea_Transportation_Management_System.Model.Vessels;
public enum VesselType
{
    ContainerVessel,
    Tanker,
    PassengerVessel
}
public enum VesselStatus
{
    Unknown,
    WaitingInPort,
    OnVoyage
}
public class Vessel
{
    public int Length { get; protected set; }
    public int Width { get; protected set; }
    public int Height { get; protected set; }
    public float Capacity { get; protected set; }
    public float Fuel { get; protected set; }
    public VesselType Type { get; protected set; }
    public VesselStatus Status { get; protected set; }

}
