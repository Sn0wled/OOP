namespace TransportManagementSystem;
public class RailwayVehicle : Vehicle {

    public RailwayVehicle(string name) : base(name) {
    }

    public override void ShowObject()
    {
        base.ShowObject();
        Console.WriteLine("���: ��������������� ���������");
    }

    public override void Move(Coordinates coords)
    {
        Console.WriteLine($"���� �� �������");
        coords.ShowInfo();
        base.Move(coords);
    }

}