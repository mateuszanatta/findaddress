using AddressService.Models.DTO;

namespace AddressService.GeograficCalculations
{
    public static class GeograficCalculation
    {
        public static double ComputeDistanceFromLatLonInKm(GeographicCoordinates coordinates) {
            var EarthRadiusInKm = 6371;
            var differenceLatitute = DegreesToRadians(coordinates.LatitudeOrigin-coordinates.LatitudeDestiny);
            var differenceLongitude = DegreesToRadians(coordinates.LongitudeOrigin-coordinates.LongitudeDestiny); 
            var a = 
                Math.Sin(differenceLatitute/2) * Math.Sin(differenceLongitude/2) +
                Math.Cos(DegreesToRadians(coordinates.LatitudeDestiny)) * Math.Cos(DegreesToRadians(coordinates.LatitudeOrigin)) * 
                Math.Sin(differenceLongitude/2) * Math.Sin(differenceLongitude/2)
                ; 
            var c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1-a)); 
            var distance = EarthRadiusInKm * c;
            return distance;
        }

        private static double DegreesToRadians(double degree) {
            return degree * (Math.PI/180);
        }
    }
}