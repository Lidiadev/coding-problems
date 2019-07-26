using PerformanceOptimizationPatterns.Common;
using System.Collections.Generic;

namespace PerformanceOptimizationPatterns.BreadthFirstSearch
{
    public static class ReverseLevelOrderTraversal
    {
        public static IList<List<int>> Traverse(TreeNode root)
        {
            var result = new List<List<int>>();

            if (root == null)
                return result;
            
            if(root.Left == null && root.Right == null)
            {
                result.Add(new List<int>(root.Value));
                return result;
            }

            var queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            int levelSize;
            List<int> levelNodes;
            TreeNode currentNode;

            while(queue.Count > 0)
            {
                levelSize = queue.Count;
                levelNodes = new List<int>();

                for(int i = 0; i < levelSize; i++)
                {
                    currentNode = queue.Dequeue();
                    levelNodes.Add(currentNode.Value);

                    if (currentNode.Left != null)
                        queue.Enqueue(currentNode.Left);

                    if (currentNode.Right != null)
                        queue.Enqueue(currentNode.Right);
                }

                result.Insert(0, levelNodes);
            }

            return result;
        }

        public static void Test()
        {
            TreeNode root = new TreeNode(12);
            root.Left = new TreeNode(7);
            root.Right = new TreeNode(1);
            root.Left.Left = new TreeNode(9);
            root.Right.Left = new TreeNode(10);
            root.Right.Right = new TreeNode(5);
            ReverseLevelOrderTraversal.Traverse(root).Print();
        }
    }
}
