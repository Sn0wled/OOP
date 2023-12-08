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

class Program
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
    }
}