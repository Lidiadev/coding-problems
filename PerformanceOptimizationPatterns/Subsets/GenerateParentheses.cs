using PerformanceOptimizationPatterns.Common;
using System;
using System.Collections.Generic;

namespace PerformanceOptimizationPatterns.Subsets
{
    public class ParenthesesString
    {
        public int LeftCount { get; set; }
        public int RightCount { get; set; }

        public string Str { get; set; }

        public ParenthesesString(string str, int leftCount, int rightCount)
        {
            Str = str;
            LeftCount = leftCount;
            RightCount = rightCount;
        }
    }

    public static class GenerateParentheses
    {
        public static IList<string> GenerateValidParentheses(int num)
        {
            var result = new List<string>();

            if (num <= 0)
                return result;

            var queue = new Queue<ParenthesesString>();
            queue.Enqueue(new ParenthesesString("", 0, 0));

            ParenthesesString parentheses; 
            while (queue.Count > 0)
            {
                parentheses = queue.Dequeue();

                if (parentheses.LeftCount + parentheses.RightCount == num * 2)
                    result.Add(parentheses.Str);
                else
                {
                    if (parentheses.LeftCount < num)
                        queue.Enqueue(new ParenthesesString($"{parentheses.Str}(", parentheses.LeftCount + 1, parentheses.RightCount));

                    if (parentheses.RightCount < num && parentheses.LeftCount >= parentheses.RightCount + 1)
                        queue.Enqueue(new ParenthesesString($"{parentheses.Str})", parentheses.LeftCount, parentheses.RightCount + 1));
                }
            }

            return result;
        }

        public static void Test()
        {
            var result = GenerateParentheses.GenerateValidParentheses(2);
            Console.WriteLine("All combinations of balanced parentheses are: ");
            result.Print();

            result = GenerateParentheses.GenerateValidParentheses(3);
            Console.WriteLine("All combinations of balanced parentheses are: ");
            result.Print();
        }
    }
}
