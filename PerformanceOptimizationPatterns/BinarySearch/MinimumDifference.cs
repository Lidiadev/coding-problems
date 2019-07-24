using System;

namespace PerformanceOptimizationPatterns.BinarySearch
{
    public class MinimumDifference
    {
        public static int SearchMinDiffElement(int[] arr, int key)
        {
            int start = 0, end = arr.Length - 1, mid;

            if (key <= arr[0])
                return arr[0];

            if (key >= arr[arr.Length - 1])
                return arr[arr.Length - 1];

            while (start <= end)
            {
                mid = start + (end - start) / 2;

                if (arr[mid] == key)
                    return arr[mid];

                if (arr[mid] > key)
                    end = mid - 1;
                else
                    start = mid + 1;
            }

            if (arr[start] - key < arr[end] - key)
                return arr[start];

            return arr[end];
        }

        public static void Test()
        {
            Console.WriteLine(MinimumDifference.SearchMinDiffElement(new int[] { 4, 6, 10 }, 7));
            Console.WriteLine(MinimumDifference.SearchMinDiffElement(new int[] { 4, 6, 10 }, 4));
            Console.WriteLine(MinimumDifference.SearchMinDiffElement(new int[] { 1, 3, 8, 10, 15 }, 12));
            Console.WriteLine(MinimumDifference.SearchMinDiffElement(new int[] { 4, 6, 10 }, 17));
        }
    }
}
