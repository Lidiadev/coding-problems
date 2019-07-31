using System;

namespace PerformanceOptimizationPatterns.MergeIntervals
{
    public class Interval
    {
        public int Start { get; set; }
        public int End { get; set; }

        public Interval(int start, int end)
        {
            Start = start;
            End = end;
        }

        public void Print()
        {
            Console.WriteLine($"[{Start},{End}]");
        }
    }
}
