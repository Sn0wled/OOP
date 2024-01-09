using Backgammon;

namespace BackgammonReal;

internal class test
{
    public static void Main()
    {
        Dice dice = new Dice();
        for (int i = 0; i < 10; i++)
        {
            dice.Roll();
            Console.WriteLine(dice.Value);
        }
    }
}
