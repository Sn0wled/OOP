namespace TransportManagementSystem
{
    internal class UnitSystem
    {
        int counter;
        List<Unit> units;

        public UnitSystem()
        {
            counter = 0;
            units = new();
        }

        public Unit? FindUnit(int id) { return units.Find(x => x.HasID(id)); }

        public void AddUnit(Unit unit)
        {
            unit.SetID(counter++);
            units.Add(unit);
        }

        public bool DelUnit(Unit unit)
        {
            return units.Remove(unit);
        }

        public void ShowUnits()
        {
            if (units.Count != 0)
                foreach (var unit in units)
                {
                    unit.ShowInfo();
                    Console.WriteLine();
                }
            else
                Console.WriteLine("Список пуст");
        }
    }
}
