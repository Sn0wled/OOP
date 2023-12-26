namespace TransportSystem;

class Transport
{
    public int TransportID { get; init; }

    public void Drive(Coords coords) => Coords = coords;

    public Coords Coords { get; set; } = new Coords(0, 0);

    public Transport(int transportID) {
        TransportID = transportID; 
    }
}