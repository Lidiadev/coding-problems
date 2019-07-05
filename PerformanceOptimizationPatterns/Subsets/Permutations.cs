using PerformanceOptimizationPatterns.Common;
using System.Collections.Generic;

namespace PerformanceOptimizationPatterns.Subsets
{
    static class Permutations
    {
        public static IList<List<int>> FindPermutations(int[] nums)
        {
            var subsets = new List<List<int>>();
            List<int> currentList;
            List<List<int>> currentSubset;
            int size;

            subsets.Add(new List<int>());

            foreach(var num in nums)
            {
                size = subsets.Count;
                currentSubset = new List<List<int>>();

                for (int i = 0; i < size; i++)
                {
                    for (int j = 0; j < subsets[i].Count + 1; j++)
                    {
                        currentList = new List<int>(subsets[i]);
                        currentList.Insert(j, num);
                        currentSubset.Add(currentList);
                    }
                }

                subsets = currentSubset;
            }

            return subsets;
        }

        public static void Test()
        {
            Permutations.FindPermutations(new int[] { 1, 3, 5 }).Print();
        }
    }
}
