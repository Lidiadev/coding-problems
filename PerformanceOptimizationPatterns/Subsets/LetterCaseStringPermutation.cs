using PerformanceOptimizationPatterns.Common;
using System;
using System.Collections.Generic;

namespace PerformanceOptimizationPatterns.Subsets
{
    public static class LetterCaseStringPermutation
    {
        public static List<string> findLetterCaseStringPermutations(string str)
        {
            List<String> permutations = new List<string>();
            int lenght = str.Length;

            if (lenght == 0)
                return permutations;
            if (lenght == 1)
            {
                permutations.Add(str);
                return permutations;
            }

            string currentPermutation, permutation;
            char currentLetter;
            int currentLenght;

            permutations.Add(str);

            for (int i = 0; i < lenght; i++)
            {
                if (str[i] >= 'a' && str[i] <= 'z')
                {
                    currentLenght = permutations.Count;
                    currentLetter = char.ToUpper(str[i]);

                    for (int j = 0; j < currentLenght; j++)
                    {
                        permutation = permutations[j];
                        currentPermutation = $"{permutation.Substring(0, i)}{currentLetter}";

                        if (i < lenght - 1)
                            currentPermutation = $"{currentPermutation}{permutation.Substring(i + 1, lenght - i - 1)}";

                        permutations.Add(currentPermutation);
                    }
                }
            }

            return permutations;
        }

        public static void Test()
        {
            LetterCaseStringPermutation.findLetterCaseStringPermutations("ad52").Print();
            LetterCaseStringPermutation.findLetterCaseStringPermutations("ab7c").Print();
        }
    }
}
