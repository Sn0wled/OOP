namespace TransportManagementSystem
{
    internal class RouteSystem
    {
        int counter;
        List<Route> routes;
        public RouteSystem()
        {
            counter = 0;
            routes = new List<Route>();
        }

        public void ShowRoutes()
        {
            if (routes.Count == 0)
            {
                Console.WriteLine("Список маршрутов пуст");
                return;
            }
            Console.WriteLine("Список маршрутов:");
            foreach (Route route in routes)
            {
                route.ShowInfo();
                Console.WriteLine();
            }
        }
        public void AddRoute()
        {
            Console.WriteLine("Введите название маршрута");
            string name = Console.ReadLine()!;
            Route route = new Route(counter++, name);
            routes.Add(route);
            Console.WriteLine($"Маршрут добавлен. Его id: {counter - 1}");
        }

        public void FindRoute(TransportManagementSystem tMS)
        {
            int id = Programm.EnterInt("Введите id маршрута");
            Route route = routes.Find(x => x.HasID(id))!;
            if (route == null)
            {
                Console.WriteLine("Маршрут не найден");
                return;
            }
            else
            {
                FoundRouteMenu(route, tMS);
            }
        }
        public void FoundRouteMenu(Route route, TransportManagementSystem tMS)
        {
            while (true)
            {
                route.ShowInfo();
                Console.WriteLine();
                Console.WriteLine("Выберите действие:");
                Console.WriteLine("1. Удалить маршрут");
                Console.WriteLine("2. Изменить маршрут");
                Console.WriteLine("0. Вернуться назад");
                string s = Console.ReadLine()!;
                switch (s)
                {
                    case "1":
                        routes.Remove(route);
                        return;
                    case "2":
                        route.ChangeRoute(tMS);
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Ошибка ввода");
                        break;
                }
            }
        }
    }
}
