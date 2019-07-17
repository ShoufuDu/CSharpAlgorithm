using System;

namespace CSharpAlgorithm.Else
{
    public class ElseSolution
    {
            public static void RandomArray(ref int[] a)
            {
                Random radomGen = new Random();
                for(int i=a.Length-1;i>=0;i--)
                {
                    int random = radomGen.Next(i+1);
                    int temp = a[i];
                    a[i] = a[random];
                    a[random] = temp;
                }
            }

            public static void TestRandomArray()
            {
                const int len = 52;
                int[] a = new int[len];
                for(int i=0;i<len;i++)
                {
                    a[i] = i+1;
                }

                RandomArray(ref a);

                Console.WriteLine();
                for(int i=0;i<len;i++ )
                    Console.Write(a[i]+" ");
                Console.WriteLine();

            }
    }
}
