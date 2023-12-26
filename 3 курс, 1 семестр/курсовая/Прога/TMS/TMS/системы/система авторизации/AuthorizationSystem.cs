namespace TransportManagementSystem;
public class AuthorizationSystem : UniqueObjectSystem
{
    public override int AddObject(UniqueObject obj)
    {
        if (obj is User)
        {
            return base.AddObject(obj);
        }
        return -1;
    }

    public override void ShowObjects()
    {
        Console.WriteLine("Список пользователей:\n");
        base.ShowObjects();
    }

    public void ShowDrivers()
    {
        Console.WriteLine("Список водителей:\n");
        int counter = 0;
        foreach (UniqueObject obj in uniqueObjectList)
        {
            if (obj is Driver)
            {
                obj.ShowObject();
                Console.WriteLine();
                counter++;
            }
        }
        if (counter == 0) 
        {
            Console.WriteLine("Список пуст\n");
        }
    }
}
