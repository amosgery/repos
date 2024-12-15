using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rand
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random myrand = new Random();
            Console.WriteLine(myrand.Next(10));
            int num = myrand.Next(50, 100);
            Console.WriteLine(num);
        }
    }
}
