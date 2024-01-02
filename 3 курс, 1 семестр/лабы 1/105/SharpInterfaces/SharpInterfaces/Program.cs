SuperImage si = new SuperImage();

try
{
    // IDraw
    (si as IDraw).Draw();

    // IDraw2
    IDraw2 idr2 = (IDraw2)si;
    idr2.Draw();
    idr2.DrawToPrinter();

    // IDraw3
    ((IDraw3)si).Draw();
    ((IDraw3)si).DrawToPrinter();
    ((IDraw3)si).DrawToMetafile();
}
catch (InvalidCastException)
{
    Console.WriteLine("No Interface");
}

interface IDraw
{
    void Draw();
}

interface IDraw2 : IDraw
{
    void DrawToPrinter();
}

interface IDraw3 : IDraw2
{
    void DrawToMetafile();
}

class SuperImage : IDraw3
{
    void IDraw.Draw() => Console.WriteLine("IDraw.Draw");
    void IDraw2.DrawToPrinter() => Console.WriteLine("IDraw2.DrawToPrinter");
    void IDraw3.DrawToMetafile() => Console.WriteLine("IDraw3.DrawToMetafile");
}