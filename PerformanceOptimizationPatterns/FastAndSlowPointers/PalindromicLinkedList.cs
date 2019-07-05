using PerformanceOptimizationPatterns.Common;
using System;

namespace PerformanceOptimizationPatterns.FastAndSlowPointers
{
    public static class PalindromicLinkedList
    {
        public static bool IsPalindrome(ListNode head)
        {
            bool isPalindrome = true;

            if (head == null || head.Next == null)
                return true;

            ListNode pointer1, pointer2;

            ListNode halfList = FindMiddle(head);
            
            halfList = ReverseList(halfList);

            ListNode copyHalfList = halfList;

            pointer1 = head;
            pointer2 = halfList;

            while (pointer2 != null && isPalindrome)
            {
                if (pointer1.Value != pointer2.Value)
                    isPalindrome = false;

                pointer1 = pointer1.Next;
                pointer2 = pointer2.Next;
            }

            ReverseList(copyHalfList);

            return isPalindrome;
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

        private static ListNode ReverseList(ListNode head)
        {
            ListNode prev = null;
            ListNode next;

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
            head.Next.Next.Next = new ListNode(4);
            head.Next.Next.Next.Next = new ListNode(2);

            Console.WriteLine($"Is palindrome: {PalindromicLinkedList.IsPalindrome(head)}");

            head.Next.Next.Next.Next.Next = new ListNode(2);
            Console.WriteLine($"Is palindrome: {PalindromicLinkedList.IsPalindrome(head)}");
        }
    }
}
