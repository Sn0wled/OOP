namespace TransportSystem;
class TransportSystem
{
    internal UserList userList = new();
    internal TransportList transportList = new();
    public User? LogIn(in string login, in string password)
    {
        User? user = userList.FindUser(login);
        if (user is not null && user.CheckPassword(password)) return user;
        return null;
    }
    public void TestUser()
    {
        userList.AddUser(new Administrator("Суетолог", "OralCumshot", userList.Length, this, "Сафин", "Михаил", "Камшотович"));
    }
}