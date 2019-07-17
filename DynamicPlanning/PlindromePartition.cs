using System;
using System.Collections.Generic;
using CSharpAlgorithm.Util;

namespace CSharpAlgorithm.DynamicPlanning
{
    public partial class DynamicPlanningSolution
    {
        //Given a string s, partition s such that every substring of the partition is a palindrome.
        //Return the minimum cuts needed for a palindrome partitioning of s.
        //For example, given s = "aab",
        //Return 1 since the palindrome partitioning ["aa","b"] could be produced using 1 cut.

        // Consider that f[i] denotes the minimum cut of the interval [i,...,n-1].
        // So the f[i] = min{f[i],f[j+1]+1}  i<=j<=n-1
        public static int PalindromePartition(string str)
        {
            int n = str.Length;

            if (n == 0)
                return 0;

            bool[,] p = new bool[n, n];
            int [] f = new int[n+1];

            for (int i=n;i>=0;i--)
            {
                f[i] = n - 1 -i; // f[n] = -1; f[n-1] = 0; f[n-2] =1; at least single letter is a plindrome
            }

            for(int i=n-1;i>=0;i--)
            {
                for(int j=i;j<n;j++)
                {
                    p[i, j] = (str[i] == str[j]) && ((j - i < 2) || p[i + 1, j - 1]);

                    if (p[i,j])
                    {
                        f[i] = Math.Min(f[i], f[j+1] + 1);
                    }
                }
            }

            return f[0];
        }

        public static void TestPalindromePartition()
        {
            string funcName = System.Reflection.MethodBase.GetCurrentMethod().Name;

            string test1 = "bababcdcdc";

            Expect.Expect1(funcName,PalindromePartition, test1, 1);

            test1 = "aab";

            Expect.Expect1(test1, PalindromePartition, test1, 1);

        }
    }

}