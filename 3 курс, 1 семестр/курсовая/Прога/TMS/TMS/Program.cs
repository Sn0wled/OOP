using TransportManagementSystem;
class Programm
{
    public static void Main(string[] args)
    {
        TransportManagementSystem.TransportManagementSystem tms = new();
        tms.StartMenu();
    }

    public static int ReadInt()
    {
        string s = Console.ReadLine()!;
        int num;

        while (!int.TryParse(s, out num))
        {
            Console.WriteLine("Введено не целое число");
            Console.Write("Повторите попытку: ");
            s = Console.ReadLine()!;
        }
        return num;
    }

    public static double ReadReal()
    {
        string s = Console.ReadLine()!;
        double num;

        while (!double.TryParse(s, out num))
        {
            Console.WriteLine("Введено не вещественное число");
            Console.Write("Повторите попытку: ");
            s = Console.ReadLine()!;
        }
        return num;
    }
}
