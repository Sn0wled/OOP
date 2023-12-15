using System.Drawing;

namespace TransportManagementSystem
{
    internal class TransportSystem
    {
        int counter;
        protected List<Transport> transports;
        public TransportSystem()
        {
            transports = new();
            counter = 0;
        }
        public void ShowTransport()
        {
            if (transports.Count == 0)
            {
                Console.WriteLine("Список транспорта пуст");
                return;
            }
            foreach (Transport transport in transports)
            {
                transport.ShowInfo();
                Console.WriteLine();
            }
        }

        public void AddTransport()
        {
            string model;
            double latitude, longitude;
            Console.Write("Введите модель:");
            model = Console.ReadLine()!;
            latitude = Programm.EnterDouble("Введите широту: ");
            longitude = Programm.EnterDouble("Введите долготу: ");
            transports.Add(new Transport(new Coordinates(longitude, latitude), model, counter++));
            Console.WriteLine("Транспорт успешно добавлен");
        }

        public Transport? GetTransport(int id)
        {
            return transports.Find(x => x.HasID(id));
        }

        public void FindTransport()
        {
            int id = Programm.EnterInt("Введите id транспорта");
            Transport? transport = transports.Find(x => x.HasID(id));
            if (transport == null)
            {
                Console.WriteLine("Транспорт не найден");
                return;
            }
            else
            {
                FoundTransportMenu(transport);
            }
        }
        public void FoundTransportMenu(Transport transport)
        {
            while (true)
            {
                transport.ShowInfo();
                Console.WriteLine("Выбеирте действие:");
                Console.WriteLine("1. Удалить транспорт");
                Console.WriteLine("2. Изменить данные транспорта");
                Console.WriteLine("0. Вернуться назад");
                string s = Console.ReadLine()!;
                switch (s)
                {
                    case "1":
                        transports.Remove(transport);
                        return;
                    case "2":
                        transport.ChangeData();
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
