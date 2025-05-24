using MapControl;

namespace Sea_Transportation_Management_System.Model
{
    public static class GeoLocator
    {
        private const double EarthRadiusKm = 6371.0;
        private const double NauticalMileToKm = 1.852;

        public static bool IsWithinRadius(Location location1, Location location2, double radiusNauticalMiles)
        {
            double radiusKm = radiusNauticalMiles * NauticalMileToKm;

            double lat1 = DegreesToRadians(location1.Latitude);
            double lon1 = DegreesToRadians(location1.Longitude);
            double lat2 = DegreesToRadians(location2.Latitude);
            double lon2 = DegreesToRadians(location2.Longitude);

            double dLat = lat2 - lat1;
            double dLon = lon2 - lon1;

            double a = Math.Sin(dLat / 2) * Math.Sin(dLat / 2) +
                       Math.Cos(lat1) * Math.Cos(lat2) *
                       Math.Sin(dLon / 2) * Math.Sin(dLon / 2);

            double c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
            double distanceKm = EarthRadiusKm * c;

            return distanceKm <= radiusKm;
        }

        private static double DegreesToRadians(double degrees)
        {
            return degrees * Math.PI / 180;
        }
    }
}