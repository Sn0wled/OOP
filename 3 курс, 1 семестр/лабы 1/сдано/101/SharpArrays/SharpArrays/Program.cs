using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpArrays {
    internal class Program {
        static void Main(string[] args) {
            // Размер массива
            const int size = 5;
            int[,] matrix = new int[size, size];
            // Заполняем массив
            for (int i = 0; i < size; i++) {
                for (int j = 0; j < size; j++) {
                    matrix[i, j] = j + i * size;
                }
            }
            // Выводи массив
            for (int i = 0; i < size; i++) {
                for (int j = 0; j < size; j++) {
                    Console.Write(matrix[i, j] + "\t");
                }
                Console.WriteLine();
            }
            // Ломанный массив
            int[][] M = new int[size][];
            // Создаем массивы
            for (int i = 0; i < M.Length; i++) {
                M[i] = new int[i + 1];
            }
            // Выводим массивы
        }
    }
}
