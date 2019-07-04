using PerformanceOptimizationPatterns.Common;

namespace PerformanceOptimizationPatterns.CyclicSort
{
    static class CyclicSort
    {
        public static void Sort(int[] nums)
        {
            int start = 0;

            while(start < nums.Length)
            {
                if (nums[start] != start + 1)
                    Utilities.Swap(nums, start, nums[start] - 1);
                else
                    start++;
            }
        }

        public static void Test()
        {
            int[] arr = new int[] { 3, 1, 5, 4, 2 };
            CyclicSort.Sort(arr);
            arr.Print();

            arr = new int[] { 2, 6, 4, 3, 1, 5 };
            CyclicSort.Sort(arr);
            arr.Print();
        }
    }
}
