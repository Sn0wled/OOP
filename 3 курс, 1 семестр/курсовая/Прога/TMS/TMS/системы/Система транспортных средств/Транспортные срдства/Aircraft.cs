namespace TransportManagementSystem;
public class Aircraft : Vehicle {

    public Aircraft(string name) : base(name) {
    }

    public override void ShowObject() {
        base.ShowObject();
        Console.WriteLine("Тип: Воздушное судно");
    }

    public override void Move(Coordinates coords) {
        Console.WriteLine($"Летим на координаты:");
        coords.ShowInfo();
        base.Move(coords);
    }

}