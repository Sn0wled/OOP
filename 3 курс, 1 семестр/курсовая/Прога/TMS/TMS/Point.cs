namespace TransportManagementSystem;
public class Point {

    public Point(Coordinates coords, string name) {
        this.name = name;
        this.coords = coords;
    }

    protected string name;

    protected Coordinates coords;

    public bool IsPoint(Coordinates coords) {
        return this.coords.Equals(coords);
    }
    public void ShowInfo()
    {
        Console.Write($"\"{name}\", ");
        coords.ShowInfo();
    }
}