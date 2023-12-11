namespace TransportSystem;
class Point : Coords
{
    public string? Name { get; set; }
    public string? Adress { get; set; }
    public Point(double latitude, double longtitude, string? name = null, string? adress = null) : base (latitude, longtitude) { 
        Name = name; 
        Adress = adress;
    }

}
