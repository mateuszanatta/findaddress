namespace AddressService.Models.DTO
{
    public class GeographicCoordinates
    {
        public double LatitudeOrigin { get; set; }
        public double LongitudeOrigin { get; set; }
        public double LatitudeDestiny { get; set; }
        public double LongitudeDestiny { get; set; }
        

        public GeographicCoordinates(double latitudeOrigin, double longitudeOrigin, double latitudeDestiny, double longitudeDestiny)
        {
            LatitudeOrigin = latitudeOrigin;
            LongitudeOrigin = longitudeOrigin;
            LatitudeDestiny = latitudeDestiny;
            LongitudeDestiny = longitudeDestiny;
        }
    }
}