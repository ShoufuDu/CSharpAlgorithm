using System;
using System.Linq;
using CSharpAlgorithm.Util;

namespace CSharpAlgorithm.DynamicPlanning
{

    public partial class DynamicPlanningSolution
    {
        public static int MaxMSubset(int[] a, int m)
        {
            int n = a.Length;
            var aEx = new int[n + 1];
            a.CopyTo(aEx, 1);

            //sumArr[i,j] denote i subsets that have the maximum sum of all subsets of the set a[1]...a[j], this array cannot be used
            var sumArr = new int[m + 1, n + 1];

            //b[i,j] denote the i subsets that have the maximum sum of themselves of the set a[1]...a[j] and of which the last subset ends with a[j];
            var b = new int[m + 1, n + 1];

            //for (int i = 0; i < m+1; i++)
            //for (int j = 0; j < n+1; j++)
            //{
            //    sumArr[i, j] = int.MinValue/2;
            //    b[i, j] = int.MinValue/2;
            //}

            for (int i = 1; i <= m; i++)
            {
                for (int j = i; j <= n; j++)
                {
                    for (int k = i - 1; k <= j - 1; k++)
                        b[i, j] = Math.Max(b[i, j], b[i - 1,k] + aEx[j]);

                    if (j > i)
                        b[i, j] = Math.Max(b[i, j], b[i, j - 1] + aEx[j]);

                    //sumArr[i, j] = b[i, j];
                    //for (int k = i; k <= j-1; k++)
                    //sumArr[i, j] = Math.Max(sumArr[i, j], b[i, k]);
                }
            }

            int sumMax = 0;
            for (int k = m; k <= n; k++)
                sumMax = Math.Max(sumMax, b[m, k]);

            Console.WriteLine("b");
            for (int i = 1; i <= m; i++)
            {
                Console.WriteLine();
                for (int j = 1; j <= n; j++)
                    Console.Write("{0,3}", b[i, j]);
            }

            //Console.WriteLine("\nsumArr");
            //for (int i = 1; i <= m; i++)
            //{
            //    Console.WriteLine();
            //    for (int j = 1; j <= n; j++)
            //        Console.Write("{0,12}", sumArr[i, j]);
            //}

            return sumMax;
        }

        public static int MaxMSubsetEx(int[] a, int m)
        {
            int n = a.Length;

            var aEx = new int[n + 1];
            var b= new int[2,n + 1];
            int maxSum = 0;

            for(int i=1;i<=m;i++)
                for(int j=i;j<=n;j++)
                {
                    int maxTemp = 0;
                    for (int k = i - 1; k <= j; k++)
                        maxTemp = Math.Max(maxTemp, b[0,k]+a[j]);

                    b[1,j] = Math.Max(b[1,j], b[1,j - 1] + a[j]);

                    //Array.Copy(b[1],b[0]);
                }

            for (int i = 1; i < n; i++)
                maxSum = Math.Max(maxSum, b[1,i]);

            return maxSum;
        }

        public static void TestMaxMSubset()
        {
            int[] a = new int[] { 1, -2, 3, 4, -5, -6, 7, 8, -9 };
            int m = 5;

            Expect.Expect2("TestMaxMSubset", MaxMSubset, a, m, 21);
        }
    }
}