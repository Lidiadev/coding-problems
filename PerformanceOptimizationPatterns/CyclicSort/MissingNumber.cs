using System;
namespace PerformanceOptimizationPatterns.CyclicSort
{
    static class MissingNumber
    {
        public static int FindMissingNumber(int[] nums)
        {
            int start = 0;

            while (start < nums.Length)
            {
                if (start < nums.Length && nums[start] != start && nums[start] < nums.Length)
                {
                    Utilities.Swap(nums, start, nums[start]);
                }
                else
                    start++;
            }

            for (int i = 0; i < nums.Length; i++)
                if (nums[i] != i)
                    return i;

            return nums.Length;
        }

        public static void Test()
        {
            Console.WriteLine(MissingNumber.FindMissingNumber(new int[] { 4, 0, 3, 1 }));
            Console.WriteLine(MissingNumber.FindMissingNumber(new int[] { 8, 3, 5, 2, 4, 6, 0, 1 }));
        }
    }
}
