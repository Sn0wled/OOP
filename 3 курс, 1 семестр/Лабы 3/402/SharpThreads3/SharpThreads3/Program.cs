internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("ID of Main is {0}", Thread.CurrentThread.GetHashCode());
        Worker w = new();
        Thread t = new(w.DoWork);
        t.Start();
        for (int i = 0; i < 5; i++)
        {
            Console.WriteLine("main " + i);
        }
        t.Join();
    }
}

internal class Worker
{
    public void DoWork()
    {
        Console.WriteLine("ID of worker is {0}", Thread.CurrentThread.GetHashCode());
        Console.WriteLine("Worker says: ");
        for (int i = 0; i < 10; i++)
        {
            Console.Write(i + ", ");
        }
        Console.WriteLine();
    }
}