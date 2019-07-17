using System.Linq;
using System;
using System.Diagnostics;

namespace CSharpAlgorithm.MyString
{

    class TestString{

        public static void TestBasicFunction(string str)
        {
            Console.WriteLine(str);

            string Test = "my name is a bad boy";

            string substr = Test.Substring(0,2);

            Debug.Assert(substr=="my");

            substr = Test.Substring(3);
            Debug.Assert(substr == "name is a bad boy");

            //Console.WriteLine(substr);

            string insertStr = Test.Insert(3,"chinese ");

            //Console.WriteLine(insertStr);
            Debug.Assert(insertStr == "my chinese name is a bad boy");

            string[] splitStr = Test.Split(' ');
            foreach(var item in splitStr){
                Console.WriteLine(item);
            }

            char[] reverseChar = Test.ToCharArray();
            //string reverseDirstr = Test.Reverse();
            System.Array.Reverse(reverseChar);
            String reverseDirstr = new String(reverseChar);
            var reverseStr = Test.Reverse().ToArray();
            var charIEnumerable = reverseChar.Reverse<char>();

            string test1 = "";
            Console.WriteLine("new:"+test1.Insert(0, "dafs")+"|old:"+test1);


            string test2 = "My name is a good boy of china";
            Console.WriteLine("new:" + test2.Replace(' ', '-') + "|old:" + test2);

            string test3 = "My name is a good boy of china";
            Console.WriteLine("new:" + test2.Remove(0,3) + "|old:" + test3);


            string test4 = "My name is a good boy of china";
            Console.WriteLine("new:" + test4.ToUpper() + "|old:" + test4);
        }
    }

}