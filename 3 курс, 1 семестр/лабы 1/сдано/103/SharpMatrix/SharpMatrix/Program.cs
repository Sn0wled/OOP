using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

interface IMatrix
{
    int this[int i, int j] { get; set; }
}

class Matrix : IMatrix
{
    public int this[int i, int j]
    {
        get
        {
            return matrix[i][j];
        }
        set
        {
            if (0 <= i && i < cols && 0 <= j && j < rows) matrix[i][j] = value;
        }
    }
    protected int[][] matrix;
    protected int cols, rows;
    public Matrix(int x, int y)
    {
        cols = x;
        rows = y;
        matrix = new int[cols][];
        for (int i = 0; i < cols; i++)
        {
            matrix[i] = new int[rows];
        }
    }
    public int Cols
    {
        get { return cols; }
    }
    public int Rows
    {
        get { return rows; }
    }
}

namespace SharpMatrix
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Matrix m = new Matrix(3, 5);
            PrintMatrix(m);
            m[0, 2] = 200;
            m[10, 5] = 20;
            m[1, 4] = 30;
            PrintMatrix(m);
        }
        static private void PrintMatrix(Matrix m)
        {
            int cols = m.Cols, rows = m.Rows;
            for (int i = 0; i < cols; i++)
            {
                for (int j = 0; j < rows; j++)
                {
                    Console.Write("{0}\t", m[i, j]);
                }
                Console.WriteLine();
            }
        }
    }
}
