using System.Collections;
class Program
{
    public static void Main(string[] args)
    {
        Point a = new Point(3, 3);
        Point b = new Point(2, 2);
        Point c = new Point(1, 1);

        dlgPointOp add = Point.PointAdd;
        dlgPointOp sub = Point.PointSub;

        a.Operation(add, b);
        Console.WriteLine($"a{a}");

        a.Operation(sub, c);
        Console.WriteLine($"a{a}");

        Points po = new Points(3);
        po.Operation(add, c);

        foreach(Point p in po) Console.WriteLine($"p{p}");

        dlgPointOp1 inc = Point.PointIncrement;
        po.Operation1(inc);

        foreach (Point p in po) Console.WriteLine($"p{p}");
    }

}

class Point
{
    protected int x = 0, y = 0;
    public Point() { }
    public Point(int x, int y)
    {
        this.x = x;
        this.y = y;
    }
    public static void PointAdd(Point a, Point b)
    {
        a.x += b.x;
        a.y += b.y;
    }
    public static void PointSub(Point a, Point b)
    {
        a.x -= b.x;
        a.y -= b.y;
    }

    public void Operation(dlgPointOp d, Point b)
    {
        d(this, b);
    }
    public override string ToString()
    {
        return $"({x}, {y})";
    }
    public static void PointIncrement(Point p)
    {
        p.x += 1;
        p.y -= 1;
    }
}

delegate void dlgPointOp(Point a, Point b);
delegate void dlgPointOp1(Point a);

class Points : IEnumerable
{
    private Point[] points;
    public Points()
    {
        points = new Point[1];
        points[0] = new Point();
    }
    public Points(int number)
    {
        points = new Point[number];
        for (int i = 0; i < number; i++) points[i] = new Point();
    }
    public IEnumerator GetEnumerator()
    {
        foreach (Point p in points)
        {
            yield return p;
        }
    }
    public Point this[int index]
    {
        get => points[index];
    }

    public void Operation(dlgPointOp d, Point b)
    {
        foreach (Point p in points)
        {
            d(p, b);
        }
    }
    public void Operation1(dlgPointOp1 d)
    {
        foreach (Point p in points)
        {
            d(p);
        }
    }
}