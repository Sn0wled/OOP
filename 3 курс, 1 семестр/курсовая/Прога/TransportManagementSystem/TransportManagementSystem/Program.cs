namespace TransportManagementSystem
{
    class Programm
    {
        public static void Main(string[] args)
        {
            TransportManagementSystem tMS = new TransportManagementSystem();
            while (true)
            {
                Console.WriteLine("1. Войти");
                Console.WriteLine("0. Закрыть программу");
                string s = Console.ReadLine()!;
                Console.Clear();
                switch (s)
                {
                    case "1":
                        tMS.LogIn();
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Ошибка");
                        break;
                }
            }
        }
        public static int EnterInt(string message)
        {
            Console.WriteLine(message);
            string sNum = Console.ReadLine()!;
            int num;
            while (!int.TryParse(sNum, out num))
            {
                Console.WriteLine("Введено не число");
                Console.WriteLine(message);
                sNum = Console.ReadLine()!;
            }
            return num;
        }
        public static double EnterDouble(string message)
        {
            Console.WriteLine(message);
            string sNum = Console.ReadLine()!;
            double num;
            while (!double.TryParse(sNum, out num))
            {
                Console.WriteLine("Введено не число");
                Console.WriteLine(message);
                sNum = Console.ReadLine()!;
            }
            return num;
        }
    }
}