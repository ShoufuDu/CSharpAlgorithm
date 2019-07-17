using System;
using System.Collections.Generic;

namespace CSharpAlgorithm.DynamicPlanning
{
    public partial class DynamicPlanningSolution
    {
        public static int CollectMaxApples(int[] A, int K, int L)
        {
            long sumLeft = 0;
            long sumRight = 0;
            int n = A.Length;

            if (K + L > n)
            {
                return -1;
            }

            for (int i = 0; i < K; i++)
            {
                sumLeft += A[i];
            }
            long firstSumLeft = sumLeft;

            for (int i = n - 1; i >= n - L; i--)
            {
                sumRight += A[i];
            }
            long lastSumRight = sumRight;

            long maxSum = firstSumLeft + lastSumRight;

            for (int i = K - 1; i < n; i++)
            {
                sumLeft = i == K - 1 ? firstSumLeft : sumLeft + A[i] - A[i - K];
                for (int j = n - L; j >= 0; j--)
                {

                    sumRight = j == n - L ? lastSumRight : sumRight + A[j] - A[j + L];

                    if (i < j || i - K + 1 > j + L - 1)
                    {
                        maxSum = Math.Max(maxSum, sumLeft + sumRight);
                    }

                }
            }

            return Convert.ToInt32(maxSum % (Math.Pow(10, 9) + 7));
        }

        public static bool TestCollectMaxApples(out string res)
        {
            res = "OK";

            int[] a = new int[] { 6, 6, 4, 7, 8, 7, 16 };

            long result = CollectMaxApples(a, 3, 2);

            System.Diagnostics.Debug.Assert(result == 43);

            Console.WriteLine(result);

            return true;

        }

    }
}
