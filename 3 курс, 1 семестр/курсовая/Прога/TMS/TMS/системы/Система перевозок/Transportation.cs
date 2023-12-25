namespace TransportManagementSystem;
public class Transportation : UniqueObject
{

    public Transportation(string name)
    {
        this.name = name;
        Status = Status.NotStarted;
        dTList = new();
    }

    protected string name;

    protected List<DirectTransportation> dTList;

    public Status Status { get; protected set; }

    public override void ShowObject()
    {
        Console.WriteLine($"Перевозка \"{name}\"\n");
        base.ShowObject();
        Console.WriteLine($"\nСтатус: {Status}\n");
        Console.WriteLine($"\n{string.Concat(Enumerable.Repeat("-", 20))}\n"); // разделитель
        for (int i = 0; i < dTList.Count; i++)
        {
            Console.WriteLine($"Часть {i + 1}");
            dTList[i].ShowInfo();
            Console.WriteLine($"\n{string.Concat(Enumerable.Repeat("-", 20))}\n"); // разделитель
        }
        if (dTList.Count == 0)
        {
            Console.WriteLine("Перевозка пуста\n");
        }
    }
    public bool StartTransportation()
    {
        if (dTList.Count == 0)
        {
            return false;
        }
        else
        {
            Status = Status.Started;
            dTList.First().IssueDT();
            return true;
        }
    }

    // Возвращает true, если перевозка отменена
    // false, если перевозка уже завершена или еще на начата
    public bool Cancel()
    {
        if (Status == Status.Started)
        {
            dTList.Find(x => x.Status == Status.Started)?.Cancel();
            while (DelLastDT()) ;
            return true;
        }
        return false;
    }

    public bool IsEmpty()
    {
        return dTList.Count == 0;
    }

    public Point? GetLastPoint()
    {
        if (IsEmpty())
        {
            return null;
        }
        else
        {
            return dTList.Last().EndPoint;
        }
    }

    public int? HasDTransportationWithVeh(Vehicle veh)
    {
        if (dTList.Find(x => x.Vehicle == veh) is not null) return ID;
        return null;
    }

    public bool AddToEndDT(DirectTransportation dT)
    {
        if (Status == Status.Finished || Status == Status.Canceled)
        {
            return false;
        }
        dTList.Add(dT);
        return true;
    }

    public bool DelLastDT()
    {
        if (dTList.Count == 0 || dTList.Last().Status != Status.NotStarted)
        {
            return false;
        }
        else
        {
            dTList.RemoveAt(dTList.Count - 1);
            if (dTList.Count == 0) return true;
            if (dTList.Last()?.Status == Status.Finished)
            {
                Status = Status.Finished;
            }
            else if (dTList.Last().Status == Status.Canceled)
            {
                Status = Status.Canceled;
            }
            return true;
        }
    }

    public void StartNextDT()
    {
        DirectTransportation? dt = dTList.Find(x => x.Status == Status.NotStarted);
        if (dt != null)
        {
            dt.IssueDT();
        }
        else
        {
            Status = Status.Finished;
        }
    }
}