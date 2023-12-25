namespace TransportManagementSystem;
public abstract class Vehicle : UniqueObject {

    public Vehicle(string name) {
        this.name = name;
        Coords = new(0, 0);
    }

    protected string name;

    public Coordinates Coords { get; protected set; }

    public Driver? Driver { get; set; }

    public DirectTransportation? DTransportation { get; set; }

    public override void ShowObject()
    {
        Driver?.ShowObject();
        Console.WriteLine("\n��");
        base.ShowObject();
        Console.WriteLine($"������: {name}");
        Console.WriteLine("����������:");
        Coords.ShowInfo();
    }

    public virtual void Move(Coordinates coords)
    {
        this.Coords = coords;
        Console.WriteLine("�� �������");
        DTransportation?.TryStart(coords);
        DTransportation?.TryEnd(coords);
    }
}
