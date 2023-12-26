namespace TransportManagementSystem
{
    internal class Coordinates
    {
        protected double longtitude;
        protected double latitude;

        public Coordinates(double longtitude, double latitude)
        {
            this.longtitude = longtitude;
            this.latitude = latitude;
        }

        public double Longtitude
        {
            get
            {
                return longtitude;
            }
            set
            {
                longtitude = value;
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
            longtitude = c.longtitude;
            latitude = c.latitude;
        }
    }
}
