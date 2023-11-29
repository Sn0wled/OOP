using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SharpClass
{
    enum emp_type : byte
    {
        manager = 10, grunt = 1, contractor = 100, VP = 9
    }

    struct sEmployee
    {
        public emp_type title;
        public string name;
        public short deptID;
        public sEmployee(emp_type et, string n, byte d)
        {
            title = et;
            name = n;
            deptID = d;
        }
    }
    internal class Program
    {
        void DisplayEmployeeStats(sEmployee e)
        {
            Console.WriteLine("{0}: отдел {1}, тип {2}",
                e.name, e.deptID,
                Enum.Format(typeof(emp_type), e.title, "G") + ".");
        }
        static void Main(string[] args)
        {
            Program t = new Program();
            sEmployee bill = new sEmployee(emp_type.VP, "Bill", 10);
            t.DisplayEmployeeStats(bill);
            object bill_inbox = bill;
            // автоупаковка
            t.UnboxsEmployee(bill);
            // packed
            t.UnboxsEmployee(bill_inbox);
        }
        void UnboxsEmployee(object o)
        {
            sEmployee e = (sEmployee)o;
            DisplayEmployeeStats(e);
        }
    }
}
