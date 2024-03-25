using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringsConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MyIndexOf();
            MyEqual();
            MyCompareTo();
            MySubstring();
            MyReplace();
            MyToUpperLower();
            MyStartsWith();
            MyEndsWith();

            Console.ReadLine();
        }

        public static void MyIndexOf()
        {
            string text = "sometimes you win sometimes you learn";
            int x = text.IndexOf("win");
            Console.WriteLine("x=" + x);
            int y = text.IndexOf("lose");
            Console.WriteLine("y=" + y);
        }
        static void MyEqual()
        {
            string text1 = "Hello";

            string text2 = "World";
            bool result1 = text1.Equals(text2);
            Console.WriteLine("result1=" + result1);
            bool result2 = text1.Equals(text1);
            Console.WriteLine("result2=" + result2);
        }

        static void MyCompareTo()
        {
            string text1 = "Hello";
            string text2 = "World";
            int result1 = text1.CompareTo(text2);
            Console.WriteLine("result1=" + result1);
            int result2 = text2.CompareTo(text1);
            Console.WriteLine("result2=" + result2);
            int result3 = text1.CompareTo(text1);
            Console.WriteLine("result3=" + result3);
        }

        public static void MySubstring()
        {
            string text = "think big be bold show your color";
            string text1 = text.Substring(2, 5);
            Console.WriteLine("Substring(2, 5)=" + text1);
            string text2 = text.Substring(10, 18);
            Console.WriteLine("Substring(10,18)=" + text2);
            string text3 = text.Substring(5);
            Console.WriteLine("Substring(5)" + text3);
            string text4 = text.Substring(text.Length);
            Console.WriteLine("Substring(text.Length)=" + text4);
        }

        public static void MyReplace()
        {
            string text = "I like bananas";
            string result1 = text.Replace("bananas", "apples");
            Console.WriteLine("result1=" + result1);
            string result2 = text.Replace('n', '*');
            Console.WriteLine("result2=" + result2);
        }
        public static void MyToUpperLower()
        {
            string text = "sOmEtImEs YoU wIn SoMeTiMeS yOu LeArN";
            string result1 = text.ToUpper();
            Console.WriteLine("result1=" + result1);
            string result2 = text.ToLower();
            Console.WriteLine("result2=" + result2);
        }


        public static void MyStartsWith()
        {
            string text = "Be yourself, everone else is already taken";
            bool result1 = text.StartsWith("Be");
            Console.WriteLine("result1=" + result1);
            bool result2 = text.StartsWith("be");
            Console.WriteLine("result2=" + result2);
        }



        public static void MyEndsWith()
        {
            string text = "Be yourself, everone else is already taken";
            bool result1 = text.EndsWith("taken");
            Console.WriteLine("result1=" + result1);
            bool result2 = text.EndsWith("Taken");
            Console.WriteLine("result2=" + result2);
        }




    }
}
