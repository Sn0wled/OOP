namespace TransportManagementSystem
{
    internal class WayPoint : Point
    {
        bool checkbox;
        public WayPoint(Point point)
            : base(point)
        {
            checkbox = false;
        }
        public void ShowPoint()
        {
            string state = checkbox == true ? "Пройдена" : "Не пройдена";
            Console.WriteLine($"Название: {name}");
            Console.WriteLine($"Широта: {coords.Longtitude}, Долгота: {coords.Latitude}");
            Console.WriteLine($"Состояние: {state}");
        }

        public bool HasCoords(double longitude, double latitude)
        {
            return coords.Longtitude == longitude && coords.Latitude == latitude;
        }

        public bool IsMarked() { return checkbox; }

        public void Mark()
        {
            checkbox = true;
        }

        public void Unmark()
        {
            checkbox = false;
        }
    }
}
