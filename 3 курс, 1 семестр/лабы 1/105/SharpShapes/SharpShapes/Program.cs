Shape fc = new Circle("circle");
fc.Draw();
Shape fs = new Square("square");
fs.Draw();
Square s = new("square");
Circle c = new("circle");
Console.WriteLine(s.Points());
//Console.WriteLine(fs.Points);

// 1 ыпособ
IPointy ip;
try
{
    ip = (IPointy)s;
    Console.WriteLine($"points = {ip.Points()}");
    ip = (IPointy)fs;
    Console.WriteLine($"points = {ip.Points()}");
    ip = (IPointy)c;
    Console.WriteLine($"points = {ip.Points()}");
} catch (InvalidCastException)
{
    Console.WriteLine("No IPointy");
}

// 2 способ
ip = s as IPointy;
if (ip == null)
{
    Console.WriteLine("No as IPointy");
}
else
{
    Console.WriteLine("points = {0}", ((IPointy)s).Points());
}

// способ 3
if (s is IPointy ipo)
{
    Console.WriteLine($"points = {ipo.Points()}");
}
else
{
    Console.WriteLine("No is IPointy"); 
}

if (s is IDraw3D id3)
{
    id3.Draw();
}
else
{
    Console.WriteLine("No IDraw3D");
}

abstract class Shape : IDrawable
{
    protected string name = "figure";
    public Shape()
    {

    }

    public Shape(string name)
    {
        this.name = name;
    }

    public Shape(string name, int id) 
        :this(name)
    {
        ID = id;
    }

    public abstract void Draw();

    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    private int ID  = 0;
}

class Circle : Shape
{
    public Circle(string name) :base(name) { }

    public override void Draw()
    {
        Console.WriteLine($"Circle {name}"); ;
    }
}

class Square : Shape, IPointy, IDraw3D
{
    public Square(string name) : base(name) { }

    public override void Draw()
    {
        Console.WriteLine($"Square {name}"); ;
    }
    public int Points()
    {
        return 4;
    }

    void IDraw3D.Draw()
    {
        Console.WriteLine($"Square3D {name}");
    }
}

interface IDrawable
{
    void Draw();
}

interface IPointy
{
    int Points();
}

interface IDraw3D
{
    void Draw();
}


