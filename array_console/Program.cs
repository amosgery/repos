using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace array_console
{
    internal class Program
    {
        static void Main(string[] args)
        {


            Console.WriteLine("Enter the number of students:");
            int numOfStudents = int.Parse(Console.ReadLine());


            int[] grades = new int[numOfStudents];

            int i;
            Console.WriteLine("Enter the grade of each student:");
            for (i = 0; i < numOfStudents; i++)
            {
                grades[i] = int.Parse(Console.ReadLine());
            }

            int sum = 0;
            for (i = 0; i < numOfStudents; i++)
            {
                sum += grades[i];
            }
            double avg = sum / numOfStudents;
            Console.WriteLine("The average grade is: " + avg);
            int count = 0;
            for (i = 0; i < numOfStudents; i++)
            {
                if (grades[i] > avg)
                {
                    count++;
                }
            }
            Console.WriteLine("The number of grades above average is: "+count);




            Console.WriteLine("Enter the grade to search for:");
            int grade = int.Parse(Console.ReadLine());
            bool exists = false;
            for (i = 0; i < numOfStudents; i++)
            {
                if (grades[i] == grade)
                {
                    Console.WriteLine("Exists");
                    exists = true;
                }
            }
            if (!exists)
                Console.WriteLine("Doesn't exist");

            bool exist = false;
            i = 0;
            while (i < numOfStudents && !exist && grades[i] <= grade)
            {
                if (grades[i] == grade)
                {
                    Console.WriteLine("Exists");
                    exists = true;
                    i++;
                }

            }
            if (!exists)
                Console.WriteLine("Doesn't exist");
        }
    }
}
