using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Stringer : StringIndexer
{
    private string[] ss;
    public Stringer(int n)
    {
        ss = new string[n];
    }
    public string getItem(int m)
    {
        return ss[m];
    }
    public void setItem(int m, string newVal)
    {
        ss[m] = newVal;
    }
    public string this[int m]
    {
        get
        {
            return ss[m];
        }
        set
        {
            ss[m] = value;
        }
    }
}

interface StringIndexer
{
    string this[int m] { get; set; }
}

namespace SharpIndexer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stringer s = new Stringer(2);
            s.setItem(0, "Ann");
            s.setItem(1, "Mary");
            Console.WriteLine(s.getItem(0));
            Console.WriteLine(s.getItem(1));
            s[0] = "John";
            Console.WriteLine(s.getItem(0));

        }
    }
}
