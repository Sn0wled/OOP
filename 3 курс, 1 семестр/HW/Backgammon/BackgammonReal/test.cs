using Backgammon;

namespace BackgammonReal;

internal class test
{
    public static void Main()
    {
        Board b = new Board();
        Console.WriteLine(b);
        b.Move(11, 22);
        Console.WriteLine(b);
    }
}
