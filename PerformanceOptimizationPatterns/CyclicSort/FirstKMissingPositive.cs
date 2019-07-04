using PerformanceOptimizationPatterns.Common;
using System.Collections.Generic;

namespace PerformanceOptimizationPatterns.CyclicSort
{
    static class FirstKMissingPositive
    {
        public static List<int> FindNumbers(int[] nums, int k)
        {
            var missingNumbers = new List<int>();
            var extraNumbers = new HashSet<int>();

            int start = 0;

            while(start < nums.Length)
            {
                if (nums[start] > 0 && nums[start] <= nums.Length && nums[start] != nums[nums[start] - 1])
                    Utilities.Swap(nums, start, nums[start] - 1);
                else
                    start++;
            }

            for (int i = 0; i < nums.Length && missingNumbers.Count < k; i++)
            {
                if (nums[i] - 1 != i)
                {
                    missingNumbers.Add(i + 1);
                    extraNumbers.Add(nums[i]);
                }
            }

            int number = nums.Length + 1;

            while(missingNumbers.Count < k)
            {
                if (!extraNumbers.Contains(number))
                    missingNumbers.Add(number);
                number++;
            }

            return missingNumbers;
        }

        public static void Test()
        {
            var missingNumbers = FirstKMissingPositive.FindNumbers(new int[] { 3, -1, 4, 5, 5 }, 3);
            missingNumbers.Print();

            missingNumbers = FirstKMissingPositive.FindNumbers(new int[] { 2, 3, 4 }, 3);
            missingNumbers.Print();

            missingNumbers = FirstKMissingPositive.FindNumbers(new int[] { -2, -3, 4 }, 2);
            missingNumbers.Print();
        }
    }
}
