internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Main starts");
        ThreadWithState w = new ThreadWithState("Number {0}", 33);
        Thread t = new(w.ThreadProc);
        t.Start();
        while (!t.IsAlive) ;
        Console.WriteLine("Main works and waits");
        t.Join();
        Console.WriteLine("Main ends");
    }
}

// хранит параметры потока
internal class ThreadWithState
{
    private string sos;
    private int sin;
    public ThreadWithState(string sos, int sin)
    {
        this.sos = sos;
        this.sin = sin;
    }
    public void ThreadProc()
    {
        Console.WriteLine(sos, sin);
    }
}