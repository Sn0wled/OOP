using System.Xml.Linq;

namespace TransportManagementSystem {
    internal class Transport {
        Coordinates coords;
        TransportState state;
        int id;
        string model;
        public Transport( Coordinates coords, string model, int id ) {
            this.coords = coords;
            state = TransportState.Free;
            this.id = id;
            this.model = model;
        }
        public void ShowInfo( ) {
            Console.WriteLine($"ID: {id}");
            Console.WriteLine($"Модель: {model}");
            Console.WriteLine($"Координаты:");
            Console.WriteLine($"Широта: {coords.Longtitude}, Долгота: {coords.Latitude}");
            string sState = state == TransportState.Free? "Свободен" : "Занят";
            Console.WriteLine($"Состояние: {sState}");
        }
        public bool HasID(int id) {
            return this.id == id;
        }
        public void ChangeData( ) {
            while (true) {
                Console.WriteLine("Выберите действие:");
                Console.WriteLine("1. Изменить модель");
                Console.WriteLine("0. Вернуться назад");
                string s = Console.ReadLine()!;
                switch (s) {
                    case "1":
                        Console.Write("Введине новую модель: ");
                        model = Console.ReadLine()!;
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

enum TransportState {
    Occupied,
    Free
}
