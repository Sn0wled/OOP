namespace TransportManagementSystem
{
    internal class Coordinates
    {
        public double Longitude { get; set; }
        public double Latitude { get; set; }

        public Coordinates(double longitude, double latitude)
        {
            Longitude = longitude;
            Latitude = latitude;
        }

        public void Show()
        {
            Console.WriteLine($"Широта: {Latitude}, Долгота {Longitude}");
        }

        public static Coordinates CreateCoords()
        {
            double latitude, longitude;
            Console.WriteLine("Введите координаты");
            latitude = Program.EnterDouble("Введите широту: ");
            longitude = Program.EnterDouble("Введите долготу: ");
            return new Coordinates(longitude, latitude);
        }

        public bool IsEqual(Coordinates c)
        {
            return c.Longitude == Longitude && c.Latitude == Latitude;
        }
    }
}
