using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_sample
{
    internal class Student : Person
    {
        //Fields:
        private int[] grades;

        //Properties:
        public int[] Grades
        {
            get { return grades; }
            set { grades = value; }
        }

        //C'tors:
        public Student()
        {
            Grades = new int[5];
        }

        public Student(string fName, string lName, int[] grades)
          : base(fName, lName)
        {
            Grades = grades;
        }

        //Methods:
        public new string Print()
        {
            string str = base.Print() + "\nGrades:\t";

            foreach (int g in Grades)
                str += g + "\t";

            return str;
        }
    }
}
