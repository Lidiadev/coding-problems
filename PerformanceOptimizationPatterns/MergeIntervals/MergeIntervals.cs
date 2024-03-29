﻿using System;
using System.Collections.Generic;

namespace PerformanceOptimizationPatterns.MergeIntervals
{
    public static class MergeIntervals
    {
        public static List<Interval> Merge(Interval[] intervals)
        {
            var mergedIntervals = new List<Interval>();

            if (intervals.Length <= 1)
                return new List<Interval>(intervals);

            Array.Sort(intervals, (a, b) => a.Start.CompareTo(b.Start));

            Interval result = intervals[0];
            int i = 1;

            while (i < intervals.Length)
            {
                if (Intersect(result, intervals[i]))
                {
                    result = new Interval(result.Start, Math.Max(result.End, intervals[i].End));
                }
                else
                {
                    mergedIntervals.Add(result);
                    result = intervals[i];
                };

                i++;
            }

            mergedIntervals.Add(result);

            return mergedIntervals;
        }

        private static bool Intersect(Interval a, Interval b)
        => (b.Start <= a.End && a.End <= b.End)
            || b.Start <= a.End
            || b.End <= a.End;

        public static void Test()
        {
            List<Interval> input = new List<Interval>
            {
                new Interval(1, 4),
                new Interval(2, 5),
                new Interval(7, 9)
            };
            Print(MergeIntervals.Merge(input.ToArray()));

            input = new List<Interval>
            {
                new Interval(6, 7),
                new Interval(2, 4),
                new Interval(5, 9)
            };
            Print(MergeIntervals.Merge(input.ToArray()));

            input = new List<Interval>
            {
                new Interval(1, 4),
                new Interval(2, 6),
                new Interval(3, 5)
            };
            Print(MergeIntervals.Merge(input.ToArray()));
        }

        private static void Print(IList<Interval> intervals)
        {
            Console.WriteLine();
            foreach (var interval in intervals)
            {
                interval.Print();
            }
        }
    }
}
