using Backgammon;

namespace BackgammonReal;

internal class test
{
    public static void Main()
    {
<<<<<<< HEAD
        Player player = new Player("nonam", Color.White);
        Console.WriteLine($"Имя: {player.Name}, Цвет: {player.Color}");
        for (int i = 0; i < 10; i++)
        {
            Console.WriteLine("Бросаем кости:");
            player.RollDices();
            Console.WriteLine($"Выпало: {player.Dice1}, {player.Dice2}");
        }
=======
        Board b = new Board();
        Console.WriteLine(b);
        b.Move(11, 22);
        Console.WriteLine(b);
>>>>>>> ba922ab33fb51834c03c3da1fcc94347744ac13c
    }
}
