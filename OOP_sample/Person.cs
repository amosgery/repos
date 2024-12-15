using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_sample
{
    internal class Person
    {


        //Properties:
        public string FirstName { get; set; }
        public string LastName { get; set; }

        private int Id;

        //C'tors:

        public Person()
        {
        }

        public Person(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        //Methods:
        public void SetId(int id)
        {
            Id = id;
        }

        public string Print()
        {
            return string.Format("\nName: {0} {1}",
                                 FirstName, LastName);
        }
    }
}
