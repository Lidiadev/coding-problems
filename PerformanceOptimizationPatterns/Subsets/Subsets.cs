using PerformanceOptimizationPatterns.Common;
using System.Collections.Generic;

namespace PerformanceOptimizationPatterns.Subsets
{
    public class Subsets
    {
        public static IList<List<int>> FindSubsets(int[] nums)
        {
            IList<List<int>> subsets = new List<List<int>>();
            List<int> currentList;
            int size;

            subsets.Add(new List<int>());

            foreach (var number in nums)
            {
                size = subsets.Count;

                for(int i = 0; i < size; i++) 
                {
                    currentList = new List<int>(subsets[i]);
                    currentList.Add(number);
                    subsets.Add(currentList);
                }
            }

            return subsets;
        }

        public static void Test()
        {
            Subsets.FindSubsets(new int[] { 1, 3 }).Print();
            Subsets.FindSubsets(new int[] { 1, 5, 3 }).Print();
        }
    }
}
