using PerformanceOptimizationPatterns.Common;

namespace PerformanceOptimizationPatterns.FastAndSlowPointers
{
    static class RearrangeList
    {
        public static void Reorder(ListNode head)
        {
            if (head == null || head.Next == null)
                return;

            ListNode halfList = FindMiddle(head);

            halfList = Reverse(halfList);

            ListNode pointer1 = head, pointer2 = halfList, node; 

            while(pointer2 != null)
            {
                node = pointer2;
                pointer2 = pointer2.Next;
                node.Next = pointer1.Next;
                pointer1.Next = node;
                pointer1 = node.Next;
            }

            pointer1.Next = null;
        }

        private static ListNode FindMiddle(ListNode head)
        {
            ListNode slow = head, fast = head;

            while(fast != null && fast.Next != null)
            {
                slow = slow.Next;
                fast = fast.Next.Next;
            }

            return slow;
        }

        private static ListNode Reverse(ListNode head)
        {
            ListNode prev = null, next;

            while(head != null)
            {
                next = head.Next;
                head.Next = prev;
                prev = head;
                head = next;
            }

            return prev;
        }

        public static void Test()
        {
            ListNode head = new ListNode(2);
            head.Next = new ListNode(4);
            head.Next.Next = new ListNode(6);
            head.Next.Next.Next = new ListNode(8);
            head.Next.Next.Next.Next = new ListNode(10);
            head.Next.Next.Next.Next.Next = new ListNode(12);
            RearrangeList.Reorder(head);
            head.Print();
        }
    }
}
