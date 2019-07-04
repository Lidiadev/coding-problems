using PerformanceOptimizationPatterns.Common;
using System;

namespace PerformanceOptimizationPatterns.FastAndSlowPointers
{
    public static class LinkedListCycleStart
    {
        public static ListNode FindCycleStart(ListNode head)
        {
            ListNode slow = head, fast = head;

            do
            {
                slow = slow.Next;
                fast = fast.Next.Next;
            }
            while (fast != slow);

            int cycleSize = GetCycleLength(slow);

            slow = head;
            fast = head;

            for (int i = 0; i < cycleSize; i++)
                fast = fast.Next;

            while(slow != fast)
            {
                slow = slow.Next;
                fast = fast.Next;
            }

            return slow;
        }

        private static int GetCycleLength(ListNode slow)
        {
            ListNode p = slow;
            int lenght = 0;

            do
            {
                lenght++;
                p = p.Next;
            }
            while (p != slow);

            return lenght;
        }

        private static void Print(ListNode node)
        {
            Console.WriteLine($"LinkedList cycle start: {LinkedListCycleStart.FindCycleStart(node).Value}");
        }

        public static void Test()
        {
            ListNode head = new ListNode(1);
            head.Next = new ListNode(2);
            head.Next.Next = new ListNode(3);
            head.Next.Next.Next = new ListNode(4);
            head.Next.Next.Next.Next = new ListNode(5);
            head.Next.Next.Next.Next.Next = new ListNode(6);

            head.Next.Next.Next.Next.Next.Next = head.Next.Next;
            Print(LinkedListCycleStart.FindCycleStart(head));

            head.Next.Next.Next.Next.Next.Next = head.Next.Next.Next;
            Print(LinkedListCycleStart.FindCycleStart(head));

            head.Next.Next.Next.Next.Next.Next = head;
            Print(LinkedListCycleStart.FindCycleStart(head));
        }
    }
}
