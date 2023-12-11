namespace TransportSystem;

class Driver : User
{
    Transport? Transport {  get; set; }
    Status status;
    public Status Status { get { return status; } }

    public Driver(string login, string password, int userID, string fName = "Unknown", string sName = "Unknown", string? pName = null , Transport? transport = null) :
        base(login, password, userID, fName, sName, pName) 
    { 
        Transport = transport;
        status = Status.Free;
    }

    public void ChangeStatus(Status status) => this.status = status;
}
