using System;
using System.Linq;

namespace CSharpAlgorithm.DynamicPlanning
{

    public partial class DynamicPlanningSolution
    {
        //Cosider that a continuous squares which connect to form a long rectangel.
        //we use red, green, blue to color them requiring that the blocks must have 
        //different colors and the beging and end of the square have the different 
        //colors as well
        public static int ColorBlocks(int n)
        {
            int f1 = 3,f2=6,f3=6;
            int fn = 0;

            for(int i=4;i<=n;i++)
            {
                fn = f3+2*f2;
                f2 = f3;
                f3 = fn;
            }

            return fn;
        }

        public static bool TestColorBlocks(out string result )
        {
            result = "TestColorBlocks OK";

            int res = ColorBlocks(5);
            Console.WriteLine($"the methods of coloring is {res}");
            return false;
        }
    }



}