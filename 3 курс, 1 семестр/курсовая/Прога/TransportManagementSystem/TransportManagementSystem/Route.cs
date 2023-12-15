using System;
using System.Security.Cryptography;

namespace TransportManagementSystem
{
    internal class Route
    {
        int id;
        string name;
        List<WayPoint> wayPoints;
        Driver? driver;
        public Route(int id, string name)
        {
            this.id = id;
            wayPoints = new List<WayPoint>();
            this.name = name;
        }

        public void Finish()
        {
            foreach (var wayPoint in wayPoints)
            {
                wayPoint.Unmark();
            }
            driver = null;
        }

        public void ShowInfo()
        {
            Console.WriteLine($"ID: {id}");
            Console.WriteLine($"Название: {name}");
            string state = driver is null ? "Свободен" : "Выполняется";
            Console.WriteLine($"Статус: {state}");
        }

        public bool HasID(int id) => this.id == id;

        public WayPoint? FindFirstNotMarked()
        {
            return wayPoints.Find(x => x.IsMarked());
        }

        public void ShowPoints()
        {
            if (wayPoints.Count == 0)
            {
                Console.WriteLine("В маршруте нет пунктов");
            }
            else
            {
                int counter = 1;
                foreach (WayPoint wayPoint in wayPoints)
                {
                    Console.WriteLine($"Пункт {counter++}");
                    wayPoint.ShowPoint();
                    Console.WriteLine();
                }
            }
        }

        public void ChangeName()
        {
            Console.Write("Введине новое название: ");
            name = Console.ReadLine()!;
        }

        public void ChangeRoute(TransportManagementSystem tMS)
        {
            while (true)
            {
                ShowInfo();
                ShowPoints();
                Console.WriteLine("Выберите действие:");
                Console.WriteLine("1. Изменить название");
                Console.WriteLine("2. Изменить пункт");
                Console.WriteLine("3. Удалить пункт");
                Console.WriteLine("4. Добавить пункт");
                Console.WriteLine("5. Назначить маршрут водителю");
                Console.WriteLine("6. Отменить маршрут");
                Console.WriteLine("0. Вернуться назад");
                string s = Console.ReadLine()!;
                int num;
                switch (s)
                {
                    case "0":
                        return;
                    case "1":
                        ChangeName();
                        break;
                    case "2":
                        num = Programm.EnterInt("Введите номер пункта");
                        if (num < 1 || num > wayPoints.Count)
                            Console.WriteLine("Такой точки нет");
                        else
                            ChangeWayPoint(num, tMS.GetPointsSystem());
                        break;
                    case "3":
                        RemoveWayPoint();
                        break;
                    case "4":
                        AddWayPoint(tMS.GetPointsSystem());
                        break;
                    case "5":
                        AppointDriver(tMS.GetUserSystem());
                        break;
                    case "6":
                        if (driver is not null)
                        {
                            driver.CancelRoute();
                            driver = null;
                        }
                        Console.WriteLine("Маршрут свободен");
                        break;
                    default:
                        Console.WriteLine("Неверный ввод");
                        break;
                }
            }
        }

        public void AppointDriver(UserSystem us)
        {
            Console.WriteLine("Выбеирте действие:");
            Console.WriteLine("1. Посмотреть список водителей");
            Console.WriteLine("2. Назначить водителя");
            Console.WriteLine("0. Выйти");
            string s = Console.ReadLine()!;
            switch (s)
            {
                case "0":
                    return;
                case "1":
                    us.ShowDrivers();
                    break;
                case "2":
                    int driverID = Programm.EnterInt("Введите id водителя");
                    Driver? driver = us.FindDriver(driverID);
                    if (driver is null)
                    {
                        Console.WriteLine("Водитель не найден");
                    }
                    else if (!driver.IsFree())
                    {
                        Console.WriteLine("Водитель занят");
                    }
                    else
                    {
                        driver.TakeRoute(this);
                        this.driver = driver;
                        Console.WriteLine("Водитель назначен");
                    }
                    return;
                default:
                    Console.WriteLine("Неверный ввод");
                    break;

            }
        }

        public void AddWayPoint(PointsSystem ps)
        {
            while (true)
            {
                ShowInfo();
                Console.WriteLine("Выберите действие:");
                Console.WriteLine("1. Показать список доступных пунктов");
                Console.WriteLine("2. Выбрать пункт");
                Console.WriteLine("0. Вернуться назад");
                string s = Console.ReadLine()!;
                switch (s)
                {
                    case "0":
                        return;
                    case "1":
                        ps.ShowPoints();
                        break;
                    case "2":
                        int id = Programm.EnterInt("Введите id пункта");
                        Point? point = ps.FindPoint(id);
                        if (point == null)
                            Console.WriteLine("Пункт не найден");
                        else
                            wayPoints.Add(new WayPoint(point));
                        break;
                }
            }
        }
        public void ChangeWayPoint(int num, PointsSystem ps)
        {
            while (true)
            {
                ShowInfo();
                Console.WriteLine("Выберите действие:");
                Console.WriteLine("1. Показать список доступных пунктов");
                Console.WriteLine("2. Заменить другим пунктом");
                Console.WriteLine("0. Вернуться назад");
                string s = Console.ReadLine()!;
                switch (s)
                {
                    case "0":
                        return;
                    case "1":
                        ps.ShowPoints();
                        break;
                    case "2":
                        int id = Programm.EnterInt("Введите id пункта");
                        Point? point = ps.FindPoint(id);
                        if (point == null)
                            Console.WriteLine("Пункт не найден");
                        else
                            wayPoints[num - 1] = new WayPoint(point);
                        break;
                }
            }
        }
        public void RemoveWayPoint()
        {
            int num = Programm.EnterInt("Введите номер пункта");
            if (num > 0 && num <= wayPoints.Count)
                wayPoints.RemoveAt(num - 1);
            else
                Console.WriteLine("Такого пункта нет");
        }
    }
}
