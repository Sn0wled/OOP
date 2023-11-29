using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpHello
{
    internal class Sharp {
        static void Main(string[] args) {
            dialog();
        }
        static void arguments(string[] args) {
            Console.WriteLine("Hello, World!");
            foreach (string s in args) {
                Console.WriteLine(s);
            }
            for (int i = 0; i < args.Length; i++) {
                Console.WriteLine("Parameter {0} is {1}", i, args[i]);
            }
        }
        static void dialog() {
            Console.Write("Как вас называть: ");
            string s;
            s = Console.ReadLine();
            Console.WriteLine("Привет, {0}!", s);
            Console.Write("Ваш возраст: ");
            s = Console.ReadLine();
            Console.WriteLine("Вам {0} лет (года).", s);
        }
    }
}
