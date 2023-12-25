namespace TransportManagementSystem;
public class Coordinates {

    public Coordinates(double longitude, double latitude) {
        this.longitude = longitude;
        this.latitude = latitude;
    }

    protected double latitude;

    protected double longitude;

    public void ShowInfo()
    {
        Console.WriteLine($"Широта: {latitude}, Долгота: {longitude}");
    }

}