using System;

namespace CSharpAlgorithm.MyString
{
    public partial class StringSolution
    {

        //            Given two binary strings, return their sum(also a binary string).
        //For example,
        //a = "11" b = "1"
        //Return "100".
        public static string StringBinaryAdd(string sa, string sb)
        {
            int n = 0;
            string s1, s2;

            if (sa.Length > sb.Length)
            {
                s1 = sa;   
                s2 = sb.PadLeft(sa.Length, '0');
                n = s1.Length;
            }
            else
            {
                s1 = sa.PadLeft(sb.Length, '0');
                s2 = sb;
                n = s2.Length;
            }

            int i = 0; bool sign = false;
            int res = 0;
            int p = 1;
            int cur = 0;
            for (i = n - 1; i >= 0; i--)
            {
                if (!sign)
                {
                    if (s1[i] != s2[i])
                    {
                        res = 1;
                    }
                    else
                    {
                        res = 0;
                        if (s1[1] == '1')
                        {
                            sign = true;
                        }
                        else
                        {
                            sign = false;
                        }
                    }
                }
                else
                {
                    if (s1[i] != s2[i])
                    {
                        res = 0;
                        sign = true;
                    }
                    else
                    {

                        if (s1[1] == '1')
                        {

                            sign = true;
                        }
                        else
                        {

                            sign = false;
                        }

                        res = 1;
                    }

                }

                cur = cur + res * p;
                p *= 10;
            }

            if (sign)
            {
                return Convert.ToString(cur + 1 * p);
            }
            else
            {
                return Convert.ToString(cur);
            }

        }


        public static string StringBinaryAddEx(string sa, string sb)
        {

            int n = 0;
            string s1, s2;

            if (sa.Length > sb.Length)
            {
                s1 = sa;
                s2 = sb.PadLeft(sa.Length, '0');
                n = s1.Length;
            }
            else
            {
                s1 = sa.PadLeft(sb.Length, '0');
                s2 = sb;
                n = s2.Length;
            }


            int val=0,carry = 0,v1=0,v2=0;
            string result = "";


            for(int i=n-1;i>=0;i--)
            {
                v1 = s1[i] - '0';
                v2 = s2[i] - '0';

                val = (v1 + v2 + carry) % 2;
                carry = (v1 + v2+carry) / 2;

                //result=Convert.ToString(val)+result;

                result = result.Insert(0, Convert.ToString(val));
            }

            if (carry>0)
            {
                result = Convert.ToString(carry) + result;
            }

            return result;
        }


        public static bool TestStringBinaryAdd(out string result)
        {
            string s1 = "110";
            string s2 = "11";

            string res = StringBinaryAdd(s1, s2);
            string res2 = StringBinaryAddEx(s1, s2);
            if (res != res2)
            {
                result = "error2:" + s1 + "+" + s2 + "=" + res2;
                return false;
            }

            if (res.CompareTo("1001") != 0)
            {
                result = "error2:" + s1 + "+" + s2 + "="+res;
                return false;
            }

             s1 = "1111";
             s2 = "111"; 

            res = StringBinaryAdd(s1, s2);
            res2 = StringBinaryAddEx(s1, s2);
            if (res != res2)
            {
                result = "error2:" + s1 + "+" + s2 + "=" + res2;
                return false;
            }

            if (res.CompareTo("10110") != 0)
            {
                result = "error:" + s1 + "+" + s2 + "=" + res;
                return false;
            }

            result = "TestStringBinaryAdd OK";
            return true;
        }
    }
}