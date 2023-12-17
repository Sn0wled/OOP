using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportManagementSystem
{
    internal abstract class Unit
    {
        internal int ID { get; set; }

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
