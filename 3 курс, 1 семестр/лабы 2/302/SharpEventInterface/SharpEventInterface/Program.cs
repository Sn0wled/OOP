using System.Security.Cryptography;

internal class Program
{
    private static void Main(string[] args)
    {
        IEventInterface IE = new TestEventInterface();
        IE.Changed += Handler!;
        IE.FireEvent(EventArgs.Empty);
        (IE as TestEventInterface)?.ChangeData();
    }
    static void Handler(object sender, EventArgs e)
    {
        Console.WriteLine("Event Fired");
    }
}

interface IEventInterface
{
    event EventHandler Changed;
    void FireEvent(EventArgs e);
}

class TestEventInterface : IEventInterface
{
    public event EventHandler Changed;

    public void FireEvent(EventArgs e)
    {
        Changed?.Invoke(this, e);
    }
    public void ChangeData()
    {
        FireEvent(EventArgs.Empty);
    }
}