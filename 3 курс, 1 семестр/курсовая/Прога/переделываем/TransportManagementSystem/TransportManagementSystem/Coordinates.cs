namespace TransportManagementSystem
{
    internal class Coordinates
    {
        protected double longitude;
        protected double latitude;

        public Coordinates(double longitude, double latitude)
        {
            this.longitude = longitude;
            this.latitude = latitude;
        }

        public double Longitude
        {
            get
            {
                return longitude;
            }
            set
            {
                longitude = value;
            }
        }

        public double Latitude
        {
            get
            {
                return latitude;
            }
            set
            {
                latitude = value;
            }
        }

        public Coordinates(Coordinates c)
        {
            longitude = c.longitude;
            latitude = c.latitude;
        }
    }
}
