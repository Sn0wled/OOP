namespace TransportManagementSystem;
public class Dispatcher : User {

    public Dispatcher(string name) : base(name) { }

    public override void ShowObject()
    {
        Console.WriteLine("Диспетчер");
        base.ShowObject();
    }

}