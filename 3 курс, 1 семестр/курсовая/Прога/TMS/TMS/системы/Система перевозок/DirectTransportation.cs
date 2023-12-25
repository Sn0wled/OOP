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
        Console.WriteLine($"������: {Status}\n");
        Console.Write($"��������� �����: ");
        startPoint.ShowInfo();
        Console.Write($"\n�������� �����: ");
        EndPoint.ShowInfo();
        Console.WriteLine("\n����������� ������������ ��������:");
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
            Console.WriteLine("��������� ��������\n");
            return true;
        }
        return false;
    }

    public bool TryEnd(Coordinates coords)
    {
        if (EndPoint.IsPoint(coords))
        {
            Status = Status.Finished;
            Console.WriteLine("��������� �����������\n");
            transportation.StartNextDT();
            Vehicle.DTransportation = null;
            return true;
        }
        return false;
    }

}