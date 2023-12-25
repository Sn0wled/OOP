namespace TransportManagementSystem;
public class TransportationSystem : UniqueObjectSystem {

    public TransportationSystem() {
    }

    public override void ShowObjects()
    {
        Console.WriteLine("Список перевозок:\n");
        base.ShowObjects();
    }

    public override int AddObject(UniqueObject obj)
    {
        if (obj is Transportation) return base.AddObject(obj);
        return -1;
    }

    public int? HasTransportationWithVeh(Vehicle veh, params int[] exceptions)
    {
        int? id = null;
        foreach (Transportation t in uniqueObjectList)
        {
            id = t.HasDTransportationWithVeh(veh);
            if (!exceptions.Any(x => x == id)) return id;
        }
        return null;
    }
}