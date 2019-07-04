using System;
using System.Collections.Generic;

namespace PerformanceOptimizationPatterns.SlidingWindow
{
    public static class MinimumWindowSubstring
    {
        public static string FindPermutation(string str, string pattern)
        {
            if (pattern.Length > str.Length)
                return string.Empty;

            var chars = new Dictionary<char, int>();
            
            for(int i = 0; i < pattern.Length; i++)
            {
                if (chars.ContainsKey(pattern[i]))
                    chars[pattern[i]]++;
                else
                    chars.Add(pattern[i], 1);
            }

            int start = 0, subStart = 0, matched = 0, minLenght = str.Length + 1;

            for(int i = 0; i < str.Length; i++)
            {
                if(chars.ContainsKey(str[i]))
                {
                    chars[str[i]]--;

                    if (chars[str[i]] == 0)
                        matched++;
                }

                while(matched == pattern.Length)
                {
                    if(minLenght > i - start + 1)
                    {
                        minLenght = i - start + 1;
                        subStart = start;
                    }

                    start++;
                    if(chars.ContainsKey(str[start]))
                    {
                        if (chars[str[start]] == 0)
                            matched--;

                        chars[str[start]]++;
                    }
                }
            }

            return minLenght == str.Length + 1
                ? string.Empty
                : str.Substring(subStart, minLenght);
        }

        public static void Test()
        {
            Console.WriteLine(MinimumWindowSubstring.FindPermutation("aabdec", "abc"));
            Console.WriteLine(MinimumWindowSubstring.FindPermutation("abdabca", "abc"));
            Console.WriteLine(MinimumWindowSubstring.FindPermutation("adcad", "abc"));
        }
    }
}
