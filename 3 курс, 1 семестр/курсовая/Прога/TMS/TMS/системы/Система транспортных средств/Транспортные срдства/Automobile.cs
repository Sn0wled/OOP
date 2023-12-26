namespace TransportManagementSystem;
public class Automobile : Vehicle {

    public Automobile(string name) : base(name) {
    }

    public override void ShowObject()
    {
        base.ShowObject();
        Console.WriteLine("Тип: Автомобиль");
    }

    public override void Move(Coordinates coords)
    {
        Console.WriteLine($"Едем по дороге:");
        coords.ShowInfo();
        base.Move(coords);
    }

}