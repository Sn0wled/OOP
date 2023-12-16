namespace TransportManagementSystem
{
    internal class Point : Unit
    {
        protected Coordinates coords;
        protected string name, description;
        public Point(Coordinates coords, string name, string description)
        {
            this.coords = coords;
            this.name = name;
            this.description = description;
        }

        public Point(Point p)
        {
            name = p.name;
            description = p.description;
            coords = new Coordinates(p.coords);
        }
        public override void ShowInfo()
        {
            base.ShowInfo();
            Console.WriteLine($"Название: {name}");
            Console.WriteLine($"Описание: {description}");
            Console.WriteLine($"Широта: {coords.Latitude}, Долгота: {coords.Longitude}");
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
                        coords.Longitude = Programm.EnterInt("Введине новую широту: ");
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
