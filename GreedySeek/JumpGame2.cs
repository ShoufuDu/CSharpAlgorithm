using System;
using CSharpAlgorithm.Util;

namespace CSharpAlgorithm.GreedySeek
{
    public partial class GreedySeekSolution
    {
        public static int JumpGame2(int[] num)
        {
            int steps = 0; //denoting the minimun steps to reach the last index
            int left = 0;  
            int right = 0; //denoting the rightest index that can reach from the the last starting index 

            Console.WriteLine();
            while(left<=right)
            {
                steps++;
                Console.Write($"->{right}");

                int oldRight = right; //denoting the every starting index

                //search the farthest index able to reach within the steps of last index already reached
                for (int i=left;i<=oldRight;i++)
                {
                    int newRight = i + num[i];
                    if (newRight >= num.Length - 1) //Got it
                    {
                        Console.WriteLine();
                        return steps;
                    }

                    if (newRight > right) // Updated to get the farthest index
                        right = newRight;
                }

                left = oldRight;
            }

            return 0;
        }

        public static int JumpGame2Ex(int[] num)
        {
            int cur = 0;
            int steps = 0;
            int last = 0; // the last farthest index able to reach

            Console.WriteLine();

            for (int i=0;i<num.Length;i++)
            {
                if (i>last) 
                {
                    //note: if i>last then it means the process of searching max ended,
                     //last can possibly go back whether there are maximum value before the previous last
                    last = cur;
                    Console.Write($"->{last}");
                    steps++;
                }

                cur = Math.Max(cur, num[i] + i);
            }

            Console.WriteLine();
            return steps;
        }

        public static void TestJumpGame2()
        {
            string funcName = System.Reflection.MethodBase.GetCurrentMethod().Name;
            int[] num = new int[] { 2, 3, 1, 1, 4 };

            Expect.Expect1("JumpGame2", JumpGame2, num, 2);

            Expect.Expect1("JumpGame2Ex", JumpGame2Ex, num, 2);

            num = new int[] { 5, 7, 1, 1, 3, 2, 5, 3 ,6};

            Expect.Expect1("JumpGame2", JumpGame2, num, 2);
        }


    }
}