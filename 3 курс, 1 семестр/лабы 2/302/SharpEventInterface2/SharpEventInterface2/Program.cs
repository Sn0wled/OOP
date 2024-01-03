delegate void SampleEventHandler(string s);
internal class Program
{
    private static void Main(string[] args)
    {
        TestTwoEvents test = new();
        (test as IEvents1).SampleEvent += Handler;
        (test as IEvents2).SampleEvent += Handler2;
        test.FireEvents();
    }
    public static void Handler(object? sender, EventArgs e)
    {
        Console.WriteLine("IEvents1.SampleEvent Fired");
    }
    public static void Handler2(string s)
    {
        Console.WriteLine(s);
    }
}

interface IEvents1
{
    event EventHandler SampleEvent;
}

interface IEvents2
{
    event SampleEventHandler SampleEvent;
}

class TestTwoEvents : IEvents1, IEvents2
{
    public event EventHandler SampleEvent;

    private SampleEventHandler SampleEventStorage;

    event SampleEventHandler IEvents2.SampleEvent
    {
        add
        {
            SampleEventStorage += value;
        }

        remove
        {
            SampleEventStorage -= value;
        }
    }

    public void FireEvents()
    {
        SampleEvent?.Invoke(this, EventArgs.Empty);
        SampleEventStorage?.Invoke("SampleEventStorage Fired");
    }
}