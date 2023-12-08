/*class Program
{
    static public void Main(string[] args)
    {
        //arguments(args);
        dialog();
    }
    static public void arguments(string[] args)
    {
        Console.WriteLine("Hello world!");
        *//*for (int i = 0; i < args.Length; i++)
        {
            Console.WriteLine(args[i]);
        }*//*
        foreach(var arg in args)
        {
            Console.WriteLine(arg);
        }
        for (int i = 0; i < args.Length; i++)
        {
            Console.WriteLine("Parameter {0} is {1}", i, args[i]);
        }
    }
    static public void dialog()
    {
        Console.WriteLine("Как вас называть?");
        string? s = Console.ReadLine();
        Console.WriteLine($"Привет {s}!");
        Console.WriteLine("Сколько вам лет?");
        int? age = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine($"Вам {age} лет (года)");
    }
}*/

/*class Program
{
    static public void Main(string[] args)
    {
        const int size = 5;
        int[,] matrix = new int[size, size];
        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                matrix[i, j] = j + i * size;
            }
        }
        for (int i = 0;i < size; i++)
        {
            for(int j = 0;j < size; j++)
            {
                Console.Write(matrix[i, j] + "\t");
            }
            Console.WriteLine();
        }
        int[][] M= new int[size][];
        for (int i = 0; i < size; i++)
        {
            M[i] = new int[i + 1];
        }
        for(int i = 0; i < M.Length; i++)
        {
            Console.Write($"Строка {i} : {M[i].Length} : \t");
            for(int j = 0; j < M[i].Length; j++)
            {
                Console.Write(M[i][j] + " ");
            }
            Console.WriteLine() ;
        }

        string[] N = new string[] {"123", "456", "789"};
        for (int i =0; i<N.Length; i++) {
            Console.WriteLine(N[i]);
        }
        //search
        int index = Array.BinarySearch(N, "456");
        Console.WriteLine("Найден элемент {0}", index);
        // reverse
        Array.Reverse(N);
        Console.WriteLine("Reversed");
        foreach(string s in N) Console.WriteLine(s);
        // sorting
        Array.Sort(N);
        Console.WriteLine("Sorted");
        foreach (string s in N) Console.WriteLine(s);
        // clear
        Array.Clear(N, 1, 2);
        Console.WriteLine("Cleared");
        foreach (string s in N) Console.WriteLine(s);
    }
}*/

// SharpString

using System.Data.SqlTypes;
using System.Globalization;
using System.Text;

class Program {
    public static void Main(String[] args) {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.WriteLine("C format: {0:C}", 99989.987);
        Console.WriteLine("D19 format: {0:D19}", 99999);
        Console.WriteLine("E format {0:E}", 999996.75432);
        Console.WriteLine("F3 format {0:f3}", 999.9999);
        Console.WriteLine("N format: {0:n}", 99999);
        Console.WriteLine("X format: {0:X}", 99999);
        Console.WriteLine("x format: {0:x}", 99999);
        string s = string.Format("На счету {0:c}", 9999.942);
        Console.WriteLine(s);
        object[] stuff = {"Hi", 2.9, 1, "three", "87"};
        Console.WriteLine("stuff: {0}, {1}, {2}, {3}, {4}", stuff);
        // методы строк
        string strObj = "test";
        string s1 = "TEST";
        if (s1 == strObj) {
            Console.WriteLine("Одно и то же");
        } else {
            Console.WriteLine("Разные строки");
        }
        string newstr = strObj + s1;
        Console.WriteLine($"strObj + s1 = {newstr}");
        for (int i = 0; i < s1.Length; i++) {
            Console.WriteLine($"Char {i} is {s1[i]}");
        }
        // управляющие последовательности
        string a, b, c;
        a = "Применение \"кавычек\"";
        Console.WriteLine(a);
        b = "Применение \"\\\\\" и \"\n\" - C:\\app\n.file";
        Console.WriteLine(b);
        // @ отменяет действие последовательностей
        c = @"Последовательности отметены - C:\app\n.file";
        Console.WriteLine(c);
        string fixeds = "string-String";
        Console.WriteLine(fixeds);
        string uppers = fixeds.ToUpper();
        Console.WriteLine(uppers);
        Console.WriteLine(fixeds);
        // string-builder
        StringBuilder buff = new StringBuilder("Буфер строки");
        buff.Append(", который стал длиннее");
        Console.WriteLine(buff);
        string e = buff.ToString().ToUpper();
        Console.WriteLine(e);
        Console.WriteLine(buff);
    }
}