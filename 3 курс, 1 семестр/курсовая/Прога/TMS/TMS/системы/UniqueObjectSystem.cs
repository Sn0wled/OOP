namespace TransportManagementSystem;
public abstract class UniqueObjectSystem {

    public UniqueObjectSystem() {
        uniqueObjectList = new();
        counter = 0;
    }

    protected List<UniqueObject> uniqueObjectList;

    protected int counter;

    public virtual int AddObject(UniqueObject obj) {
        obj.ID = counter;
        uniqueObjectList.Add(obj);
        return counter++;
    }

    public bool DelObject(int id) {
        UniqueObject? obj = FindObject(id);
        if (obj != null)
        {
            uniqueObjectList.Remove(obj);
            return true;
        }
        return false;
    }

    public UniqueObject? FindObject(int id) {
        return uniqueObjectList.Find(x => x.ID == id);
    }

    public virtual void ShowObjects()
    {
        if (uniqueObjectList.Count > 0)
        {
            foreach (UniqueObject obj in uniqueObjectList)
            {
                obj.ShowObject();
                Console.WriteLine($"\n{string.Concat(Enumerable.Repeat("-", 20))}\n"); // разделитель
            }
        }
        else
        {
            Console.WriteLine("Список пуст\n");
        }
    }

}