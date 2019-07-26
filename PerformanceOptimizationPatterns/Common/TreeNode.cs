using System;
using System.Collections.Generic;
using System.Text;

namespace PerformanceOptimizationPatterns.Common
{
    public class TreeNode
    {
        public TreeNode Left { get; set; }
        public TreeNode Right { get; set; }
        public int Value { get; set; }

        public TreeNode(int value)
        {
            Value = value;
        }
    }
}
