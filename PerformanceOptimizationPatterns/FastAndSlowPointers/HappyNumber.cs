using System;

namespace PerformanceOptimizationPatterns.FastAndSlowPointers
{
    public static class HappyNumber
    {
        public static bool Find(int num)
        {
            int slow = num, fast = num;

            do
            {
                slow = GetSqrtNum(slow);
                fast = GetSqrtNum(GetSqrtNum(fast));
            }
            while (slow != fast);

            return slow == 1;
        }

        private static int GetSqrtNum(int num)
        {
            int sum = 0, digit;

            while(num > 0)
            {
                digit = num % 10;
                sum += digit * digit;
                num = num / 10;
            }

            return sum;
        }

        public static void Test()
        {
            Console.WriteLine(HappyNumber.Find(23));
            Console.WriteLine(HappyNumber.Find(12));
        }
    }
}
