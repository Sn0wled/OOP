namespace TransportManagementSystem
{
    internal class Dispatcher : User
    {
        public Dispatcher(string login, string password, string fName, string lName, string pName, int age)
            : base(login, password, fName, lName, pName, age) { }


        public override void ShowUnit()
        {
            base.ShowUnit();
            Console.WriteLine("Должность: Диспетчер");
        }
        public override void Menu(TransportManagementSystem tms)
        {
            string s = "";
            while (s != "0")
            {
                Console.WriteLine("Выбеирте действие:");
                Console.WriteLine("1. Посмотреть доступные точки");
                Console.WriteLine("2. Посмотреть список водителей");
                Console.WriteLine("3. Посмотреть список транспорта");
                Console.WriteLine("4. Посмотреть список маршрутов");
                Console.WriteLine("5. Создать маршрут");
                Console.WriteLine("6. Выбрать маршрут по id");
                Console.WriteLine("7. Назначить водителю транспорт");
                Console.WriteLine("0. Выйти");
                s = Console.ReadLine()!;
                Program.ConClear();
                switch (s)
                {
                    case "0":
                        tms.LogOut();
                        break;
                    case "1":
                        tms.PointsSystem.ShowUnits();
                        break;
                    case "2":
                        tms.UserSystem.ShowDrivers();
                        break;
                    case "3":
                        tms.TransportSystem.ShowUnits();
                        break;
                    case "4":
                        tms.RouteSystem.ShowUnits();
                        break;
                    case "5":
                        tms.RouteSystem.CreateUnit();
                        break;
                    case "6":
                        tms.RouteSystem.SelectUnit(tms);
                        break;
                    case "7":
                        SetTransport(tms);
                        break;
                    default:
                        Program.ErrorInput();
                        break;
                }
            }

        }

        public void SetTransport(TransportManagementSystem tms)
        {
            tms.UserSystem.ShowDrivers();
            int id = Program.EnterInt("Введите id водителя: ");
            Driver? driver = tms.UserSystem.FindDriver(id);
            if (driver != null)
            {
                if (driver.HasTranport())
                {
                    Console.Clear();
                    Console.WriteLine("У водителя уже есть транспорт");
                }
                else
                {
                    tms.TransportSystem.ShowUnits();
                    int tid = Program.EnterInt("Введите id транспорта: ");
                    Transport? transport = (Transport?)tms.TransportSystem.FindUnit(tid);
                    if (transport != null)
                    {
                        driver.Transport = transport;
                        transport.HasDriver = true;
                        Console.Clear();
                        Console.WriteLine("Транспорт назначен");
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Транспорт с указанным id не найден");
                    }
                }
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Водитель с указанным id не найден");
            }
        }
    }
}
