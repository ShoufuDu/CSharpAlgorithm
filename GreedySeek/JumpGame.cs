using System;
namespace CSharpAlgorithm.GreedySeek
{
    public partial class GreedySeekSolution
    {
        public GreedySeekSolution()
        {
        }

        //Given an array of non-negative integers, you are initially positioned at the first index of the array.Each element in the array represents your maximum jump length at that position.
        //Determine if you are able to reach the last index.
        public static bool JumpGame1(int[] a)
        {
            int reach = 1;

            for (int i = 0; i < reach && reach < a.Length; i++)
            {
                reach = Math.Max(reach, i + 1 + a[i]);
            }

            if (reach >= a.Length)
                return true;

            return false;
        }

        public static bool JumpGame1Ex(int[] a)
        {
            int leftMost = a.Length - 1;
            for (int i = a.Length - 2; i >= 0; i--)
            {
                if (a[i] + i >= leftMost)
                    leftMost = i;
            }

            if (leftMost == 0)
                return true;

            return false;
        }

        //Dynamic Programming, f[i] denote the maximum remaining steps to reach a[i]
        public static bool JumpGameExEx(int[] a)
        {
            int[] f = new int[a.Length];

            for(int i=1;i<a.Length;i++)
            {
                f[i] = Math.Max(f[i - 1], a[i]) - 1;
                if (f[i] < 0)
                    return false;
            }

            if (f[a.Length - 1] >= 0)
                return true;

            return false;
        }
    }
}
