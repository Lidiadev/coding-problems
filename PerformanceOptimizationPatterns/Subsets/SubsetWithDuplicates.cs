using PerformanceOptimizationPatterns.Common;
using System.Collections.Generic;

namespace PerformanceOptimizationPatterns.Subsets
{
    public static class SubsetWithDuplicates
    {
        public static IList<List<int>> FindSubsets(int[] nums)
        {
            var subsets = new List<List<int>>();
            List<int> currentList;
            int size = 0, start;

            subsets.Add(new List<int> { });

            for(int i = 0; i < nums.Length; i++)
            {
                start = 0;

                if (i > 0 && nums[i - 1] == nums[i])
                    start = size;

                size = subsets.Count;

                for(int j = start; j < size; j++)
                {
                    currentList = new List<int>(subsets[j]);
                    currentList.Add(nums[i]);
                    subsets.Add(currentList);
                }
            }

            return subsets;
        }

        public static void Test()
        {
            SubsetWithDuplicates.FindSubsets(new int[] { 1, 3, 3 }).Print();
            SubsetWithDuplicates.FindSubsets(new int[] { 1, 5, 3, 3 }).Print();
        }
    }
}
