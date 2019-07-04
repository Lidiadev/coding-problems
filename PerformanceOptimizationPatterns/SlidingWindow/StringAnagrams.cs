using PerformanceOptimizationPatterns.Common;
using System.Collections.Generic;

namespace PerformanceOptimizationPatterns.SlidingWindow
{
    public class StringAnagrams
    {
        public static IList<int> FindStringAnagrams(string str, string pattern)
        {
            var resultIndices = new List<int>();

            if (pattern.Length > str.Length)
                return resultIndices;

            var chars = new Dictionary<char, int>();

            for (int i = 0; i < pattern.Length; i++)
            {
                if (chars.ContainsKey(pattern[i]))
                    chars[pattern[i]]++;
                else
                    chars.Add(pattern[i], 1);
            }

            int matches = 0, start = 0;

            for (int i = 0; i < str.Length; i++)
            {
                if(chars.ContainsKey(str[i]))
                {
                    chars[str[i]]--;

                    if (chars[str[i]] == 0)
                        matches++;
                }

                if (matches == chars.Count)
                    resultIndices.Add(start);

                if(i + 1 >= pattern.Length)
                {
                    if(chars.ContainsKey(str[start]))
                    {
                        if (chars[str[start]] == 0)
                            matches--;

                        chars[str[start]]++;
                    }

                    start++;
                }
            }

            return resultIndices;
        }

        public static void Test()
        {
            StringAnagrams.FindStringAnagrams("ppqp", "pq").Print();
            StringAnagrams.FindStringAnagrams("abbcabc", "abc").Print();
        }
    }
}
