using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace table
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = 2;
            int[,] arr0 = new int[size,size];
            int[,] arr1 = {
                {1, 2, 3},
                {4, 5, 6},
                {7, 8, 9}
            };
            Console.WriteLine("arr0.Length = " + arr0.Length);
            
            int[,] grades = GetGrades(size);
            
            PrintTable(grades);

            Console.ReadLine();
        }

        static int[,] GetGrades(int n)
        {
            int[,] grades = new int[n, 5];
            for (int row = 0; row < n; row++)
                for (int col = 0; col < 5; col++)
                    grades[row, col] = int.Parse(Console.ReadLine());
            return grades;
        }

        static void PrintTable(int[,] grades)
        {
            for (int row = 0; row < grades.GetLength(0); row++)
            {
                for (int col = 0; col < grades.GetLength(1); col++)
                    Console.Write(grades[row, col] + " ");

                Console.WriteLine();
            }
        }

    }
}
