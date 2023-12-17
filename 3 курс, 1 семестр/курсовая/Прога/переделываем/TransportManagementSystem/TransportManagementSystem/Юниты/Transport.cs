using System.Reflection;

namespace TransportManagementSystem
{
    internal class Transport : Unit
    {
        protected Coordinates coords;
        protected string model;
        public bool HasDriver { get; private set; }

        public Transport(string model)
        {
            coords = new Coordinates(0, 0);
            HasDriver = false;
            this.model = model;
        }

        public void Drive()
        {
            coords = Coordinates.CreateCoords();
        }

        public bool IsAtPoint(Point p)
        {
            return p.Coords.IsEqual(coords);
        }

        public override void ShowUnit()
        {
            base.ShowUnit();
            Console.WriteLine($"Модель: {model}");
            Console.WriteLine($"Координаты");
            coords.Show();
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
                        model = Program.EnterString("Введине новую модель: ", minChars: 1);
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

