using System;

namespace PerformanceOptimizationPatterns.BinarySearch
{
    public static class NumberRange
    {
        public static int[] FindRange(int[] arr, int key)
        {
            int[] result = new int[] { -1, -1 };
            int length = arr.Length;

            if (key < arr[0] || key > arr[length - 1])
                return result;

            result[0] = FindIndex(arr, key, false);
            result[1] = FindIndex(arr, key, true);

            // TODO: Write your code here
            return result;
        }

        public static int FindIndex(int[] arr, int key, bool isMax)
        {
            int middle, start = 0, end = arr.Length, index = -1;

            while(start <= end)
            {
                middle = start + (end - start) / 2;
                if(key < arr[middle])
                    end = middle - 1;
                else
                {
                    if (key > arr[middle])
                        start = middle + 1;
                    else
                    {
                        index = middle;

                        if (isMax)
                            start = middle + 1;
                        else
                            end = middle - 1;
                    }
                }
            }

            return index;
        }

        private static void Print(int[] result)
        {
            Console.WriteLine("Range: [" + result[0] + ", " + result[1] + "]");
        }

        public static void Test()
        {
            int[] result = NumberRange.FindRange(new int[] { 4, 6, 6, 6, 9 }, 6);
            Print(result);
            result = NumberRange.FindRange(new int[] { 1, 3, 8, 10, 15 }, 10);
            Print(result);
            result = NumberRange.FindRange(new int[] { 1, 3, 8, 10, 15 }, 12);
            Print(result);
        }
    }
}
