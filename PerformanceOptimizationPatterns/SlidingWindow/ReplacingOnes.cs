using System;

namespace PerformanceOptimizationPatterns.SlidingWindow
{
    public class ReplacingOnes
    {
        public static int FindLength(int[] arr, int k)
        {
            int start = 0, countZeros = 0, maxLenght = 0;

            for(int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == 0)
                    countZeros++;

                while(countZeros > k && start < i)
                {
                    if (arr[start] == 0)
                        countZeros--;

                    start++;
                }

                maxLenght = Math.Max(maxLenght, i - start + 1);
            }

            return maxLenght;
        }

        public static void Test()
        {
            Console.WriteLine(ReplacingOnes.FindLength(new int[] { 0, 1, 1, 0, 0, 0, 1, 1, 0, 1, 1 }, 2));
            Console.WriteLine(ReplacingOnes.FindLength(new int[] { 0, 1, 0, 0, 1, 1, 0, 1, 1, 0, 0, 1, 1 }, 3));
            Console.WriteLine(ReplacingOnes.FindLength(new int[] { 1, 1, 1, 1 }, 1));
            Console.WriteLine(ReplacingOnes.FindLength(new int[] { 0, 0, 0, 0 }, 1));
            Console.WriteLine(ReplacingOnes.FindLength(new int[] { 0, 0, 0, 0 }, 5));
            Console.WriteLine(ReplacingOnes.FindLength(new int[] { 1, 1, 1, 0 }, 1));
            Console.WriteLine(ReplacingOnes.FindLength(new int[] { 0 }, 5));
        }
    }
}
