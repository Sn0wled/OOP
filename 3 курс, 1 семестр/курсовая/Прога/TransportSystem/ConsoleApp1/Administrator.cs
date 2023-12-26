namespace TransportSystem;

class Administrator : User
{
    public delegate void AddUser(string login, string password, string fName, string sName, string? pName);
    public AddUser addDispatcher;
    public AddUser addAdmin;
    public AddUser addDriver;
    TransportSystem tSystem;
    public Administrator(string login, string password, int userID, TransportSystem tSystem, string fName = "Unknown", string sName = "Unknown", string? pName = null) :
        base(login, password, userID, fName, sName, pName)
    { 
        this.tSystem = tSystem;
        addDispatcher = AddDispatcher;
        addAdmin = AddAdmin;
        addDriver = AddDriver;
    }

    public void AddAdmin(string login, string password, string fName = "Unknown", string sName = "Unknown", string? pName = null)
    {
        int userID = tSystem.userList.Length;
        tSystem.userList.AddUser(new Administrator(login, password, userID, tSystem, fName, sName, pName));
    }

    public void AddDispatcher( string login, string password, string fName = "Unknown", string sName = "Unknown", string? pName = null)
    {
        int userID = tSystem.userList.Length;
        tSystem.userList.AddUser(new Dispatcher(login, password, userID, fName, sName, pName));
    }

    public void AddDriver( string login, string password, string fName = "Unknown", string sName = "Unknown", string? pName = null)
    {
        tSystem.userList.AddUser(new Driver(login, password, tSystem.userList.Length, fName, sName, pName));
    }

    public bool DeleteUser(int userID)
    {
        User? user = tSystem.userList.FindUserAtID(userID);
        if (user != null)
        {
            tSystem.userList.DeleteUser(user);
            return true;
        }    
        else
        {
            return false;
        }
    }

    public void AddTransport()
    {
        tSystem.transportList.AddTransport(new Transport(tSystem.transportList.Length));
    }

    public bool DeleteTransport(int tID)
    {
        Transport? t = tSystem.transportList.FindTransport(tID);
        if (t != null)
        {
            tSystem.transportList.DeleteTransport(t);
            return true;
        }
        else
        {
            return false;
        }
    }

    public void EditUser(User user, string? login = null, string? password = null, string? fName = null, string? sName = null, string? pName = null)
    {
        if (login is not null) user.Login = login;
        if (password is not null) user.Password = password;
        if (fName is not null) user.FName = fName;
        if (sName is not null) user.SName = sName;
        if (PName is not null) user.PName = pName;
    }
    /*public UserList GetUsers ()
    {

    }*/
}
