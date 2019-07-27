using PerformanceOptimizationPatterns.Common;
using System.Collections.Generic;

namespace PerformanceOptimizationPatterns.BreadthFirstSearch
{
    public static class LevelAverage
    {
        public static List<double> FindLevelAverages(TreeNode root)
        {
            var result = new List<double>();

            if (root == null)
                return result;

            if (root.Left == null && root.Right == null)
            {
                result.Add(root.Value);
                return result;
            }

            var queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            int levelSize;
            double sum;
            TreeNode currentNode;

            while(queue.Count > 0)
            {
                levelSize = queue.Count;
                sum = 0;

                for(int i = 0; i < levelSize; i++)
                {
                    currentNode = queue.Dequeue();
                    sum += currentNode.Value;

                    if (currentNode.Left != null)
                        queue.Enqueue(currentNode.Left);

                    if (currentNode.Right != null)
                        queue.Enqueue(currentNode.Right);
                }

                result.Add(sum / levelSize);
            }

            return result;
        }

        public static void Test()
        {
            TreeNode root = new TreeNode(12);
            root.Left = new TreeNode(7);
            root.Right = new TreeNode(1);
            root.Left.Left = new TreeNode(9);
            root.Left.Right = new TreeNode(2);
            root.Right.Left = new TreeNode(10);
            root.Right.Right = new TreeNode(5);
            LevelAverage.FindLevelAverages(root).Print();
        }
    }
}
