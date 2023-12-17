
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
            Console.Clear() ;
            Console.WriteLine("Транспорт добавлен");
        }
    }
}
