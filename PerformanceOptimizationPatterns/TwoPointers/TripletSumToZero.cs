using System;
using System.Collections.Generic;

namespace PerformanceOptimizationPatterns.TwoPointers
{
    public static class TripletSumToZero
    {
        public static List<List<int>> SearchTriplets(int[] array)
        {
            Array.Sort(array);

            var triplets = new List<List<int>>();

            for (int i = 0; i < array.Length; i++)
            {
                if (i > 0 && array[i] == array[i - 1]) // skip same element to avoid duplicate triplets
                    continue;

                SearchPairs(array, -array[i], i + 1, triplets);
            }

            return triplets;
        }

        public static void SearchPairs(int[] array, int sum, int left, IList<List<int>> pairs)
        {
            int right = array.Length - 1;

            while (left < right)
            {
                if (array[left] == sum - array[right])
                {
                    pairs.Add(new List<int> { -sum, array[left], array[right] });
                    left++;
                    right--;
                    while (left < right && array[left] == array[left - 1])
                        left++; // skip same element to avoid duplicate triplets
                    while (left < right && array[right] == array[right + 1])
                        right--; // skip same element to avoid duplicate triplets
                }
                else
                {
                    if (array[left] < sum - array[right])
                        left++;
                    else
                        right--;
                }
            }
        }

        static void PrintTriplets(IList<List<int>> triplets)
        {
            Console.WriteLine("Triplets: ");
            foreach (var triplet in triplets)
            {
                Console.Write("( ");
                foreach (var item in triplet)
                    Console.Write($"{item} ");
                Console.Write("),");
            }

            Console.WriteLine();
        }

        public static void Test()
        {
            PrintTriplets(TripletSumToZero.SearchTriplets(new int[] { -3, 0, 1, 2, -1, 1, -2 }));
            PrintTriplets(TripletSumToZero.SearchTriplets(new int[] { -5, 2, -1, -2, 3 }));
        }
    }
}
