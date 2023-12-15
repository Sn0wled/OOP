namespace TransportManagementSystem
{
    internal class Dispatcher : User
    {
        public Dispatcher(int id, string login, string password, string fName, string lName, string pName, int age, Gender gender)
            : base(id, login, password, fName, lName, pName, age, gender) { }

        public override void ShowInfo()
        {
            base.ShowInfo();
            Console.WriteLine("Должность: Диспетчер");
        }

        public void IssueTransport(TransportManagementSystem tMS)
        {
            int driverID, tID;
            driverID = Programm.EnterInt("Введите id водителя");
            Driver? driver = tMS.GetUserSystem().FindDriver(driverID);
            if (driver == null)
            {
                Console.WriteLine("Водитель с данным id не найден");
                return;
            }
            if (driver.HasTransport())
            {
                Console.WriteLine("Водитель уже имеет транспорт");
                return;
            }
            tID = Programm.EnterInt("Введите id транспорта");
            Transport? transport = tMS.GetTransportSystem().GetTransport(tID);
            if (transport == null)
            {
                Console.WriteLine("Транспорт с данным id не найден");
                return;
            }
            if (transport.HasDriver())
            {
                Console.WriteLine("Транспорт уже занят");
                return;
            }
            driver.SetTransport(transport);
            transport.SetDriver();
            Console.WriteLine("Транспорт назначен");
        }

        public override void Menu(TransportManagementSystem tMS)
        {
            while (true)
            {
                Console.WriteLine("Выбеирте действие:");
                Console.WriteLine("1. Посмотреть доступные точки");
                Console.WriteLine("2. Посмотреть список маршрутов");
                Console.WriteLine("3. Добавить маршрут");
                Console.WriteLine("4. Выбрать маршрут");
                Console.WriteLine("5. Посмотреть список водителей");
                Console.WriteLine("6. Посмотреть список транспорта");
                Console.WriteLine("7. Назначить водителю транспорт");
                Console.WriteLine("0. Выйти");
                string s = Console.ReadLine()!;
                switch (s)
                {
                    case "0":
                        tMS.LogOut();
                        return;
                    case "1":
                        tMS.GetPointsSystem().ShowPoints();
                        break;
                    case "2":
                        tMS.GetRouteSystem().ShowRoutes();
                        break;
                    case "3":
                        tMS.GetRouteSystem().AddRoute();
                        break;
                    case "4":
                        tMS.GetRouteSystem().FindRoute(tMS);
                        break;
                    case "5":
                        tMS.GetUserSystem().ShowDrivers();
                        break;
                    case "6":
                        tMS.GetTransportSystem().ShowTransport();
                        break;
                    case "7":
                        IssueTransport(tMS);
                        break;
                    default:
                        Console.WriteLine("Неверный ввод");
                        break;
                }
            }
        }
    }
}
