namespace TransportManagementSystem;
public class Aircraft : Vehicle {

    public Aircraft(string name) : base(name) {
    }

    public override void ShowObject() {
        base.ShowObject();
        Console.WriteLine("���: ��������� �����");
    }

    public override void Move(Coordinates coords) {
        Console.WriteLine($"����� �� ����������:");
        coords.ShowInfo();
        base.Move(coords);
    }

}