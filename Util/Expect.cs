using System;
using System.Diagnostics;
using System.Collections;

namespace CSharpAlgorithm.Util
{
    public class Expect
    {
        public Expect()
        {
        }

        public static void Expect1<T1, TypeExpected>(string funcName, Func<T1, TypeExpected> func, T1 arg1, 
                        TypeExpected valueExpected)
            where TypeExpected : IComparable
        {
            TypeExpected realVaule = func(arg1);

            if (realVaule.Equals(valueExpected))
            {
                Console.WriteLine($"\n{funcName} Success");
                return;
            }

            Console.WriteLine($"\n{funcName} failed, result :{realVaule}, expected:{valueExpected}");

            return;
        }

        public static void Expect2<T1, T2, TypeExpected>(string funcName,Func<T1, T2, TypeExpected> func, 
                T1 arg1, T2 arg2, TypeExpected valueExpected)
            where TypeExpected:IComparable
        {
            TypeExpected realVaule = func(arg1,arg2);

            if (realVaule.Equals(valueExpected))
            {
                Console.WriteLine($"\n{funcName} Success");
                return;
            }

            Console.WriteLine($"\n{funcName} failed, result :{realVaule}, expected:{valueExpected}");

            return;
        }

        public static void Expect3<T1, T2, T3, TypeExpected>(string funcName,Func<T1, T2, T3, TypeExpected> func, 
                T1 arg1, T2 arg2, T3 arg3, TypeExpected valueExpected)
        where TypeExpected : IComparable
        {
            TypeExpected realVaule = func(arg1, arg2,arg3);

            if (realVaule.Equals(valueExpected))
            {
                Console.WriteLine($"\n{funcName} Success");
                return;
            }

            Console.WriteLine($"\n{funcName} failed, result :{realVaule}, expected:{valueExpected}");

            return;
        }

    }
}
