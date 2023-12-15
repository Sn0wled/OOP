namespace TransportManagementSystem {
    internal class Point {
        int id;
        protected Coordinates coords;
        string name, description;
        public Point(Coordinates coords, string name, string description, int id) {
            this.coords = coords;
            this.name = name;
            this.description = description;
            this.id = id;
        }
        public void ShowPoint( ) {
            Console.WriteLine($"ID точки: {id}");
            Console.WriteLine($"Название: {name}");
            Console.WriteLine($"Описание: {description}");
            Console.WriteLine($"Широта: {coords.Longtitude}, Долгота: {coords.Latitude}");
        }
        public bool HasID(int id) {
            return this.id == id;
        }
        public void ChangeData( ) {
            while (true) {
                Console.WriteLine("Выберите действие:");
                Console.WriteLine("1. Изменить название");
                Console.WriteLine("2. Изменить описание");
                Console.WriteLine("3. Изменить широту");
                Console.WriteLine("4. Изменить долготу");
                Console.WriteLine("0. Вернуться назад");
                string s = Console.ReadLine()!;
                string temp;
                double tempDouble;
                switch (s) {
                    case "1":
                        Console.Write("Введине новое название: ");
                        name = Console.ReadLine()!;
                        break;
                    case "2":
                        Console.Write("Введине новое описание: ");
                        description = Console.ReadLine()!;
                        break;
                    case "3":
                        Console.Write("Введине новую широту: ");
                        temp = Console.ReadLine()!;
                        if (double.TryParse(temp, out tempDouble))
                            coords.Longtitude = tempDouble;
                        else
                            Console.WriteLine("Введено не число");
                        break;
                    case "4":
                        Console.Write("Введине новую долготу: ");
                        temp = Console.ReadLine()!;
                        if (double.TryParse(temp, out tempDouble))
                            coords.Latitude = tempDouble;
                        else
                            Console.WriteLine("Введено не число");
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
