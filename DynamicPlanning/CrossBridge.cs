using System;
using CSharpAlgorithm.Util;

namespace CSharpAlgorithm.DynamicPlanning
{

    public partial class DynamicPlanningSolution
    {

        public static int MinTimeToCrossBridge(int[] p)
        {
            if (p.Length < 2)
                return p.Length;

            Array.Sort(p);

            //p = p.OrderBy(x =>x).ToArray();

            int f0 = p[0];
            int f1 = p[1];

            int f = 0;

            for(int i=2;i<p.Length;i++)
            {
                f = Math.Min(f1 + p[0] + p[i], f0 + p[0] + p[i] + 2*p[1]);

                f0 = f1;
                f1 = f;

                Console.WriteLine($"i:{i},fi:{f}");
            }

            return f;
        }


        public static bool TestMinTimeToCrossBridge()
        {
            string funcName = System.Reflection.MethodBase.GetCurrentMethod().Name;

            int[] p = new int[] { 1, 2, 5, 10 };

            Expect.Expect1(funcName,MinTimeToCrossBridge, p, 17);

            p = new int[] { 1, 2, 5, 10, 11 };

            Expect.Expect1(funcName,MinTimeToCrossBridge, p, 24);

            return true;
        }

    }
}