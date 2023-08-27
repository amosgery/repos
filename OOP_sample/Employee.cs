using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_sample
{
    class Employee : Person
    {
        //Fields:
        private double salary;

        //Properties:
        public double Salary
        {
            get { return salary; }
            set
            {
                if (value < 0)
                    throw new Exception("Illegal salary");

                salary = value;
            }
        }

        //C'tors:
        public Employee()
        {
            Salary = 0;
        }

        public Employee(string fName, string lName, double salary)
          : base(fName, lName)
        {
            Salary = salary;
        }

        //Methods:
        public new string Print()
        {
            return base.Print()
                   + string.Format("\nSalary: {0}", Salary);
        }
    }
}
