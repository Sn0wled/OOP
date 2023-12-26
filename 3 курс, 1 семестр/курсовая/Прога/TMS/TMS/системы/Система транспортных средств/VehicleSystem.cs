namespace TransportManagementSystem;
public class VehicleSystem : UniqueObjectSystem {

    public VehicleSystem() {
    }
    public override int AddObject(UniqueObject obj)
    {
        if (obj is Vehicle)
        {
            return base.AddObject(obj);
        }
        return -1;
    }

    public override void ShowObjects()
    {
        Console.WriteLine("Список транспортных средств:\n");
        base.ShowObjects();
    }

}