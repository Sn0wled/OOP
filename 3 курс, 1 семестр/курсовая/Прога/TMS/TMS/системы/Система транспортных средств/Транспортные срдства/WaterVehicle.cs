namespace TransportManagementSystem;
public class WaterVehicle : Vehicle {

    public WaterVehicle(string name) : base(name) {
    }

    public override void ShowObject()
    {
        base.ShowObject();
        Console.WriteLine("Тип: Водный транспорт");
    }

    public override void Move(Coordinates coords)
    {
        Console.WriteLine($"Плывем");
        coords.ShowInfo();
        base.Move(coords);
    }

}