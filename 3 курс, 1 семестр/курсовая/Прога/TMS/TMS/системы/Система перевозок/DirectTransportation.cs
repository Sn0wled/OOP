namespace TransportManagementSystem;
public class DirectTransportation {

    public DirectTransportation(Point start, Point end, Vehicle executor, Transportation transportation) {
        startPoint = start;
        EndPoint = end;
        Vehicle = executor;
        this.transportation = transportation;
    }

    protected Point startPoint;

    public Point EndPoint { get; init; }

    public Status Status { get; private set; } = Status.NotStarted;

    public Vehicle Vehicle { get; protected set; }

    protected Transportation transportation;

    public void ShowInfo() {
        Console.WriteLine($"Статус: {Status}\n");
        Console.Write($"Начальная точка: ");
        startPoint.ShowInfo();
        Console.Write($"\nКонечная точка: ");
        EndPoint.ShowInfo();
        Console.WriteLine("\nИсполняющее транспортное средство:");
        Vehicle.ShowObject();
    }

    public void IssueDT()
    {
        Vehicle.DTransportation = this;
    }

    public void Cancel() {
        Vehicle.DTransportation = null;
        Status = Status.Canceled;
    }

    public bool TryStart(Coordinates coords)
    {
        if (startPoint.IsPoint(coords) && Status == Status.NotStarted)
        {
            Status = Status.Started;
            Console.WriteLine("Перевозка началась\n");
            return true;
        }
        return false;
    }

    public bool TryEnd(Coordinates coords)
    {
        if (EndPoint.IsPoint(coords))
        {
            Status = Status.Finished;
            Console.WriteLine("Перевозка закончилась\n");
            transportation.StartNextDT();
            Vehicle.DTransportation = null;
            return true;
        }
        return false;
    }

}