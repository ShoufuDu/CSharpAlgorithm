using System.Security.AccessControl;
using System;
using System.Collections.Generic;

namespace CSharpAlgorithm.DynamicPlanning
{
    public partial class DynamicPlanningSolution
    {
        //Given a triangle, find the minimum path sum from top to bottom.Each step you may move to adjacent numbers on the row below.
        //For example, given the following triangle
        //[
        //      [2],
        //      [3,4],
        //      [6,5,7],
        //      [4,1,8,3]
        //]
        //The minimum path sum from top to bottom is 11 (i.e., 2 + 3 + 5 + 1 = 11).
        //Note: Bonus point if you are able to do this using only O(n) extra space, where n is the total number of
        //rows in the triangle.

        static public int TriangleMinSum(int[][] triangle)
        {
            for (int i = triangle.Length - 2; i >= 0; i--)
                for (int j = 0; j < i + 1; j++)
                {
                    triangle[i][j] = Math.Min(triangle[i + 1][j], triangle[i + 1][j + 1]) + triangle[i][j];
                }

            return triangle[0][0];
        }

        static public int MinimumTotal(IList<IList<int>> triangle) 
        {
           for (int i= triangle.Count-2;i>=0;i--)
           {
               for(int j=0;j<=i;j++)
                    triangle[i][j] = Math.Min(triangle[i+1][j],triangle[i+1][j+1])+triangle[i][j];
           }

           return triangle[0][0];
        }

        static public bool TestTriangleMinSum(out string result)
        {
            result = "TestTriangleMinSum OK";
            int[][] triangle = new int[4][];

            triangle[0] = new int[] { 2 };
            triangle[1] = new int[] { 3, 4 };
            triangle[2] = new int[] { 6, 5, 7 };
            triangle[3] = new int[] { 4, 1, 8, 3 };

            int res = TriangleMinSum(triangle);
            if (res != 11)
            {

                result = "TestTriangleMinSum err:" + res;
                return false;

            }

            return false;
        }

    }
}