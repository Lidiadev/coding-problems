using PerformanceOptimizationPatterns.Common;
using System.Collections.Generic;

namespace PerformanceOptimizationPatterns.BreadthFirstSearch
{
    public static class ZigzagTraversal
    {
        public static IList<int> Traverse(TreeNode root)
        {
            var result = new List<int>();

            if (root == null)
                return result;

            if (root.Left == null && root.Right == null)
            {
                result.Add(root.Value);
                return result;
            }

            var currentLevel = new Stack<TreeNode>();
            var nextLevel = new Stack<TreeNode>();
            currentLevel.Push(root);
            bool leftToRight = true;
            TreeNode currentNode;

            while (currentLevel.Count > 0)
            {
                currentNode = currentLevel.Pop();
                result.Add(currentNode.Value);

                if (leftToRight)
                {
                    if (currentNode.Left != null)
                        nextLevel.Push(currentNode.Left);

                    if (currentNode.Right != null)
                        nextLevel.Push(currentNode.Right);
                }

                else
                {
                    if (currentNode.Right != null)
                        nextLevel.Push(currentNode.Right);

                    if (currentNode.Left != null)
                        nextLevel.Push(currentNode.Left);
                }

                if (currentLevel.Count == 0)
                {
                    leftToRight = !leftToRight;
                    currentLevel = nextLevel;
                    nextLevel = new Stack<TreeNode>();
                }
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
            root.Right.Left.Left = new TreeNode(20);
            root.Right.Left.Right = new TreeNode(17);
            ZigzagTraversal.Traverse(root).Print();
        }
    }
}
