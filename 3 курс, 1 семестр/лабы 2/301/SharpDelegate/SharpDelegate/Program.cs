class Programm
{
    delegate void dlgSet(int a, int b);
    public static void Main(string[] args)
    {
        Point p1 = new(1, 1);
        Point p2 = new(2, 2);
        Fration f1 = new(1, 1);
        dlgSet d1 = p1.SetValues;
        d1(5, 5);
        Console.WriteLine($"p1: {p1}");
        d1 += p2.SetValues;
        d1 += f1.SetValues;
        d1(6, 6);
        Console.WriteLine($"p1: {p1}");
        Console.WriteLine($"p2: {p2}");
        Console.WriteLine($"f1: {f1}");

        d1 -= p1.SetValues;
        d1!(7, 7);
        Console.WriteLine($"p1: {p1}");
        Console.WriteLine($"p2: {p2}");
        Console.WriteLine($"f1: {f1}");

        dlgSet d2 = p2.SetValues;
        dlgSet df = f1.SetValues;
        d2(4, 4);
        df(5, 5);
        Console.WriteLine($"p2: {p2}");
        Console.WriteLine($"f1: {f1}");

        d1 -= p2.SetValues;
        d1 -= f1.SetValues;
        d1 = d2 + df;
        d1(9, 9);
        Console.WriteLine($"p2: {p2}");
        Console.WriteLine($"f1: {f1}");

    }
}

class Point
{
    protected int x, y;
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
    }
    public override string ToString()
    {
        return $"({x},{y})";
    }
}

class Fration
{
    protected int num, den;
    public Fration() { }
    public Fration(int num, int den)
    {
        this.num = num;
        this.den = den;
    }
    public void SetValues(int num, int den)
    {
        this.num = num;
        this.den = den;
    }
    public override string ToString()
    {
        return $"({num}/{den})";
    }
}
