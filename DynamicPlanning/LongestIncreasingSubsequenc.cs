using System;
using System.Linq;

namespace CSharpAlgorithm.DynamicPlanning
{

    public partial class DynamicPlanningSolution
    {
        public static int LongestIncreasingSubsequence(int[] a)
        {
            int[] f = new int[a.Length];
            int longest = f[0];

            for(int i=1;i<a.Length;i++)
            {
                for (int j = i - 1; j >= 0; j--)
                {

                    if (a[i] > a[j])
                    {
                        f[i] = Math.Max(f[i], f[j] + 1);
                    }
                }

                longest = Math.Max(f[i]+1, longest);
            }

            return longest;
        }

        public static bool TestLongestIncreasingSubsequence(out string result)
        {
            result = "TestLongestIncreasingSubsequence OK";

            int[] a = { 1, 2, 3, 2, 9,4, 6, 6, 2, 12, 3, 4, 5, 3, 1 };

            int longest = LongestIncreasingSubsequence(a);

            Console.WriteLine($"The longest subsequence is {longest}");

            return true;
        }
    }
}