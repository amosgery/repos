// See https://aka.ms/new-console-template for more information
using System;
using System.Threading;

namespace myth1
{
    class Program
    {
        static void Main(string[] args)
        {
            ThreadStart threadStart1 = new ThreadStart(Run1);
            Thread thread1 = new Thread(threadStart1);
            Console.WriteLine("Starting threads...");

            ThreadStart threadStart2 = new ThreadStart(Run2);
            Thread thread2 = new Thread(threadStart2);

            thread1.Start();
            thread2.Start();
            thread1.Join();
            thread2.Join();
            Console.WriteLine("Threads done !");
        }

        public static void Run1()
        {
            int x = 8;
            string name = "This is thread 1";
            while (x >= 0)
            {
                Thread.Sleep(2000);
                Console.WriteLine(name + " " + x);
                x--;
            }
            Console.WriteLine("thread 1 finish");
        }
        public static void Run2()
        {
            int x = 8;
            string name = "This is thread 2";
            while (x >= 0)
            {
                Thread.Sleep(1000);
                Console.WriteLine(name + " " + x);
                x--;
            }
            Console.WriteLine("thread 2 finished");
        }

    }
}
