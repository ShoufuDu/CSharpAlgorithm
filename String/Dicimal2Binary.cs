using System;
namespace CSharpAlgorithm.MyString
{
    public partial class StringSolution
    {
        public static string Dicimal2Binary(int n)
        {
            int b = 0;

            int r = 0,p = 1; 

            while (n > 0)
            {
                r = n % 2;
                n = n / 2;
                b = b + r * p;
                p *= 10;
            }

            return Convert.ToString(b);
        }

        public static string Dicimal2BinaryEx(int n)
        {
            int r = 0;
            string result = "";

            while (n > 0)
            {
                r = n % 2;
                n = n / 2;
                result = result.Insert(0, Convert.ToString(r));
            }

            return result;
        }

        public static bool TestDicimal2Binary(out string res)
        {
            res = "TestDicimal2Binary OK";

            if (Dicimal2Binary(5) != "101")
            {
                res = "5" + " error";
                return false;
            }

            if (Dicimal2Binary(8) != "1000")
            {
                res = "8" + " error";
                return false;
            }

            string test1 = Dicimal2Binary(100);
            string test2 = Dicimal2BinaryEx(100);
            if ( test1!= test2)
            {
                res = "Dicimal2BinaryEx error:" + test2;
                return false;
            }

            Console.WriteLine(Dicimal2Binary(125));

            Console.WriteLine(Dicimal2Binary(256));

            return true;
        }
    }
}
