using System;
using System.Collections.Generic;

namespace PerformanceOptimizationPatterns.MergeIntervals
{
    public static class InsertInterval
    {
        public static IList<Interval> Insert(Interval[] intervals, Interval newInterval)
        {
            var mergedIntervals = new List<Interval>();

            if (newInterval == null)
                return mergedIntervals;

            if (intervals == null || intervals.Length == 0)
            {
                mergedIntervals.Add(newInterval);
                return mergedIntervals;
            }

            // sort intervals based on their start 
            Array.Sort(intervals, (a, b) => a.Start.CompareTo(b.Start));

            if (newInterval.End < intervals[0].Start) // insert at the beginning of the list
            {
                mergedIntervals.Add(newInterval);
                mergedIntervals.AddRange(intervals);
            }
            else
            {
                int numberOfIntervals = intervals.Length;

                if (intervals[numberOfIntervals - 1].End < newInterval.Start) // insert at the end of the list
                {
                    mergedIntervals.AddRange(intervals);
                    mergedIntervals.Add(newInterval);
                }
                else 
                {
                    int i = 0;
                    // skip intervals which end before the start of the new interval
                    while (i < numberOfIntervals && intervals[i].End < newInterval.Start)
                    {
                        mergedIntervals.Add(intervals[i]);
                        i++;
                    }

                    // start intersecting intervals
                    while(i < numberOfIntervals && intervals[i].Start <= newInterval.End)
                    {
                        newInterval.Start = Math.Min(intervals[i].Start, newInterval.Start);
                        newInterval.End = Math.Max(intervals[i].End, newInterval.End);
                        i++;
                    }

                    mergedIntervals.Add(newInterval);

                    // add the remaining intervals
                    while(i < numberOfIntervals)
                    {
                        mergedIntervals.Add(intervals[i]);
                        i++;
                    }
                }
            }

            return mergedIntervals;
        }

        public static void Test()
        {
            List<Interval> input = new List<Interval>
            {
                new Interval(1, 3),
                new Interval(5, 7),
                new Interval(8, 12)
            };
            Print(InsertInterval.Insert(input.ToArray(), new Interval(4, 6)));

            input = new List<Interval>
            {
                new Interval(1, 3),
                new Interval(5, 7),
                new Interval(8, 12)
            };
            Print(InsertInterval.Insert(input.ToArray(), new Interval(4, 10)));

            input = new List<Interval>
            {
                new Interval(2, 3),
                new Interval(5, 7)
            };
            Print(InsertInterval.Insert(input.ToArray(), new Interval(1, 4)));

            Print(InsertInterval.Insert(null, new Interval(1, 4)));
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
