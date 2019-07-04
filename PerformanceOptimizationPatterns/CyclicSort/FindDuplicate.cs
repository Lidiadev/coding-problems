using System;

namespace PerformanceOptimizationPatterns.CyclicSort
{
    static class FindDuplicate
    {
        public static int FindNumber(int[] nums)
        {
            int start = 0;

            while(start < nums.Length)
            {
                if (start + 1 != nums[start])
                {
                    if (nums[nums[start] - 1] == nums[start])
                        return nums[start];
                    else
                        Utilities.Swap(nums, nums[start] - 1, start);
                }
                else
                    start++;
            }

            return -1;
        }

        public static void Test()
        {
            Console.WriteLine(FindDuplicate.FindNumber(new int[] { 1, 4, 4, 3, 2 }));
            Console.WriteLine(FindDuplicate.FindNumber(new int[] { 2, 1, 3, 3, 5, 4 }));
            Console.WriteLine(FindDuplicate.FindNumber(new int[] { 2, 4, 1, 4, 4 }));
        }
    }
}
