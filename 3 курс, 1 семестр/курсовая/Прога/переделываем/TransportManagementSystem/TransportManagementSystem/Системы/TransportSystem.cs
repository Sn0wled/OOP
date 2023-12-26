namespace TransportManagementSystem
{
    internal class TransportSystem : UnitSystem
    {
        public override bool AddUnit(Unit unit)
        {
            if (unit is Transport) return base.AddUnit(unit);
            return false;
        }

        public override void ShowUnits()
        {
            Console.Clear();
            Console.WriteLine("Список доступного транспорта");
            Console.WriteLine();
            base.ShowUnits();
        }

        public override void CreateUnit()
        {
            Console.Clear();
            string model = Program.EnterString("Введите название модели транспорта: ", "Название не может быть пустым", 1);
            AddUnit(new Transport(model));
            Console.Clear();
            Console.WriteLine("Транспорт добавлен");
        }

        public Transport? SetDriver()
        {
            int id = Program.EnterInt("Введите id транспорта: ");
            Transport? transport = (Transport?)FindUnit(id);
            Console.Clear();
            if (transport == null)
            {
                Console.WriteLine("Транспорт с указанным id не найден");
            }
            else
            {
                if (transport.HasDriver)
                {
                    Console.WriteLine("У этого транспорта уже есть водитель");
                }
                else
                {
                    return transport;
                }
            }
            return null;
        }
    }
}
