using Backgammon;

namespace BackgammonReal;

internal class test
{
    public static void Main()
    {
        Player player = new Player("nonam", Color.White);
        Console.WriteLine($"Имя: {player.Name}, Цвет: {player.Color}");
        for (int i = 0; i < 10; i++)
        {
            Console.WriteLine("Бросаем кости:");
            player.RollDices();
            Console.WriteLine($"Выпало: {player.Dice1}, {player.Dice2}");
        }
    }
}
