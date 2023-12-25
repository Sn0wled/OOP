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

    public override void ShowObject() {
        base.ShowObject();
        Console.WriteLine($"Модель: {name}");
        if ( Driver != null )
        {
            Driver.ShowObject();
        }
    }

    public virtual void Move(Coordinates coords)
    {
        this.coords = coords;
        Console.WriteLine("Вы прибыли");
        DTransportation?.TryStart(coords);
        DTransportation?.TryEnd(coords);
    }
}
