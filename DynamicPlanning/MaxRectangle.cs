using System;
using System.Linq;
using CSharpAlgorithm.Util;

namespace CSharpAlgorithm.DynamicPlanning
{

    public partial class DynamicPlanningSolution
    {

        public static int MaxRectangle(int[,] matrix)
        {
            int m = matrix.GetLength(0);
            int n = matrix.GetLength(1);

            int[] H = new int[n];
            int[] L = new int[n];
            int[] R = new int[n];

            Array.Fill(R, n);

            int ret = 0;
            for (int i = 0; i < m; i++)
            {
                int left = 0, right = n;

                for (int j = 0; j < n; j++)
                {
                    Console.WriteLine($"\ni={i},j={j}，matrix[{i},{j}]={matrix[i, j]}");
                    if (matrix[i, j] == 1)
                    {
                        Console.Write("\n BefIF1:H[{0,2}]={1,2},L[{2,2}]={3,2},R[{4,2}]={5,2},left={6,2}", j, H[j], j, L[j], j, R[j], left);
                        ++H[j];
                        L[j] = Math.Max(L[j], left);

                        Console.Write("\n EndIF1:H[{0,2}]={1,2},L[{2,2}]={3,2},R[{4,2}]={5,2},left={6,2}", j, H[j], j, L[j], j, R[j], left);
                    }
                    else
                    {
                        Console.Write("\n BefEL1:H[{0,2}]={1,2},L[{2,2}]={3,2},R[{4,2}]={5,2},left={6,2}", j, H[j], j, L[j], j, R[j], left);
                        left = j + 1;
                        H[j] = 0;
                        L[j] = 0;
                        R[j] = n;
                        Console.Write("\n EndEL1:H[{0,2}]={1,2},L[{2,2}]={3,2},R[{4,2}]={5,2},left={6,2}", j, H[j], j, L[j], j, R[j], left);
                    }
                }

                for (int j = n - 1; j >= 0; j--)
                {
                    Console.WriteLine($"\ni={i},j={j},matrix[{i},{j}]={matrix[i, j]}");
                    if (matrix[i, j] == 1)
                    {
                        Console.Write("\n BefIF2:H[{0,2}]={1,2},L[{2,2}]={3,2},R[{4,2}]={5,2},right={6,2},ret={7,2}", j, H[j], j, L[j], j, R[j], right, ret);
                        R[j] = Math.Min(R[j], right);
                        ret = Math.Max(ret, H[j] * (R[j] - L[j]));
                        Console.Write("\n EndIF2:H[{0,2}]={1,2},L[{2,2}]={3,2},R[{4,2}]={5,2},right={6,2},ret={7,2}", j, H[j], j, L[j], j, R[j], right, ret);
                    }
                    else
                    {
                        Console.Write("\n BefEL2:H[{0,2}]={1,2},L[{2,2}]={3,2},R[{4,2}]={5,2},right={6,2},ret={7,2}", j, H[j], j, L[j], j, R[j], right, ret);
                        right = j;
                        Console.Write("\n EndEL2:H[{0,2}]={1,2},L[{2,2}]={3,2},R[{4,2}]={5,2},right={6,2},ret={7,2}", j, H[j], j, L[j], j, R[j], right, ret);
                    }

                }
            }

            return ret;
        }

        //{ 0, 1, 0, 1, 0 }, 
        //{ 1, 1, 1, 0, 0 }, 
        //{ 0, 1, 1, 1, 1 }, 
        //{ 0, 1, 1, 1, 1 },
        //{ 0, 1, 0, 1, 1 },
        //{ 0, 1, 0, 1, 1 }
        public static int MaxRectangleSelf(int[,] matrix)
        {
            int m = matrix.GetLength(0);
            int n = matrix.GetLength(1);

            int[] R = new int[n]; //Denote from right to left, 
            int[] L = new int[n];
            int[] H = new int[n];

            int ret = 0;

            Array.Fill(R, n);

            for (int i = 0; i < m; i++)
            {
                int left = 0;

                for (int j = 0; j < n; j++)
                {
                    if (matrix[i, j] == 1)
                    {
                        H[j]++;
                        L[j] = Math.Max(L[j], left);
                    }
                    else
                    {
                        left = j + 1;
                        L[j] = 0;
                        H[j] = 0;
                        R[j] = n;
                    }
                }

                int right = n;
                for (int j = n - 1; j >= 0; j--)
                {
                    if (matrix[i, j] == 1)
                    {
                        R[j] = Math.Min(R[j], right);
                        ret = Math.Max(ret, H[j] * (R[j] - L[j]));
                    }
                    else
                    {
                        right = j;
                    }
                }
            }
           
            return ret;
        }

        public static void TestMaxRectangle()
        {
            int[,] matrix = new int[,] { { 0, 1, 0, 1, 0 }, { 1, 1, 1, 0, 0 }, { 0, 1, 1, 1, 1 }, { 0, 1, 1, 1, 1 }, { 0, 1, 0, 1, 1 } };

            Expect.Expect1("TestMaxRectangle", MaxRectangle, matrix, 8);

            //Expect.Expect1("TestMaxRectangleSelf", MaxRectangleSelf, matrix, 8);
        }


    }
}