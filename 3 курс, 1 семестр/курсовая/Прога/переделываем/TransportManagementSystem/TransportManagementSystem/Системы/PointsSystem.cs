
namespace TransportManagementSystem
{
    internal class PointsSystem : UnitSystem
    {
        public override bool AddUnit(Unit unit)
        {
            if (unit is Point) return base.AddUnit(unit);
            return false;
        }

        public override void ShowUnits()
        {
            Console.WriteLine("Список доступных пунктов");
            Console.WriteLine("");
            base.ShowUnits();
        }

        public override void CreateUnit()
        {
            string name, description;
            name = Program.EnterString("Введите название точки: ");
            description = Program.EnterString("Введите описание точки: ");
            Coordinates coords = Coordinates.CreateCoords();
            AddUnit(new Point(coords, name, description));
            Console.Clear() ;
            Console.WriteLine("Пункт добавлен");
        }


    }
}
