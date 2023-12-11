namespace TransportSystem;

class Dispatcher : User
{
    public Dispatcher(string login, string password, int userID, string fName = "Unknown", string sName = "Unknown", string? pName = null) :
        base(login, password, userID, fName, sName, pName) { }
}