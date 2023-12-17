namespace TransportManagementSystem
{
    internal class WayPoint
    {
        public bool Checkbox {  get; set; }

        public Point Point { get; set; }

        public WayPoint(Point point)
        {
            this.Point = point;
            Checkbox = false;
        }

        public void ShowWayPoint()
        {
            string state = Checkbox == true ? "Пройдена" : "Не пройдена";
            Console.WriteLine($"Состояние: {state}");
            Point.ShowUnit();
            return;
        }

        public void Mark()
        {
            Checkbox = true;
        }

        public void UnMark()
        {
            Checkbox = false;
        }

        public void ReplacePoint(TransportManagementSystem tms)
        {
            tms.PointsSystem.ShowUnits();
            int id = Program.EnterInt("Введите id заменяющего пункта");
            Point? point = (Point?)tms.PointsSystem.FindUnit(id);
            Console.Clear();
            if (point == null)
            {
                Console.WriteLine("Пункт с данным id не найден");
            } else
            {
                this.Point = point;
                Console.WriteLine("Пункт заменен");
            }
        }
    }
}
