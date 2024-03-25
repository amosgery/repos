using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test1
{
    internal class Program
    {
        // See https://aka.ms/new-console-template for more information
        static int[] secret1(int[] arr)
        {
            for (int i = arr.Length - 2; i >= 0; i--)
            {
                arr[i] = arr[i] + arr[i + 1];
            }
            return arr;
        }
        static int[] secret2(int[] arr)
        {
            for (int i = 0; i < arr.Length - 1; i++)
            {
                arr[i] = arr[i] + arr[i + 1];
            }
            return arr;
        }

        static int[] MergeSorted(int[] list1, int[] list2)
        {
            int[] newArr = new int[list1.Length+list2.Length];
            int l1 = 0, l2 = 0;
            for (int i = 0; i < list1.Length+list2.Length;i++)
            {
                if (l1 < list1.Length && l2 < list2.Length)
                {
                    if (list1[l1] < list2[l2])
                    {
                        newArr[i] = list1[l1];
                        l1++;
                    }
                    else
                    {
                        newArr[i] = list2[l2];
                        l2++;
                    }
                }
                else if (l1 == list1.Length)
                {
                    newArr[i] = list2[l2];
                    l2++;
                }
                else
                {
                    newArr[i] = list1[l1];
                    l1++;
                }
            }
            return newArr;
        }
        static void Main(string[] args)
        {


            int[] list1 = { 1, 3, 4, 5 };
            int[] list2 = { 2, 4, 6, 8, 9, 10 };
            int[] arr3 = MergeSorted(list1, list2);
            for (int i = 0; i < arr3.Length; i++)
            {
                Console.WriteLine(arr3[i]);
            }
        }
    }
}
