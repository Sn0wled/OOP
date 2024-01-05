using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SharpThreadsWait
{
    internal class Program
    {
        private static AutoResetEvent autoEvent;
        static void Main(string[] args)
        {
            Console.WriteLine("Method Main starts");
            autoEvent = new AutoResetEvent(false);
            Thread t = new Thread(Process);
            t.Start();
            Thread.Sleep(3000);
            Console.WriteLine("Main thread signals");
            autoEvent.Set();
            t.Join();
            Console.WriteLine("Method Main ends");
        }
        static void Process()
        {
            Console.WriteLine("Second thread waits for event");
            autoEvent.WaitOne();
            Console.WriteLine("Second thread resume and ends");
        }
    }
}
