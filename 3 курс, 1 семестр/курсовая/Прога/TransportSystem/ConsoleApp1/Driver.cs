namespace TransportSystem;

class Driver : User
{
    public Transport? Transport {  get; set; }
    public Route? Route { get; set; }
    public Status status;
    public Status Status { get { return status; } }
    PointList.IEnumerator? points = null;
    Point? nextPoint = null;
    public void GetNextPoint()
    {
        if (points == null) points = Route.GetEnumerator();
    }

    public Driver(string login, string password, int userID, string fName = "Unknown", string sName = "Unknown", string? pName = null , Transport? transport = null) :
        base(login, password, userID, fName, sName, pName) 
    { 
        Transport = transport;
        status = Status.Free;
    }
    void MarkWayPoint()
    {
        if (Transport == null) return;
        if (Route == null) return;
        Point? point = Route.Last();
        if (point == null)
        {
            status = Status.Free;
            return;
        }
        if (point.Equals(Route.Last())) { }
    }

    public void ChangeStatus(Status status) => this.status = status;
}
