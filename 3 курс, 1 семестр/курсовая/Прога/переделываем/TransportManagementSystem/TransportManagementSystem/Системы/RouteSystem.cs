
namespace TransportManagementSystem
{
    internal class RouteSystem : UnitSystem
    {
        public override bool AddUnit(Unit unit)
        {
            if (unit is Route) return base.AddUnit(unit);
            return false;
        }

        public override void ShowUnits()
        {
            Console.Clear();
            Console.WriteLine("Список доступных маршрутов");
            Console.WriteLine();
            base.ShowUnits();
        }

        public override void CreateUnit()
        {
            string name = Program.EnterString("Введите название маршрута: ", "Название не может быть пустым", 1);
            AddUnit(new Route(name));
            Console.Clear();
            Console.WriteLine("Маршрут создан");
        }
    }
}
