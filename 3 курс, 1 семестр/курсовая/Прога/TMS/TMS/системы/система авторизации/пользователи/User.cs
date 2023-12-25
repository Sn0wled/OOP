namespace TransportManagementSystem;
public abstract class User : UniqueObject
{
    public User(string name)
    {
        this.name = name;
    }

    protected string name;

    public override void ShowObject()
    {
        base.ShowObject();
        Console.WriteLine($"Имя пользователя: {name}");
    }
}
