using System;
using System.Collections.Generic;

namespace PerformanceOptimizationPatterns.SlidingWindow
{
    static class NoRepeatSubstring
    {
        public static int FindLength(string str)
        {
            Dictionary<char, int> chars = new Dictionary<char, int>();
            int start = 0, maxLength = 0;

            for(int i = 0; i < str.Length; i++)
            {
                if(chars.ContainsKey(str[i]))
                {
                    if(chars[str[i]] >= start)
                    {
                        maxLength = Math.Max(maxLength, i - start);
                        start = i;
                    }
                }

                chars[str[i]] = i; 
            }

            if (maxLength == 0)
                return str.Length;

            return maxLength;
        }

        public static void Test()
        {
            Console.WriteLine($"Length of the longest substring: { NoRepeatSubstring.FindLength("aabccbb")}");
            Console.WriteLine($"Length of the longest substring: { NoRepeatSubstring.FindLength("abbbb")}");
            Console.WriteLine($"Length of the longest substring: { NoRepeatSubstring.FindLength("abccde")}");
            Console.WriteLine($"Length of the longest substring: { NoRepeatSubstring.FindLength("abcdef")}");
            Console.WriteLine($"Length of the longest substring: { NoRepeatSubstring.FindLength("aaaaaa")}");
        }
    }
}
