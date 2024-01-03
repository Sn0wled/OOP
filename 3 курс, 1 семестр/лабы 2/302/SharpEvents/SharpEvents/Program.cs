delegate void dlgChange1();
delegate void dlgChange2(object Sender);
delegate void dlgChange3(object Sender, int x, int y);
delegate void dlgChange4(object Sender, PointEventArgs e);

internal class Program
{
    private static void Main(string[] args)
    {
        Point a = new(1, 1);
        a.Change1 += Handler1;
        a.SetValues(2, 2);
        a.Change2 += Handler2a;
        a.Change2 += Handler2b;
        a.SetValues(3, 3);
        Console.WriteLine("-- Handler3 --");
        a.Change3 += Handler3;
        a.SetValues(4, 4);
        Console.WriteLine("-- Handler4 --");
        a.Change4 += Handler4;
        a.SetValues(5, 5);
        Console.WriteLine("-- Standart Delegate --");
        a.Change += Handler;
        a.SetValues(6, 6);
        Console.WriteLine("-- Standart Params --");
        a.Change5 += Handler4;
        a.SetValues(8, 8);
    }
    static void Handler1()
    {
        Console.WriteLine("Change1");
    }
    static void Handler2a(object Sender)
    {
        Console.WriteLine("Changed2a");
    }
    static void Handler2b(object Sender)
    {
        Console.WriteLine($"Changed2b to {Sender as Point}");
    }
    static void Handler3(object Sender, int x, int y)
    {
        Console.WriteLine($"Changed3 to ({x}, {y})");
    }
    static void Handler4(object Sender, PointEventArgs e)
    {
        Console.WriteLine($"Changed4 to ({e.x}, {e.y})");
    }
    static void Handler(object Sender, EventArgs e)
    {
        Console.WriteLine($"Changed - empty EventArgs");
    }
}

class Point
{
    public int x = 0, y = 0;
    public Point() { }
    public Point(int x, int y)
    {
        this.x = x;
        this.y = y;
    }
    public void SetValues(int x, int y)
    {
        this.x = x;
        this.y = y;
        Change1?.Invoke();
        Change2?.Invoke(this);
        Change3?.Invoke(this, x, y);
        Change4?.Invoke(this, new PointEventArgs(x, y));
        Change?.Invoke(this, EventArgs.Empty);
        Change?.Invoke(this, new EventArgs());
        Change5?.Invoke(this, new PointEventArgs(x, y));
    }
    public override string ToString()
    {
        return $"({x}, {y})";
    }
    public event dlgChange1 Change1;
    public event dlgChange2 Change2;
    public event dlgChange3 Change3;
    public event dlgChange4 Change4;
    public event EventHandler Change;
    public event EventHandler<PointEventArgs> Change5;
}

class PointEventArgs : EventArgs
{
    public int x, y;
    public PointEventArgs(int x, int y)
    {
        this.x = x;
        this.y = y;
    }
}
