using System;
using System.Collections.Generic;

namespace PerformanceOptimizationPatterns.SlidingWindow
{
    static class StringPermutation
    {
        public static bool FindPermutation(string str, string pattern)
        {
            Dictionary<char, int> chars = new Dictionary<char, int>();

            if (str.Length < pattern.Length)
                return false;

            for (int i = 0; i < pattern.Length; i++)
            {
                if (chars.ContainsKey(pattern[i]))
                    chars[pattern[i]]++;
                else
                    chars.Add(pattern[i], 1);
            }

            int matchedChars = 0, start = 0;

            for (int i = 0; i < str.Length; i++)
            {
                if (chars.ContainsKey(str[i]))
                {
                    chars[str[i]]--;

                    if (chars[str[i]] == 0)
                        matchedChars++;
                }

                if (matchedChars == chars.Values.Count)
                    return true;

                if (i + 1 >= pattern.Length)
                {
                    if (chars.ContainsKey(str[start]))
                    {
                        if (chars[str[start]] == 0)
                            matchedChars--;

                        chars[str[start]]++;
                    }
                    start++;
                }
            }
            return false;
        }

        public static void Test()
        {
            Console.WriteLine(StringPermutation.FindPermutation("oidbcaf", "abc"));
            Console.WriteLine(StringPermutation.FindPermutation("odicf", "dc"));
            Console.WriteLine(StringPermutation.FindPermutation("bcdxabcdy", "bcdyabcdx"));
            Console.WriteLine(StringPermutation.FindPermutation("aacb", "abc"));

            Console.WriteLine(StringPermutation.FindPermutation("acb", "abc"));
            Console.WriteLine(StringPermutation.FindPermutation("abc", "abc"));
            Console.WriteLine(StringPermutation.FindPermutation("ac", "abc"));
            Console.WriteLine(StringPermutation.FindPermutation("dfgccccbaaa", "abc"));
            Console.WriteLine(StringPermutation.FindPermutation("dfgccccbbaaa", "abc"));
            Console.WriteLine(StringPermutation.FindPermutation("dfgccccbbaaa", "a"));
        }
    }
}
