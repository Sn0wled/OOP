namespace TransportManagementSystem
{
    internal class PointsSystem
    {
        int counter = 0;
        List<Point> points;
        public PointsSystem()
        {
            points = new List<Point>();
        }

        public void Test()
        {
            points.Add(new Point(new Coordinates(1, 1), "point1", "", counter++));
            points.Add(new Point(new Coordinates(1, 1), "point2", "", counter++));
            points.Add(new Point(new Coordinates(1, 1), "point3", "", counter++));
        }

        public void ShowPoints()
        {
            if (points.Count == 0)
            {
                Console.WriteLine("Список точек пуст");
                return;
            }
            foreach (var point in points)
            {
                point.ShowInfo();
                Console.WriteLine();
            }
        }
        public void AddPoint()
        {
            string name, description, sLatitude, sLongtitude;
            double latitude, longitude;
            Console.WriteLine("Добавление новой точки");
            Console.WriteLine("Введите название точки");
            name = Console.ReadLine()!;
            Console.WriteLine("Введите описание точки");
            description = Console.ReadLine()!;
            Console.Write("Введите широту: ");
            sLatitude = Console.ReadLine()!;
            while (!double.TryParse(sLatitude, out latitude))
            {
                Console.Write("Введите широту: ");
                Console.WriteLine("Неверный ввод");
                sLatitude = Console.ReadLine()!;
            }
            Console.Write("Введите долготу: ");
            sLongtitude = Console.ReadLine()!;
            while (!double.TryParse(sLongtitude, out longitude))
            {
                Console.WriteLine("Неверный ввод");
                Console.Write("Введите долготу: ");
                sLatitude = Console.ReadLine()!;
            }
            points.Add(new Point(new Coordinates(longitude, latitude), name, description, counter++));
            Console.WriteLine("Точка успешно добавлена");
        }

        public void FindPoint()
        {
            int id = Programm.EnterInt("Введите id точки");
            Point? point = points.Find(x => x.HasID(id));
            if (point == null)
            {
                Console.WriteLine("Точка не найдена");
                return;
            }
            else
            {
                FoundPointMenu(point);
            }
        }
        public Point? FindPoint(int id)
        {
            return points.Find(x => x.HasID(id));
        }
        public void FoundPointMenu(Point point)
        {
            while (true)
            {
                point.ShowInfo();
                Console.WriteLine("Выбеирте действие:");
                Console.WriteLine("1. Удалить точку");
                Console.WriteLine("2. Изменить данные точки");
                Console.WriteLine("0. Вернуться назад");
                string s = Console.ReadLine()!;
                switch (s)
                {
                    case "1":
                        points.Remove(point);
                        return;
                    case "2":
                        point.ChangeData();
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
