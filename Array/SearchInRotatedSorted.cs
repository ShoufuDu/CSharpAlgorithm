using System;
using System.Collections.Generic;

namespace CSharpAlgorithm.MyArray
{
    public partial class ArraySolution
    {
        //Follow up for ”Remove Duplicates”: What if duplicates are allowed at most twice? For example, Given sorted array A = [1, 1, 1, 2, 2, 3],
        //Your function should return length = 5, and A is now[1, 1, 2, 2, 3]
        static public int SearchInRotatedSorted(int[] a, int item)
        {

            int index = 0;

            return index;
        }

        static public void TestSearchInRotatedSorted()
        {
            int[] a = { 1, 3, 5, 19, 12, 3, 4, 7, 3, 1, 1, 15, 14, 22, 12 };

            int count = RemoveDuplicatFromUnorder(a, 1);

            Console.WriteLine("count={0}", count);
            for (int i = 0; i < count; i++)
            {
                Console.WriteLine("{0} ", a[i]);
            }

        }
    }
}
