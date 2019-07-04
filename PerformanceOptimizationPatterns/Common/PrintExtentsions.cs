using System;
using System.Collections.Generic;

namespace PerformanceOptimizationPatterns.Common
{
    public static class PrintExtentsions
    {
        public static void Print(this ListNode head)
        {
            while (head != null)
            {
                Console.Write($"{head.Value} ");
                head = head.Next;
            }

            Console.WriteLine();
        }

        public static void Print(this int[] arr)
        {
            foreach (var item in arr)
                Console.Write($"{item} ");

            Console.WriteLine();
        }

        public static void Print(this IList<int> list)
        {
            foreach (var item in list)
                Console.Write($"{item} ");
            Console.WriteLine();
        }

        public static void Print(this IList<List<int>> list)
        {
            foreach (var sublist in list)
            {
                Console.Write("{ ");
                foreach (var item in sublist)
                {
                    Console.Write($"{item} ");
                }
                Console.Write("} ");
            }
            Console.WriteLine();
        }
    }
}
