namespace TransportManagementSystem;
public class RailwayVehicle : Vehicle {

    public RailwayVehicle(string name) : base(name) {
    }

    public override void ShowObject()
    {
        base.ShowObject();
        Console.WriteLine("Тип: Железнодорожный транспорт");
    }

    public override void Move(Coordinates coords)
    {
        Console.WriteLine($"Едем по рельсам");
        coords.ShowInfo();
        base.Move(coords);
    }

}