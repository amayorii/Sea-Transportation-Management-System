using Sea_Transportation_Management_System.Model.Vessels;

namespace Sea_Transportation_Management_System.Model
{
    public class Voyage
    {
        public Voyage(int id, int vesselId, Vessel? vessel, string? fromPort, string? toPort, DateTime departureDate, DateTime arrivalDate)
        {
            Id = id;
            VesselId = vesselId;
            Vessel = vessel;
            FromPort = fromPort;
            ToPort = toPort;
            DepartureDate = departureDate;
            ArrivalDate = arrivalDate;
        }

        public int Id { get; set; }
        public int VesselId { get; set; }
        public Vessel? Vessel { get; set; }
        public string? FromPort { get; set; }
        public string? ToPort { get; set; }
        public double Distance { get; set; }
        public DateTime DepartureDate { get; set; }
        public DateTime ArrivalDate { get; set; }
    }
}
