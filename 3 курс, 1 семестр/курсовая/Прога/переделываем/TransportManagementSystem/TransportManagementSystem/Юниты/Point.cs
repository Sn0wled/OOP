using System.Drawing;
using System.Xml.Linq;

namespace TransportManagementSystem
{
    internal class Point : Unit
    {
        public Coordinates Coords { get; set; }

        protected string Name { get; set; }

        protected string Description{ get; set; }

        public Point(Coordinates coords, string name, string description)
        {
            this.Coords = coords;
            this.Name = name;
            this.Description = description;
        }

        public override void ShowUnit()
        {
            base.ShowUnit();
            Console.WriteLine($"Название: {Name}");
            Console.WriteLine($"Описание: {Description}");
            Console.WriteLine("Координаты");
            Coords.Show();
        }

        public override void ChangeUnitData(TransportManagementSystem? tms = null)
        {
            string s = "";
            while (s != "0")
            {
                Console.WriteLine("Выберите действие:");
                Console.WriteLine("1. Изменить название");
                Console.WriteLine("2. Изменить описание");
                Console.WriteLine("3. Изменить широту");
                Console.WriteLine("4. Изменить долготу");
                Console.WriteLine("0. Вернуться назад");
                s = Console.ReadLine()!;
                switch (s)
                {
                    case "1":
                        Name = Program.EnterString("Введине новое название: ");
                        break;
                    case "2":
                        Description = Program.EnterString("Введине новое описание: ");
                        break;
                    case "3":
                        Coords.Latitude = Program.EnterInt("Введине новую широту: ");
                        break;
                    case "4":
                        Coords.Latitude = Program.EnterInt("Введине новую долготу: ");
                        break;
                    case "0":
                        return;
                    default:
                        Program.ErrorInput();
                        break;

                }
            }
        }

    }
}
