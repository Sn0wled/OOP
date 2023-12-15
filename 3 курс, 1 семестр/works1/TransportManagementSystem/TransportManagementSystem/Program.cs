namespace TransportManagementSystem
{
    class Programm
    {
        public static void Main(string[] args)
        {
            TransportManagementSystem tMS = new TransportManagementSystem();
            tMS.GetUserSystem().AddUser();
            Console.Clear();
            while (true)
            {
                Console.WriteLine("1. Войти");
                Console.WriteLine("0. Закрыть программу");
                string s = Console.ReadLine();
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
    }
}