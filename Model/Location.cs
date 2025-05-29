namespace Sea_Transportation_Management_System.Model
{
    public class Location
    {
        private double latitude;
        private double longitude;

        public Location(double latitude, double longitude)
        {
            Latitude = latitude;
            Longitude = longitude;
        }

        public double Latitude { get { return latitude; } set { latitude = value; } }
        public double Longitude { get { return longitude; } set { longitude = value; } }

    }
}
