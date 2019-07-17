using System;
using System.Linq;

namespace CSharpAlgorithm.DynamicPlanning
{

    public partial class DynamicPlanningSolution
    {
        //Find the contiguous subarray within an array(containing at least one number) which has the largest sum.
        //For example, given the array[−2, 1,−3, 4,−1, 2, 1,−5, 4], the contiguous subarray[4,−1, 2, 1] has the largest sum = 6.
        public static int ContinusMaxSum(int[] a)
        {
            int[] res = new int[a.Length];
            Tuple<int, int>[] index= new Tuple<int, int>[a.Length];

            res[0] = a[0];
            int maxBegin = 0, maxEnd = 0;
            index[0] = Tuple.Create<int, int>(maxBegin, maxEnd);

            for (int i=1;i<a.Length;i++)
            {
                int tempMax = 0;

                res[i] = res[i - 1];

                for (int j=i;j>=0;j--)
                {
                    tempMax += a[j];
                    if (tempMax > res[i])
                    {
                        res[i] = tempMax;
                        maxBegin = j;
                        maxEnd = i;
                    }
                }

                //Tuple<int, int> idx = new Tuple<int, int>(maxBegin, maxEnd);
                index[i]=Tuple.Create<int,int>(maxBegin, maxEnd);

            }

            //for (int i=0;i<a.Length; i++)
            //{
            //    Console.Write("{0,-5}",a[i]);
            //}
            //Console.WriteLine();

            //for (int i = 0; i < a.Length; i++)
            //{
            //    Console.Write("{0,-5}",i);
            //}
            //Console.WriteLine();

            //for (int i = 0; i < a.Length; i++)
            //{
            //    Console.Write($"i:{i},maxSum:{res[i]},[");
            //    for (int j = index[i].Item1; j <= index[i].Item2; j++)
            //        Console.Write(a[j]+" ");
            //    Console.WriteLine("]");
            //}

            //Console.WriteLine();
            return res[a.Length-1];
        }

        //The key to dynamic planning is to find the state transfering foumula. 
        //In this case, we set state f[i] that refers to the max sum of the subsequence that ends with s[i];
        //So, for s[i], there are only two choices. 
        //One is that s[i] can join the previous subsequence as being the end of the new subsequence, then f[i] = f[i]+s[i];
        //Or it separately starts to become a new subsequence beginning wtih itself, then f[i] = s[i];
        //For the two cases, f[i] = max{f[i]+s[i],s[i]}= | s[i]         when f[i-1]<=0;
                                                       //| f[i-1]+s[i]; when f[i-1] > 0;
         int ContinusMaxSumEx(int[] nums)
        {
            int result = int.MinValue, f = 0;
            for (int i = 0; i < nums.Length; ++i)
            {
                f = Math.Max(f + nums[i], nums[i]);
                result = Math.Max(result, f);

                //Console.WriteLine($"i:{i},f:{f},max:{result}");
            }
            return result;
        }

        // Consider that: 
        // if sum[i] refers to the sum of sequence n[0]....n[i],
        // f[i] refes to the maximum sum of all the the subsequence ending with n[i],
        // we assume that f[i] is the subsequence n[x]...n[i], which means that
        // the sum of the prefix subsequence n[0]...n[x-1] has the minimum value among all
        // the prefix subsequences before n[i];
        // So the solution is clear now.
        int ContinusMaxSumExEx(int[] nums)
        {
            int result = int.MinValue;
            int[] sum = new int[nums.Length + 1];

            sum[0] = 0;
            int curMin = sum[0];


            for (int i=0;i<nums.Length;i++)
            {
                sum[i+1] = sum[i] + nums[i];
            }

            for(int i=1;i<nums.Length+1;i++)
            {
                result = Math.Max(sum[i] - curMin,result); //to get them max sum of the subsequence than ends with n[i]

                curMin = Math.Min(curMin, sum[i]); // to get the min sum of all the prefix subsequences
            }

            return result;
        }



        public static bool TestContinusMaxSum(out string result)
        {
            result = "TestContinusMaxSum OK";

            int[] a = new int[]{-2, 1,-3, 4,-1, 2, 1,-5, 4,5,-6,10,3,2,-20 };

            int res = ContinusMaxSum(a);
            //if (res != 12)
            //{
            //    result = "TestContinusMaxSum Error:" + res;
            //    return false;
            //}

            DynamicPlanningSolution df = new DynamicPlanningSolution();
            int res2 = df.ContinusMaxSumEx(a);

            if (res != res2)
            {
                result = "TestContinusMaxSumEx Error:" + res2;
                return false;
            }

            int res3 = df.ContinusMaxSumExEx(a);
            if (res3 != res2)
            {
                result = "TestContinusMaxSumExEx Error:" + res3;
                return false;
            }

            return true;
        }
    }

}
