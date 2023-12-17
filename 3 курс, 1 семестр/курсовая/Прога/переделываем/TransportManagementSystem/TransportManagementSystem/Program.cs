

namespace TransportManagementSystem
{
    class Program
    {// Создает тестовых пользователей, пункты и транспорт

        public static void Main(string[] args)
        {
            TransportManagementSystem tms = new();
            Test(tms);
            tms.EnterSystem();
        }

        public static void Test(TransportManagementSystem tms)
        {
            tms.UserSystem.AddUnit(new Admin("111", "111", "Test", "Test", "Test", 20));
            tms.UserSystem.AddUnit(new Dispatcher("222", "222", "Test", "Test", "Test", 20));
            tms.UserSystem.AddUnit(new Driver("333", "333", "Test", "Test", "Test", 20));
            tms.PointsSystem.AddUnit(new Point(new Coordinates(1, 1), "test point 1", "test point 1. Description"));
            tms.PointsSystem.AddUnit(new Point(new Coordinates(2, 2), "test point 2", "test point 2. Description"));
            tms.PointsSystem.AddUnit(new Point(new Coordinates(3, 3), "test point 3", "test point 3. Description"));
            tms.TransportSystem.AddUnit(new Transport("test transport"));
        }

        public static int EnterInt(string message)
        {
            Console.WriteLine(message);
            string sNum = Console.ReadLine()!;
            int num;
            while (!int.TryParse(sNum, out num))
            {
                Console.WriteLine("Введено не целое число");
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

        public static string EnterString(string message, string? errMessage = "Поле не может быть пустым", int minChars = 0)
        {
            string result;
            while (true)
            {
                Console.Write(message);
                result = Console.ReadLine()!;
                if (result.Length < minChars)
                {
                    Console.WriteLine(errMessage);
                }
                else return result;
            }
        }

        public static void ErrorInput()
        {
            Console.WriteLine("Выбранного варианта нет");
        }

        public static void ConClear()
        {
            Console.Clear();
            Console.Clear();
            Console.Clear();
            Console.Clear();
            Console.Clear();
        }
    }
}