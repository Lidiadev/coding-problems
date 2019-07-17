using System;

namespace PerformanceOptimizationPatterns.BinarySearch
{
    public static class NextLetter
    {
        public static char SearchNextLetter(char[] letters, char key)
        {
            int length = letters.Length;

            if (key < letters[0] || key > letters[length - 1])
                return letters[0];

            int start = 0, end = length - 1;
            while (start <= end)
            {
                int mid = start + (end - start) / 2;
                if (key < letters[mid])
                {
                    end = mid - 1;
                }
                else
                {
                    start = mid + 1;
                }
            }

            // since the loop is running until 'start <= end', so at the end of the while loop, 'start == end+1'
            return start >= length
                ? letters[0] :
                letters[start];
        }

        public static void Test()
        {
            Console.WriteLine(NextLetter.SearchNextLetter(new char[] { 'a', 'c', 'f', 'h' }, 'f'));
            Console.WriteLine(NextLetter.SearchNextLetter(new char[] { 'a', 'c', 'f', 'h' }, 'b'));
            Console.WriteLine(NextLetter.SearchNextLetter(new char[] { 'a', 'c', 'f', 'h' }, 'm'));
            Console.WriteLine(NextLetter.SearchNextLetter(new char[] { 'a', 'c', 'f', 'h' }, 'h'));
        }
    }
}
