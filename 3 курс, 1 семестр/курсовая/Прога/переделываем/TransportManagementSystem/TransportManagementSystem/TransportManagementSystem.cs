namespace TransportManagementSystem
{
    internal class TransportManagementSystem
    {
        public UserSystem UserSystem { get; init; }
        public PointsSystem PointsSystem { get; init; }
        public TransportSystem TransportSystem { get; init; }
        public RouteSystem RouteSystem { get; init; }
        public User? User { get; set; }

        public TransportManagementSystem()
        {
            UserSystem = new UserSystem();
            PointsSystem = new PointsSystem();
            TransportSystem = new TransportSystem();
            RouteSystem = new RouteSystem();
        }

        // Вход в систему
        public void LogIn()
        {
            while (User == null)
            {
                User = UserSystem.LogIn();
                if (User != null)
                {
                    Console.WriteLine("Вы успешно вошли");
                    User.Menu(this);
                    break;
                }
                else
                    Console.WriteLine("Неправильный логин или пароль");
            }
        }

        public void EnterSystem()
        {
            string s = "";
            while (s != "0")
            {
                Console.Clear();
                Console.WriteLine("Выберите действие:");
                Console.WriteLine("1. Войти в систему");
                Console.WriteLine("0. Закрыть программу");
                s = Console.ReadLine()!;
                switch (s)
                {
                    case "0":
                        break;
                    case "1":
                        LogIn();
                        break;
                    default:
                        Program.ErrorInput();
                        break;
                }
            }
        }

        // Выход из системы
        public void LogOut()
        {
            User = null;
        }
    }
}
