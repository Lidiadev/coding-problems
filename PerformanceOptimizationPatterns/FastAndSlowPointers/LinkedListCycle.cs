using PerformanceOptimizationPatterns.Common;
using System;

namespace PerformanceOptimizationPatterns.FastAndSlowPointers
{
    public class LinkedListCycle
    {
        public static bool HasCycle(ListNode head)
        {
            ListNode slow = head, fast = head;

            while(fast != null && fast.Next != null)
            {
                fast = fast.Next.Next;
                slow = slow.Next;

                if (fast == slow)
                    return true;
            }

            return false;
        }

        public static int GetCycleLength(ListNode head)
        {
            ListNode slow = head, fast = head;

            while (fast != null && fast.Next != null)
            {
                fast = fast.Next.Next;
                slow = slow.Next;

                if (fast == slow)
                   return DetermineCycleLength(slow);
            }

            return 0;
        }

        private static int DetermineCycleLength(ListNode slow)
        {
            int lenght = 0;
            ListNode p = slow;

            do
            {
                lenght++;
                p = p.Next;
            }
            while (p != slow);

            return lenght;
        }

        private static void Print(ListNode head)
        {
            Console.WriteLine($"LinkedList has cycle: {LinkedListCycle.HasCycle(head)}");
            Console.WriteLine($"Cycle length: {LinkedListCycle.GetCycleLength(head)}");
        }

        public static void Test()
        {
            ListNode head = new ListNode(1);
            head.Next = new ListNode(2);
            head.Next.Next = new ListNode(3);
            head.Next.Next.Next = new ListNode(4);
            head.Next.Next.Next.Next = new ListNode(5);
            head.Next.Next.Next.Next.Next = new ListNode(6);

            Print(head);

            head.Next.Next.Next.Next.Next.Next = head.Next.Next;
            Print(head);

            head.Next.Next.Next.Next.Next.Next = head.Next.Next.Next;
            Print(head);
        }
    }
}
