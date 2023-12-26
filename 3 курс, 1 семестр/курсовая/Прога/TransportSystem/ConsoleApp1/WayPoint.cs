namespace TransportSystem;

class WayPoint : Point
{
    public string Task { get; set; }
    bool visited = false;
    bool Visited { get {  return visited; } }
    public WayPoint(Point p, string task) : 
        base(p.Latitude, p.Longitude, p.Name, p.Adress)
    {
        Task = task;
    }
    public void Visit()
    {
        visited = true;
    }
}