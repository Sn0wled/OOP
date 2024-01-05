internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Main starts!");
        Worker w = new Worker();
        Thread t = new Thread(w.Process);
        t.Start();
        while (!t.IsAlive) ;
        Thread.Sleep(1000);
        w.StopRunning();
        t.Join();
        Console.WriteLine("Main ends");
    }
}

internal class Worker
{
    private volatile bool running = false;
    public void Process()
    {
        Console.WriteLine("Now enter...");
        running = true;
        while (running)
        {
            Console.WriteLine("... running ...");
            Thread.Sleep(50);
        }
        Console.WriteLine("Now leave...");
    }
    public void StopRunning()
    {
        running = false;
    }
}