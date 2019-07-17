
using System.Collections.Generic;
using CSharpAlgorithm.Util;

namespace CSharpAlgorithm.StackQueue
{
    public class StackQueueSolution
    {
        public static Dictionary<char,char> signs = new Dictionary<char,char>{
                        {'(',')'},
                        {'[',']'},
                        {'{','}'}
                        };
        public static bool MatchSignIsValid (string s) {

                Stack<char> stack = new Stack<char>();

                stack.Push(s[0]);

                for(int i=1;i<s.Length;i++)
                {
                    if (stack.Count == 0)
                        {
                            stack.Push(s[i]);
                            continue;
                        }

                    if(IsMatch(stack.Peek(),s[i]))
                    {
                        stack.Pop();
                    }
                    else
                    {
                        stack.Push(s[i]);
                    }
                }

                if (stack.Count == 0)
                    return true;
                else
                    return false;

        }

        public static bool IsMatch(char a,char b)
        {
            char c;
            if (signs.TryGetValue(a,out c)&&c==b)
                return true;
            else
                return false;
        }

        public static void TestMatchSign(){
            const string testString = "()()[{()}]";
            Expect.Expect1("TestMatchSign",MatchSignIsValid, testString, true);

            const string testStr1 = "[(]}";
            Expect.Expect1("TestMatchSign",MatchSignIsValid, testStr1, false);

            const string testStr2 = "[{[()]}]";
            Expect.Expect1("TestMatchSign",MatchSignIsValid, testStr2, true);
        }

    }
}