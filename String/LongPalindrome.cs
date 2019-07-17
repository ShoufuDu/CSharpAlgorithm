using System;

namespace CSharpAlgorithm.MyString
{
    public partial class StringSolution
    {

        public static string LongPalindrome(string str)
        {
            string result = "";

            if (System.String.IsNullOrEmpty(str))
                return result;

            str = str.ToLower().Trim();

            int n = str.Length;
            if (n > 1000)
                return "";

            int maxIndex = 0, curLength = 0, maxLength = 0;

            for (int i = 0; i < n; i++)
            {
                int j = i - 1;
                int k = i + 1;
                curLength = 0;

                while (j >= 0 && k < n)
                {
                    if (str[j] == str[k])
                    {
                        j--;
                        k++;
                        curLength++;
                    }
                    else
                    {
                        break;
                    }
                }

                if (curLength > maxLength)
                {
                    maxIndex = i;
                    maxLength = curLength;
                }
            }

            return str.Substring(maxIndex - maxLength, maxLength * 2 + 1);
        }

        public static string LongPalindromeEx(string s)
        {
            s = s.Trim().ToLower();
            int n = s.Length;
            int maxIndex = 0, maxLength = 0;

            bool[,] flag = new bool[n, n];

            for(int i=0;i<n;i++)
            {
                flag[i, i] = true;
                for (int j=0;j<i;j++)
                {
                    flag[j, i] = ((s[j] == s[i]) && (j == i - 1 || flag[j + 1, i - 1]));

                    if (flag[j,i] && i-j+1> maxLength)
                    {
                        maxIndex = j;
                        maxLength = i - j + 1;
                    }
                }
            }

            if (maxLength>0)
            {
                return s.Substring(maxIndex, maxLength);
            }

            return "";
        }

        public static string LongestPalindrome(string s)
        {
            s = s.Trim().ToLower();
            if (s.Length == 1)
                return s;

            bool[][] f = new bool[s.Length][];

            for(int i=0;i<s.Length;i++)
                {
                    f[i] = new bool[i+1];
                }

            int min=0,max_len=1;
            for(int i=0;i<s.Length;i++)
            {
                f[i][i] = true;
                for (int j=0;j<i;j++)
                {
                    f[i][j] = (s[i]==s[j])&&((j==i-1)||f[i-1][j+1]);

                    if(f[i][j]&&i-j+1>max_len)
                    {
                        min = j;
                        max_len = i-j+1;
                    }
                }

                if(f[i][i]&&1>max_len)
                    {
                        min = i;
                        max_len = 1;
                    }
            }

            if (max_len > 0)
                return s.Substring(min,max_len);
            else
                return "";
        }

        public static bool TestLongPalindrome(out string result)
        {
            result = "TestLongPalindrome OK";

            string src = "AmanaplanacanalPanamadfasla123";

            string longStr = LongPalindrome(src);
            if (longStr != "amanaplanacanalpanama")
            {
                result = "LongPalindrome error:" + longStr;
                return false;
            }

            string longStrEx = LongPalindromeEx(src);
            if (longStr != longStrEx)
            {
                result = "LongPalindromeEx error:" + longStrEx;
                return false;
            }

            src = "babad";
            string longStrEx1 = LongestPalindrome(src);
            if (longStrEx1 != longStr)
            {
                result = "LongestPalindrome error:" + longStrEx;
                return false;
            }

            return true;
        }
    }
}


