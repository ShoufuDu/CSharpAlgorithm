using System;


namespace CSharpAlgorithm.MyString
{
    public partial class StringSolution
    {

        //Implement atoi to convert a string to an integer.
        //Hint: Carefully consider all possible input cases. If you want a challenge, please do not see below and ask yourself what are the possible input cases.
        //Notes: It is intended for this problem to be specified vaguely (ie, no given input specs). You are respon- sible to gather all the input requirements up front.
        //Requirements for atoi:
        //The function first discards as many whitespace characters as necessary until the first non-whitespace character is found.Then, starting from this character, takes an optional initial plus or minus sign followed by as many numerical digits as possible, and interprets them as a numerical value.
        //The string can contain additional characters after those that form the integral number, which are ignored and have no effect on the behavior of this function.
        //If the first sequence of non-whitespace characters in str is not a valid integral number, or if no such sequence exists because either str is empty or it contains only whitespace characters, no conversion is per- formed.
        //If no valid conversion could be performed, a zero value is returned.If the correct value is out of the range of representable values, INT_MAX (2147483647) or INT_MIN(-2147483648) is returned.

        public static int AtoI(string str)
        {
            str.Trim();

            int i=0,num = 0,sign =1;

            while (i < str.Length && (str[i] < '0' || str[i] > '9'))
                i++;

            if (i>0 && str[i - 1] == '-')
                sign = -1;

            while(i< str.Length)
            {
                if (str[i] < '0' || str[i] > '9')
                    break;

                if (num > int.MaxValue/10
                    ||(num==int.MaxValue/10 && str[i]-'0' > int.MaxValue%10))
                {
                    return sign > 0 ? int.MaxValue : int.MinValue;
                }

                num = num * 10 + str[i] - '0';

                i++;
            }

            return num * sign;
        }

        public static bool TestAtoI(out string result)
        {
            if (AtoI("123") != 123)
            {
                result = "123"+ "error";
                return false;
            }

            if (AtoI("afdbc-1238973") != -1238973)
            {
                result = "afdbc-1238973"+ "error";
                return false;
            }

            if (AtoI("afdeD!2147483649") != int.MaxValue)
            {
                result = "afdeD!2147483649"+ " error";
                return false;
            }

            if (AtoI("afdeD!-2147483648") != int.MinValue)
            {
                result = "afdeD-2147483648" + " error";
                return false;
            }

            if (AtoI("-3924x8fc")!=-3924)
            {
                result = "-3924x8fc" + " error";
                return false;
            }

            if (AtoI("++c") != 0)
            {
                result = "++c" + " error";
                return false;
            }

            result = "TestAtoI ok";
            return true; 
        }
    }
}