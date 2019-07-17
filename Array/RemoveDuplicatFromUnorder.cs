using System;
using System.Collections.Generic;
using System.Collections;

namespace CSharpAlgorithm.MyArray
{
     public partial class ArraySolution
    {
        //Follow up for ”Remove Duplicates”: What if duplicates are allowed at most twice? For example, Given sorted array A = [1, 1, 1, 2, 2, 3],
        //Your function should return length = 5, and A is now[1, 1, 2, 2, 3]
        static public int RemoveDuplicatFromUnorder(int[] a, int timesDup)
        {
            var hs = new Dictionary<int, int>();

            int index = 0;
          
            for (int i = 0; i < a.Length; i++)
            {
                int v;
                if (hs.TryGetValue(a[i], out v))
                {
                    if (v < timesDup)
                    {
                        hs[a[i]]++;
                        a[index++] = a[i];
                    }
                }
                else
                {
                    a[index++] = a[i];
                    hs.Add(a[i], 1);
                }
            }

            Hashtable t = new Hashtable();

            return index;
        }

        static public void TestRemoveDuplicatFromSorted()
        {
            int[] a = { 1, 3, 5, 19, 12, 3, 4, 7, 3, 1, 1, 15, 14, 22, 12 };

            int count = RemoveDuplicatFromUnorder(a,1);

            Console.WriteLine("count={0}", count);
            for(int i=0;i<count;i++)
            {
                Console.WriteLine("{0} ", a[i]);
            }

            int j = Array.IndexOf(a,1);
           
        }
    }
}
