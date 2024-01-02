Point p1 = new Point(2, 3);
Console.WriteLine($"1: {p1}");
Point p2 = p1;
p2.x = 3;
Console.WriteLine($"2: {p2}");
Console.WriteLine($"1: {p1}");


Point2 p3 = new Point2(6, 6);
Point2 p4 = (Point2)p3.Clone();
p4.x = 3;
Console.WriteLine($"4: {p4}");
Console.WriteLine($"3: {p3}");

class Point
{
    public int x, y;
    public Point() { }
    public Point(int x, int y)
    {
        this.x = x;
        this.y = y;
    }
    public override string ToString()
    {
        return $"({x},{y})";
    }
}

class Point2 : ICloneable
{
    public int x, y;
    public Point2() { }
    public Point2(int x, int y)
    {
        this.x = x;
        this.y = y;
    }
    public override string ToString()
    {
        return $"({x},{y})";
    }
    public object Clone()
    {
        return new Point2(x, y);
    }
    
}