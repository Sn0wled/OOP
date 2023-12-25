namespace TransportManagementSystem;
public class Driver : User
{
    public Driver(string name) : base(name)
    {
    }

    public Vehicle? Vehicle { get; set; }

    public override void ShowObject()
    {
        Console.WriteLine("Водитель");
        base.ShowObject();
    }

    public void Move(double longitude, double latitude)
    {
        Vehicle?.Move(new Coordinates(longitude, latitude));
    }
}
