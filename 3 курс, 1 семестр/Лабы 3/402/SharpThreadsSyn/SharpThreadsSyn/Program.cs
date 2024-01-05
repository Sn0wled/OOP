using System;
using System.Reflection;
using System.Runtime.CompilerServices;

internal class Program
{
    private static void Main(string[] args)
    {
        /*Worker w1 = new("A");
        Worker w2 = new("B");
        Worker w3 = new("C");
        Thread t1 = new(w1.DoWork);
        Thread t2 = new(w2.DoWork);
        Thread t3 = new(w3.DoWork);
        t1.Start();
        t2.Start();
        t3.Start();*/

        // synchronized
        Worker w1 = new("A");
        Thread t1 = new(w1.DoWork);
        Thread t2 = new(w1.DoWork);
        Thread t3 = new(w1.DoWork);
        t1.Start();
        t2.Start();
        t3.Start();
    }
}

internal class Worker
{
    private string name = "noname";
    public Worker(string name)
    {
        this.name = name;
    }
    [MethodImpl(MethodImplOptions.Synchronized)]
    public void DoWork()
    {
        /*lock (locker)
        {
            for (int i = 0; i < 5; i++)
            {
                Console.Write("Worker ");
                Thread.Sleep(2);
                Console.Write(name);
                Console.Write("-");
                Console.Write(i + " ");
                Thread.Sleep(1);
                Console.WriteLine();
            }
        }*/

        /*Monitor.Enter(locker);
        try
        {
            for (int i = 0; i < 5; i++)
            {
                Console.Write("Worker ");
                Thread.Sleep(2);
                Console.Write(name);
                Console.Write("-");
                Console.Write(i + " ");
                Thread.Sleep(1);
                Console.WriteLine();
            }
        }
        finally
        {
            Monitor.Exit(locker);
        }*/


        for (int i = 0; i < 5; i++)
        {
            Console.Write("Worker ");
            Thread.Sleep(2);
            Console.Write(name);
            Console.Write("-");
            Console.Write(i + " ");
            Thread.Sleep(1);
            Console.WriteLine();
        }
    }
    static object locker = new();
}