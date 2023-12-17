using System.Collections;

namespace TransportManagementSystem
{
    internal abstract class UnitSystem : IEnumerable
    {
        int counter;
        protected List<Unit> units;
        public UnitSystem()
        {
            counter = 0;
            units = new();
        }

        public virtual void ShowUnits()
        {
            int counter = 0;
            if (units.Count == 0)
            {
                Console.WriteLine("Список пуст\n");
            }
            else
            {
                foreach (Unit unit in units)
                {
                    counter++;
                    unit.ShowUnit();
                    Console.WriteLine();
                    if (counter % 5 == 0)
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
            Console.WriteLine("Нажмите любую кнопку чтобы закрыть");
            Console.ReadKey();
            Console.Clear();
        }

        public abstract void CreateUnit();

        public void SelectUnit(TransportManagementSystem? tms = null)
        {
            Console.Clear();
            string s1 = "";
            string s2 = "";
            if (this is UserSystem)
            {
                s1 = "пользователя";
                s2 = "Пользователь";
            }
            else if (this is TransportSystem)
            {
                s1 = "транспорта";
                s2 = "Транспорт";
            }
            else if (this is RouteSystem)
            {
                s1 = "маршрута";
                s2 = "Маршрут";
            }
            else if (this is PointsSystem)
            {
                s1 = "пункта";
                s2 = "Пункт";
            }
            int id = Program.EnterInt($"Введите id {s1}");
            Unit? unit = FindUnit(id);
            if (unit == null)
            {
                Console.Clear();
                Console.WriteLine($"{s2} с данным id не найден");
            }
            else
                ActionsOnUnit(unit, tms);
            return;
        }

        public Unit? FindUnit(int id)
        { return units.Find(x => x.ID == id); }

        public virtual bool AddUnit(Unit unit)
        {
            unit.ID = counter++;
            units.Add(unit);
            return true;
        }

        public bool DelUnit(Unit unit)
        {
            return units.Remove(unit);
        }

        public virtual void ActionsOnUnit(Unit unit, TransportManagementSystem? tms = null)
        {
            string s = "";
            while (s != "0")
            {
                Console.Clear();
                unit.ShowUnit();
                if (unit is User user)
                {
                    Console.WriteLine($"Логин: {user.Login}");
                    Console.WriteLine($"Пароль: {user.Password}");
                }
                Console.WriteLine();
                Console.WriteLine("Выберите действие:");
                Console.WriteLine("1. Удалить");
                if (unit is Route) 
                    Console.WriteLine("2. Изменить маршрут");
                else
                    Console.WriteLine("2. Изменить данные");
                Console.WriteLine("0. Вернуться назад");
                s = Console.ReadLine()!;
                switch (s)
                {
                    case "0":
                        break;
                    case "1":
                        DelUnit(unit);
                        Console.Clear();
                        Console.WriteLine("Удаление завершено");
                        if (unit is Route r && r.Driver != null) {
                            r.Driver.Route= null;
                            r.Driver = null;
                        }
                        return;
                    case "2":
                        unit.ChangeUnitData(tms);
                        break;
                    default:
                        Program.ErrorInput();
                        break;
                }
            }
            Console.Clear() ;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return units.GetEnumerator();
        }
    }
}
