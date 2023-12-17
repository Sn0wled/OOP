namespace TransportManagementSystem
{
    internal class Driver : User
    {
        public Route? Route { get; set; }
        public Transport? Transport { get; set; }
        public Driver(string login, string password, string fName, string lName, string pName, int age)
            : base(login, password, fName, lName, pName, age)
        {
            Route = null;
        }

        public override void ShowUnit()
        {
            base.ShowUnit();
            Console.WriteLine("Должность: Водитель");
            string state = Route is null ? "Свободен" : "Занят";
            string tStatus = Transport is null ? "Нет" : "Есть";
            Console.WriteLine($"Статус: {state}");
            Console.WriteLine($"Транспорт: {tStatus}");
        }

        public bool SetRoute(Route route)
        {
            if (Transport is null)
            {
                Console.WriteLine("У данного водителя нет транспорта");
                return false;
            }
            if (Route != null)
            {
                Console.WriteLine("У данного водителя уже есть маршрут");
                return false;
            }
            else
            {
                Route = route;
                Console.WriteLine("Маршрут назначен");
                return true;
            }

        }

        public override void Menu(TransportManagementSystem tms)
        {
            string s = "";
            while (s != "0")
            {
                Console.WriteLine("Выберите действие:");
                Console.WriteLine("1. Посмотреть текущий маршрут");
                Console.WriteLine("2. Посмотреть следующую точку");
                Console.WriteLine("3. Поехать по координатам");
                Console.WriteLine("4. Отметить точку");
                Console.WriteLine("5. Завершить маршрут");
                Console.WriteLine("0. Выйти");
                s = Console.ReadLine()!;
                Console.Clear();
                switch (s)
                {
                    case "0":
                        tms.LogOut();
                        return;
                    case "1":
                        if (Route is null)
                            Console.WriteLine("Маршрут не задан");
                        else
                        {
                            Route.Show();
                            Console.WriteLine();
                            Console.WriteLine("Нажмите любую кнопку");
                            Console.ReadKey();
                            Console.Clear();
                        }
                        break;
                    case "2":
                        if (IsFree())
                        {
                            Console.Clear();
                            Console.WriteLine("У вас нет маршрута");
                        }
                        else
                        {
                            WayPoint? wp = Route!.NextWayPoint();
                            if (wp != null)
                            {
                                wp.ShowWayPoint();
                                Console.WriteLine();
                                Console.WriteLine("Нажмите любую кнопку");
                                Console.ReadKey();
                                Console.Clear();
                            }
                            else
                            {
                                Console.WriteLine("Последний пункт маршрута достигнут.");
                                Console.WriteLine("Завершите маршрут.");
                            }
                        }

                        break;
                    case "3":
                        Drive();
                        break;
                    case "4":
                        MarkPoint();
                        break;
                    case "5":
                        FinishRoute();
                        break;
                    default:
                        Console.WriteLine("Неверный ввод");
                        break;
                }
            }
        }

        public void MarkPoint()
        {
            if (IsFree())
                Console.WriteLine("У вас нет маршрута");
            else
            {
                WayPoint? point = Route!.NextWayPoint();
                if (point is null)
                {
                    Console.WriteLine("Последний пункт маршрута уже достигнут.");
                    Console.WriteLine("Завершите маршрут.");
                }
                else
                {
                    if (Transport!.IsAtPoint(point.Point))
                    {
                        point.Mark();
                        Console.WriteLine("Пункт отмечен");
                    }
                    else
                        Console.WriteLine("Вы не на пункте");
                }
            }
        }

        public void FinishRoute()
        {
            if (IsFree())
                Console.WriteLine("У вас нет маршрута");
            else
            {
                if (Route!.NextWayPoint() is null)
                {
                    Route.Finish();
                    Route = null;
                    Console.WriteLine("Маршрут завершен");
                }
                else
                {
                    Console.WriteLine("Вы не достигли последнего пункта маршрута");
                }
            }
        }

        public bool HasTranport()
        {
            return Transport != null;
        }

        public void Drive()
        {
            if (Transport is null)
                Console.WriteLine("У вас нет транспорта");
            else
            {
                Transport.Drive();
                Console.WriteLine("Вы приехали");
            }
        }
        public bool IsFree()
        {
            return Route is null; ;
        }
    }
}
