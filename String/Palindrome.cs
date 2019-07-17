using System;
using System.Linq;

namespace CSharpAlgorithm.MyString
{

    public partial class StringSolution
    {

        // Given a string, determine if it is a palindrome, considering only alphanumeric characters and ignoring cases.
        // For example,
        // "A man, a plan, a canal: Panama" is a palindrome. "race a car" is not a palindrome.
        // Note: Have you consider that the string might be empty? This is a good question to ask during an interview.
        // For the purpose of this problem, we define empty string as valid palindrome.

        //error
        static bool ValidPalindrome1(string str)
        {
            if (System.String.IsNullOrEmpty(str))
                return false;

            string trimStr = str.Trim().ToLower();


            for (int i = 0, j = trimStr.Length - 1; i < trimStr.Length / 2; i++, j--)
            {
                while (i < str.Length / 2 && !char.IsLetter(trimStr[i]))
                    i++;

                while (j > str.Length / 2 && !char.IsLetter(trimStr[j]))
                    j--;

                if (trimStr[i] != trimStr[j])
                    return false;
            }

            return true;
        }

        static bool ValidPalindrome2(string str)
        {

            string trimStr = str.Trim().ToLower();
            if (string.IsNullOrEmpty(trimStr))
                return false;

            var tempArr = trimStr.ToCharArray().Where(c => char.IsLetter(c)).Select(c => c); //the result of Select is IEnumberable<T>

            char[] charArray = tempArr.ToArray();  //
            char[] reverseArray = charArray.Reverse().ToArray(); //the resulte of Array's Reverse is also IEnumberable<T>

            string newStr = new string(charArray);

            if (newStr.CompareTo(new string(reverseArray)) == 0)
                return true;

            return false;

        }

        static public bool TestValidPalindrome()
        {

            string testStr = "A man, a plan, a canal: Pan1ama";

            if (ValidPalindrome2(testStr))
                Console.WriteLine("Palindrome2");
            else
                Console.WriteLine("No palindrome2");


            if (ValidPalindrome2(testStr))
                Console.WriteLine("Palindrome1");
            else
                Console.WriteLine("No palindrome1");

            return false;
        }
    }
}