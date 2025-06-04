using Sea_Transportation_Management_System.Model.Vessels;

namespace Sea_Transportation_Management_System.Model
{
    public class Voyage
    {
        public Voyage(int id, string name, Vessel vessel, Port fromPort, Port toPort, DateTime departureDate, DateTime arrivalDate)
        {
            Id = id;
            Name = name;
            VesselId = vessel.Id;
            Vessel = vessel;
            FromPort = fromPort;
            ToPort = toPort;
            DepartureDate = departureDate;
            ArrivalDate = arrivalDate;
            Distance = fromPort.CalculateDistanceTo(toPort);
            if (vessel.CalculateFuelConsumption(Distance) > vessel.Fuel)
                throw new Exception("Not enough fuel for this voyage.");
            Vessel.Status = VesselStatus.OnVoyage;
        }

        public int Id { get; protected set; }
        public string Name { get; protected set; }
        public int VesselId { get; set; }
        public Vessel Vessel { get; set; }
        public Port FromPort { get; set; }
        public Port ToPort { get; set; }
        public double Distance { get; set; }
        public DateTime DepartureDate { get; set; }
        public DateTime ArrivalDate { get; set; }
    }
}
