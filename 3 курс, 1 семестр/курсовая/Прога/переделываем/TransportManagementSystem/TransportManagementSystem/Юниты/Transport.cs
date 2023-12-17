using System.Reflection;

namespace TransportManagementSystem
{
    internal class Transport : Unit
    {
        public Coordinates Coords { get; set; }
        public bool HasDriver { get; set; }
        public string Model { get; set; }

        public Transport(string model)
        {
            Coords = new Coordinates(0, 0);
            HasDriver = false;
            Model = model;
        }


        public void Drive()
        {
            Coords = Coordinates.CreateCoords();
        }

        public bool IsAtPoint(Point p)
        {
            return p.Coords.Equals(Coords);
        }

        public override void ShowUnit()
        {
            base.ShowUnit();
            Console.WriteLine($"Модель: {Model}");
            Console.WriteLine($"Координаты");
            Coords.Show();
            string sState = HasDriver ? "Занят" : "Свободен";
            Console.WriteLine($"Состояние: {sState}");
        }

        public override void ChangeUnitData(TransportManagementSystem? tms = null)
        {
            string s = "";
            while (s != "0")
            {
                Console.WriteLine("Выберите действие:");
                Console.WriteLine("1. Изменить модель");
                Console.WriteLine("0. Вернуться назад");
                s = Console.ReadLine()!;
                switch (s)
                {
                    case "1":
                        Model = Program.EnterString("Введине новую модель: ", minChars: 1);
                        break;
                    case "0":
                        break;
                    default:
                        Program.ErrorInput();
                        break;
                }
            }
        }
    }
}

