using System;


namespace CSharpAlgorithm.MyString
{

    public partial class StringSolution
    {
//        Implement strStr().
//Returns a pointer to the first occurrence of needle in haystack, or null if needle is not part of haystack.
        static public int StrStr(string needle, string haystack)
        {
            if (string.IsNullOrEmpty(needle) || needle.Length>haystack.Length)
                return -1;

            int n = haystack.Length - needle.Length;

            for (int i=0;i<n;i++)
            {
                int j = 0;
                while (j < needle.Length && needle[j] == haystack[i + j] )
                    j++;

                if (j == needle.Length)
                    return i;
            }

            return -1;

        }

        public static bool TestStrStr()
        {
            string haystack = "my name is a bad boy of garden is a good boy";
            string needle = "isa";

            int pos = StrStr(needle, haystack);
            int posSystem = haystack.IndexOf(needle);

            if ( pos == posSystem)
            {
                Console.WriteLine("OK" + " my:" + pos + " sys:" + posSystem);
                return true;
            }
            else
            {
                Console.WriteLine("False"+" my:"+pos+" sys:"+posSystem);
                return false;

            }
        }
    }
         
}