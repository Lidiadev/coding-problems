using System;
using System.Collections.Generic;

namespace PerformanceOptimizationPatterns.TopologicalSort
{
    public static class TaskScheduling
    {
        public static bool IsSchedulingPossible(int tasks, int[][] prerequisites)
        {
            if (tasks <= 0)
                return false;

            Dictionary<int, int> verticesCountEdges = new Dictionary<int, int>();
            Dictionary<int, List<int>> parentWithChildrenList = new Dictionary<int, List<int>>();

            for (int i = 0; i < tasks; i++)
            {
                verticesCountEdges.Add(i, 0);
                parentWithChildrenList.Add(i, new List<int>());
            }

            for (int i = 0; i < prerequisites.Length; i++)
            {
                verticesCountEdges[prerequisites[i][1]]++;
                parentWithChildrenList[prerequisites[i][0]].Add(prerequisites[i][1]);
            }

            Queue<int> sources = new Queue<int>();
            for (int i = 0; i < tasks; i++)
            {
                if (verticesCountEdges[i] == 0)
                    sources.Enqueue(i);
            }

            int source;
            IList<int> taskOrderList = new List<int>();
            IList<int> childrenList = new List<int>();
            while (sources.Count > 0)
            {
                source = sources.Dequeue();
                taskOrderList.Add(source);
                childrenList = parentWithChildrenList[source];

                foreach (var child in childrenList)
                {
                    if (verticesCountEdges[child] == 1)
                        sources.Enqueue(child);

                    verticesCountEdges[child]--;
                }
            }

            return tasks == taskOrderList.Count;
        }

        public static void Test()
        {
            Console.WriteLine($"Tasks execution possible: {TaskScheduling.IsSchedulingPossible(3, new int[][] { new int[] { 0, 1 }, new int[] { 1, 2 } })}");
            Console.WriteLine($"Tasks execution possible: {TaskScheduling.IsSchedulingPossible(3, new int[][] { new int[] { 0, 1 }, new int[] { 1, 2 }, new int[] { 2, 0 } })}");
            Console.WriteLine($"Tasks execution possible: {TaskScheduling.IsSchedulingPossible(6, new int[][] { new int[] { 2, 5 }, new int[] { 0, 5 }, new int[] { 0, 4 }, new int[] { 1, 4 }, new int[] { 3, 2 }, new int[] { 1, 3 } })}");
        }
    }
}
