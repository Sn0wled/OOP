using System;

namespace TransportManagementSystem
{
    internal class Route : Unit
    {
        public string Name { get; set; }
        List<WayPoint> wayPoints;
        public Driver? Driver { get; set; }

        public Route(string name)
        {
            wayPoints = new();
            Name = name;
        }
        public bool IsEmpty()
        {
            return wayPoints.Count == 0;
        }
        public override void ShowUnit()
        {
            base.ShowUnit();
            Console.WriteLine($"Название: {Name}");
            string state = Driver is null ? "Свободен" : "Выполняется";
            Console.WriteLine($"Статус: {state}");
        }

        public WayPoint? NextWayPoint()
        {
            return wayPoints.Find(x => x.Checkbox == false);
        }

        public void Finish()
        {
            Driver = null;
            foreach (var wayPoint in wayPoints)
            {
                wayPoint.UnMark();
            }
        }

        public void Show()
        {
            Console.WriteLine("Маршрут");
            ShowUnit();
            Console.WriteLine();
            int counter = 1;
            if (wayPoints.Count == 0)
            {
                Console.WriteLine("Маршрут пуст");
            }
            else
            {
                foreach (WayPoint wp in wayPoints)
                {
                    Console.WriteLine($"Пункт {counter++}");
                    wp.ShowWayPoint();
                    Console.WriteLine();
                    if ((counter - 1) % 2 == 0)
                    {
                        Console.WriteLine("Нажмите q чтобы закрыть");
                        Console.WriteLine("Нажмите любую кнопку чтобы посмотреть следующие");
                        if (Console.ReadKey(true).Key == ConsoleKey.Q)
                        {
                            Console.Clear();
                            return;
                        }
                        Console.Clear();
                    }
                }
            }
            Console.WriteLine("Нажмите любую кнопку");
            Console.ReadKey();
            Console.Clear();
        }

        public override void ChangeUnitData(TransportManagementSystem? tms)
        {
            Console.Clear();
            if (tms == null)
                throw new NotImplementedException();
            string s = "";
            while (s != "0")
            {
                Show();
                Console.WriteLine("Выберите действие:");
                Console.WriteLine("1. Изменить название");
                Console.WriteLine("2. Выбрать пункт");
                Console.WriteLine("3. Добавить пункт");
                Console.WriteLine("4. Назначить маршрут");
                Console.WriteLine("5. Отменить маршрут");
                Console.WriteLine("0. Вернуться назад");
                s = Console.ReadLine()!;
                Console.Clear();
                int num;
                switch (s)
                {
                    case "0":
                        return;
                    case "1":
                        Name = Program.EnterString("Введите новое название: ");
                        Console.Clear();
                        Console.WriteLine("Название изменено");
                        break;
                    case "2":
                        SelectWayPoint(tms);
                        break;
                    case "3":
                        wayPoints.Add(CreateWayPoint(tms));
                        Console.Clear();
                        Console.WriteLine("Пункт добавлен\n");
                        break;
                    case "4":
                        if (Driver != null)
                        {
                            Console.WriteLine("Маршрут уже назначен");
                            break;
                        }
                        tms.UserSystem.ShowDrivers();
                        int id = Program.EnterInt("Введите id водителя: ");
                        Driver? driver = tms.UserSystem.FindDriver(id);
                        Console.Clear();
                        if (driver == null)
                            Console.WriteLine("Водитель с данным id не найден");
                        else if (driver.SetRoute(this))
                            Driver = driver;
                        break;
                    default:
                        Console.WriteLine("Неверный ввод");
                        break;
                    case "5":
                        if (Driver != null)
                        {
                            Driver.Route = null;
                            Driver = null;
                        }
                        Console.Clear();
                        Console.WriteLine("Маршрут отменен");
                        break;
                }
            }
        }

        public void SelectWayPoint(TransportManagementSystem tms)
        {
            Console.Clear();
            Show();
            int num = Program.EnterInt("Введите номер пункта");
            if (num <= 0 || num > wayPoints.Count)
            {
                Console.Clear();
                Console.WriteLine("Пункт с данным номером не найден");
            }
            else
                ActionsOnWayPoint(wayPoints[num - 1], tms);

        }

        public void ActionsOnWayPoint(WayPoint wp, TransportManagementSystem tms)
        {
            string s = "";
            while (s != "0")
            {
                Console.WriteLine("Выберите действие");
                Console.WriteLine("1. Заменить пункт");
                Console.WriteLine("2. Удалить пункт");
                Console.WriteLine("0. Вернуться назад");
                s = Console.ReadLine()!;
                switch (s)
                {
                    case "0":
                        break;
                    case "1":
                        Console.Clear();
                        wp.ReplacePoint(tms);
                        break;
                    case "2":
                        DelWayPoint(wp);
                        Console.Clear();
                        Console.WriteLine("Пункт удален");
                        return;
                    default:
                        Program.ErrorInput();
                        break;
                }
            }
        }

        public bool DelWayPoint(WayPoint point)
        {
            return wayPoints.Remove(point);
        }

        public WayPoint? FindWayPoint(int num)
        {
            if (num <= 0 || num > wayPoints.Count)
            {
                return null;
            }
            else
                return wayPoints[num - 1];
        }

        public WayPoint CreateWayPoint(TransportManagementSystem tms)
        {
            Point? p = null;
            Console.Clear();
            tms.PointsSystem.ShowUnits();
            while (p == null)
            {
                int id = Program.EnterInt("Введите id выбранного пункта");
                p = (Point?)tms.PointsSystem.FindUnit(id);
                if (p == null)
                {
                    Console.WriteLine("Пункта с выбранным id не существует");
                }
            }
            return new WayPoint(p);
        }
    }
}
