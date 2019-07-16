using System;
using System.Collections.Generic;
using System.Text;

namespace PerformanceOptimizationPatterns.BinarySearch
{
    public class BinarySearch
    {
        public static int Search(int[] arr, int key)
        {
            int lenght = arr.Length, start, end, middle;
            bool isAscending;

            if (arr[0] < arr[lenght - 1]) // sorted asc
            {
                isAscending = true;

                if (key < arr[0] || arr[lenght - 1] < key)
                    return -1;
            }
            else
            {
                isAscending = false;

                if (key > arr[0] || arr[lenght - 1] > key)
                    return -1;
            }

            start = 0;
            end = lenght - 1;

            while (start <= end)
            {
                middle = (start + end) / 2;

                if (arr[middle] == key)
                    return middle;

                if (isAscending)
                {
                    if (key > arr[middle])
                        start = middle + 1;
                    else
                        end = middle - 1;
                }
                else
                {
                    if (key > arr[middle])
                        end = middle - 1;
                    else
                        start = middle + 1;
                }
            }

            return -1;
        }

        public static void Test()
        {
            Console.WriteLine(BinarySearch.Search(new int[] { 4, 6, 10 }, 10));
            Console.WriteLine(BinarySearch.Search(new int[] { 1, 2, 3, 4, 5, 6, 7 }, 5));
            Console.WriteLine(BinarySearch.Search(new int[] { 1, 2, 3, 4, 5, 6, 7 }, 8));
            Console.WriteLine(BinarySearch.Search(new int[] { 10, 6, 4 }, 10));
            Console.WriteLine(BinarySearch.Search(new int[] { 10, 6, 4 }, 4));
            Console.WriteLine(BinarySearch.Search(new int[] { 10, 6, 4 }, 2));
        }
    }
}
