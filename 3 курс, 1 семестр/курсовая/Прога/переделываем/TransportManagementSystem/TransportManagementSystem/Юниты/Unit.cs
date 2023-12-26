namespace TransportManagementSystem
{
    internal abstract class Unit
    {
        public int ID { get; set; }

        public Unit()
        {
            ID = 0;
        }

        public virtual void ShowUnit()
        {
            Console.WriteLine($"ID: {ID}");
        }

        public abstract void ChangeUnitData(TransportManagementSystem? tms = null);
    }
}
