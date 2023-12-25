namespace TransportManagementSystem;
public abstract class Vehicle : UniqueObject {

    public Vehicle(string name) {
        this.name = name;
        coords = new(0, 0);
    }

    protected string name;

    protected Coordinates coords;

    public Driver? Driver { get; set; }

    public DirectTransportation? DTransportation { get; set; }

    public override void ShowObject()
    {
        Driver?.ShowObject();
        Console.WriteLine("\n��");
        base.ShowObject();
        Console.WriteLine($"������: {name}");
        Console.WriteLine("����������:");
        coords.ShowInfo();
    }

    public virtual void Move(Coordinates coords)
    {
        this.coords = coords;
        Console.WriteLine("�� �������");
        DTransportation?.TryStart(coords);
        DTransportation?.TryEnd(coords);
    }
}
