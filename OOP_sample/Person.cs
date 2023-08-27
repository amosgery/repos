using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_sample
{
    internal class Person
    {
        //Fields:
        string firstName;
        string lastName;

        //Properties:

        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }

        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }

        //C'tors:

        public Person()
          : this("", "")
        {
        }

        public Person(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        //Methods:
        public string Print()
        {
            return string.Format("\nName: {0} {1}",
                                 FirstName, LastName);
        }
    }
}
