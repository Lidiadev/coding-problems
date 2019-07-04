using PerformanceOptimizationPatterns.Common;
using System.Collections.Generic;

namespace PerformanceOptimizationPatterns.CyclicSort
{
    static class AllMissingNumbers
    {
        public static IList<int> FindNumbers(int[] nums)
        {
            var missingNumbers = new List<int>();
            int start = 0;

            while(start < nums.Length)
            {
                if (nums[start] != start + 1)
                {
                    if (nums[nums[start] - 1] == nums[start])
                        start++;
                    else
                        Utilities.Swap(nums, start, nums[start] - 1);
                }
                else
                    start++;
            }

            for(int i = 0; i < nums.Length; i++)
            {
                if (nums[i] != i + 1)
                    missingNumbers.Add(i + 1);
            }
            
            return missingNumbers;
        }

        public static void Test()
        {
            var missing = AllMissingNumbers.FindNumbers(new int[] { 2, 3, 1, 8, 2, 3, 5, 1 });
            missing.Print();

            missing = AllMissingNumbers.FindNumbers(new int[] { 2, 4, 1, 2 });
            missing.Print();

            missing = AllMissingNumbers.FindNumbers(new int[] { 2, 3, 2, 1 });
            missing.Print();
        }
    }
}
