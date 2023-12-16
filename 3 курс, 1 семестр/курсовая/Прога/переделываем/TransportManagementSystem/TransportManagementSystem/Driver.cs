namespace TransportManagementSystem
{
    internal class Driver : User
    {
        Route? route;
        Transport? transport;
        public Driver(string login, string password, string fName, string lName, string pName, int age)
            : base(login, password, fName, lName, pName, age) { }

        public bool HasTransport() { return transport != null; }
        public void SetTransport(Transport t) { transport = t; }

        public override void ShowInfo()
        {
            base.ShowInfo();
            Console.WriteLine("Должность: Водитель");
            string state = route is null ? "Свободен" : "Занят";
            string tStatus = transport is null ? "Нет" : "Есть";
            Console.WriteLine($"Статус: {state}");
            Console.WriteLine($"Транспорт: {tStatus}");
        }

        public bool IsFree()
        {
            return route is null;
        }

        public void FinishRoute()
        {
            if (route is null)
                Console.WriteLine("У вас нет маршрута");
            else
            {
                if (route.FindFirstNotMarked() is null)
                {
                    route.Finish();
                    route = null;
                    Console.WriteLine("Маршрут завершен");
                }
                else
                {
                    Console.WriteLine("Вы не достигли последнего пункта маршрута");
                }
            }
        }

        public void MarkPoint()
        {
            if (route is null)
                Console.WriteLine("У вас нет маршрута");
            else
            {
                WayPoint? point = route.FindFirstNotMarked();
                if (point is null)
                {
                    Console.WriteLine("Последний пункт маршрута уже достигнут.");
                    Console.WriteLine("Завершите маршрут.");
                }
                else
                {
                    if (transport!.IsAt(point))
                    {
                        point.Mark();
                        Console.WriteLine("Пункт отмечен");
                    }
                    else
                        Console.WriteLine("Вы не на пункте");
                }
            }
        }

        public void Drive()
        {
            if (transport is null)
                Console.WriteLine("У вас нет транспорта");
            else
            {
                transport.Drive();
                Console.WriteLine("Вы приехали");
            }
        }

        public void NextPoint()
        {
            if (route is null)
                Console.WriteLine("Маршрут не задан");
            else
            {
                WayPoint? point = route.FindFirstNotMarked();
                if (point == null)
                {
                    Console.WriteLine("Последний пункт маршрута достигнут.");
                    Console.WriteLine("Завершите маршрут.");
                }
                else
                {
                    Console.WriteLine("Следующая точка:");
                    point.ShowPoint();
                }
            }
        }

        public void ShowRoute()
        {
            if (route is null)
                Console.WriteLine("Маршрут не задан");
            else
            {
                route.ShowInfo();
                route.ShowPoints();
            }
        }

        public void TakeRoute(Route route)
        {
            this.route = route;
        }

        public void CancelRoute()
        {
            route = null;
        }
    }
}
