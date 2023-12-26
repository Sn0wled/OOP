namespace TransportSystem;

class User
{
    public User(string login, string password, int userID, string fName = "Unknown", string sName = "Unknown", string? pName = null)
    {
        Login = login;
        Password = password;
        FName = fName;
        SName = sName;
        PName = pName;
        UserID = userID;
    }
    public string Login { get; set; }
    public string Password { get; set; }
    public string FName { get; set; }
    public string SName { get; set; }
    public string? PName { get; set; }
    public int UserID { get; init; }
    public bool CheckPassword(string password) => password.Equals(Password);
}