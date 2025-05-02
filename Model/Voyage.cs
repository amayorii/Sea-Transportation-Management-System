using Sea_Transportation_Management_System.Model.Vessels;

namespace Sea_Transportation_Management_System.Model
{
    public class Voyage
    {
        public Voyage(int id, Vessel? vessel, Port fromPort, Port toPort, DateTime departureDate, DateTime arrivalDate)
        {
            Id = id;
            VesselId = vessel.Id;
            Vessel = vessel;
            FromPort = fromPort;
            ToPort = toPort;
            DepartureDate = departureDate;
            ArrivalDate = arrivalDate;
            Distance = fromPort.CalculateDistanceTo(toPort);
        }

        public int Id { get; protected set; }
        public int VesselId { get; set; }
        public Vessel? Vessel { get; set; }
        public Port FromPort { get; set; }
        public Port ToPort { get; set; }
        public double Distance { get; set; }
        public DateTime DepartureDate { get; set; }
        public DateTime ArrivalDate { get; set; }
    }
}
