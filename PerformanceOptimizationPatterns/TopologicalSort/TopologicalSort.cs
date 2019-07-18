using PerformanceOptimizationPatterns.Common;
using System.Collections.Generic;

namespace PerformanceOptimizationPatterns.TopologicalSort
{
    public static class TopologicalSort
    {
        public static IList<int> Sort(int vertices, int[][] edges)
        {
            var sortedOrder = new List<int>();

            if (vertices <= 0)
                return sortedOrder;

            Dictionary<int, int> childCountNumberOfParentsDictionary = new Dictionary<int, int>();
            Dictionary<int, HashSet<int>> parentChildren = new Dictionary<int, HashSet<int>>();

            // initialize
            for (int i = 0; i < vertices; i++)
            {
                childCountNumberOfParentsDictionary.Add(i, 0);
                parentChildren.Add(i, new HashSet<int>());
            }

            int child, parent;
            HashSet<int> children;

            for (int i = 0; i < edges.Length; i++)
            {
                // increment count for child
                child = edges[i][1];
                childCountNumberOfParentsDictionary[child] = childCountNumberOfParentsDictionary[child] + 1;

                // add the child to its parent list
                parent = edges[i][0];
                children = parentChildren[parent];
                children.Add(child);
            }

            Queue<int> sources = new Queue<int>();

            // get initial sources (vertices that do not have any children)
            for (int i = 0; i < vertices; i++)
            {
                if (childCountNumberOfParentsDictionary[i] == 0)
                    sources.Enqueue(i);
            }

            int source;
            // for each source, add it to the final list and remove from the queue 
            // and decrement count of parents for its children
            while (sources.Count > 0)
            {
                source = sources.Dequeue();
                sortedOrder.Add(source);

                children = parentChildren[source];
                foreach (var item in children)
                {
                    childCountNumberOfParentsDictionary[item]--;

                    if (childCountNumberOfParentsDictionary[item] == 0) // child has become a source
                        sources.Enqueue(item);
                }
            }

            if (sortedOrder.Count != vertices) // graph has a cycle
                return new List<int>();

            return sortedOrder;
        }

        public static void Test()
        {
            var result = TopologicalSort.Sort(4, new int[][] { new int[] { 3, 2 }, new int[] { 3, 0 }, new int[] { 2, 0 }, new int[] { 2, 1 } });

            result.Print();

            result = TopologicalSort.Sort(5, new int[][] { new int[] { 4, 2 }, new int[] { 4, 3 }, new int[] { 2, 0 },
            new int[] { 2, 1 }, new int[] { 3, 1 } });
            result.Print();

            result = TopologicalSort.Sort(7, new int[][] { new int[] { 6, 4 }, new int[] { 6, 2 }, new int[] { 5, 3 },
            new int[] { 5, 4 }, new int[] { 3, 0 }, new int[] { 3, 1 }, new int[] { 3, 2 }, new int[] { 4, 1 } });
            result.Print();
        }
    }
}
