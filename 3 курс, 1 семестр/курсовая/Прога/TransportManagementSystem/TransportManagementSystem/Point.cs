namespace TransportManagementSystem
{
    internal class Point
    {
        protected int id;
        protected Coordinates coords;
        protected string name, description;
        public Point(Coordinates coords, string name, string description, int id)
        {
            this.coords = coords;
            this.name = name;
            this.description = description;
            this.id = id;
        }

        public Point(Point p)
        {
            id = p.id;
            name = p.name;
            description = p.description;
            coords = new Coordinates(p.coords);
        }
        public void ShowInfo()
        {
            Console.WriteLine($"ID точки: {id}");
            Console.WriteLine($"Название: {name}");
            Console.WriteLine($"Описание: {description}");
            Console.WriteLine($"Широта: {coords.Longtitude}, Долгота: {coords.Latitude}");
        }
        public bool HasID(int id)
        {
            return this.id == id;
        }
        public void ChangeData()
        {
            while (true)
            {
                Console.WriteLine("Выберите действие:");
                Console.WriteLine("1. Изменить название");
                Console.WriteLine("2. Изменить описание");
                Console.WriteLine("3. Изменить широту");
                Console.WriteLine("4. Изменить долготу");
                Console.WriteLine("0. Вернуться назад");
                string s = Console.ReadLine()!;
                switch (s)
                {
                    case "1":
                        Console.Write("Введине новое название: ");
                        name = Console.ReadLine()!;
                        break;
                    case "2":
                        Console.Write("Введине новое описание: ");
                        description = Console.ReadLine()!;
                        break;
                    case "3":
                        coords.Longtitude = Programm.EnterInt("Введине новую широту: ");
                        break;
                    case "4":
                        coords.Latitude = Programm.EnterInt("Введине новую долготу: ");
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Неверный ввод");
                        break;

                }
            }
        }
    }
}
