namespace BackgamonClasses;
using BackgamonClasses.Board;

internal class test
{
    public static void Main(string[] args)
    {
        Dice[] dices = new Dice[2];
        for (int i = 0; i < dices.Length; i++)
        {
            dices[i] = new Dice();
            dices[i].Roll();
            Console.WriteLine(dices[i].Value);
        }
    }
}
