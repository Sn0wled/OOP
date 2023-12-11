namespace TransportSystem;

class Coords
{
    public double Latitude { get; init; }
    public double Longitude { get; init; }
    public Coords(double latitude, double longtitude) {  Latitude = latitude; Longitude = longtitude; }

    public  bool Equals(Coords obj)
    {
        return obj.Latitude == Latitude && obj.Longitude == Longitude;
    }
}
