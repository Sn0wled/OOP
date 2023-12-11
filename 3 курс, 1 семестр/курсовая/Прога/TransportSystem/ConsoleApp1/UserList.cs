namespace TransportSystem;

class UserList : IEnumerable
{
    int counter = 0;
    public int Length {  get => counter; }
    List<User> users = new();
    public IEnumerator GetEnumerator() => users.GetEnumerator();

    public User? FindUser(string login)
    {
        return users.Find(user => user.Login == login);
    }

    public User? FindUserAtID(int userID)
    {
        return users.Find(user => user.UserID.Equals(userID));
    }

    public void AddUser(User user)
    {
        users.Add(user);
        counter++;
    }
    public void DeleteUser(User user)
    {
        users.Remove(user);
    }
}
