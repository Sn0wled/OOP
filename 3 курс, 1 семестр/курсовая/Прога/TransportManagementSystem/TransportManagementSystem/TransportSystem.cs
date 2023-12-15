using System.Drawing;

namespace TransportManagementSystem {
    internal class TransportSystem {
        int counter;
        protected List<Transport> transports;
        public TransportSystem() {
            transports = new();
            counter = 0;
        }
        public void ShowTransport( ) {
            if (transports.Count == 0) {
                Console.WriteLine("Список транспорта пуст");
                return;
            }
            foreach( Transport transport in transports ) {
                transport.ShowInfo();
                Console.WriteLine();
            }
        }

        public void AddTransport( ) {
            string model, sLongtitude, sLatitude;
            double latitude, longitude;
            Console.Write("Введите модель:");
            model = Console.ReadLine()!;
            Console.Write("Введите широту: ");
            sLatitude = Console.ReadLine()!;
            while (!double.TryParse(sLatitude, out latitude)) {
                Console.Write("Введите широту: ");
                Console.WriteLine("Неверный ввод");
                sLatitude = Console.ReadLine()!;
            }
            Console.Write("Введите долготу: ");
            sLongtitude = Console.ReadLine()!;
            while (!double.TryParse(sLongtitude, out longitude)) {
                Console.WriteLine("Неверный ввод");
                Console.Write("Введите долготу: ");
                sLatitude = Console.ReadLine()!;
            }
            transports.Add(new Transport(new Coordinates(longitude, latitude), model, counter++));
            Console.WriteLine("Транспорт успешно добавлен");
        }

        public void FindTransport( ) {
            Console.WriteLine("Введите id транспорта");
            string sID = Console.ReadLine()!;
            int id;
            while (!int.TryParse(sID, out id)) {
                Console.WriteLine("Введено не число");
                Console.WriteLine("Введите id транспорта");
                sID = Console.ReadLine()!;
            }
            Transport? transport = transports.Find(x => x.HasID(id));
            if (transport == null) {
                Console.WriteLine("Точка не найдена");
                return;
            } else {
                FoundTransportMenu(transport);
            }
        }
        public void FoundTransportMenu( Transport transport ) {
            while (true) {
                transport.ShowInfo();
                Console.WriteLine("Выбеирте действие:");
                Console.WriteLine("1. Удалить транспорт");
                Console.WriteLine("2. Изменить данные транспорта");
                Console.WriteLine("0. Вернуться назад");
                string s = Console.ReadLine()!;
                switch (s) {
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
