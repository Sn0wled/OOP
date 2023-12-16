using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportManagementSystem
{
    internal class Unit
    {
        int id;

        public Unit()
        {
            id = 0;
        }

        public void SetID(int id) { this.id = id; }

        public bool HasID(int id) { return this.id == id; }

        public virtual void ShowInfo()
        {
            Console.WriteLine($"ID: {id}");
        }
    }
}
