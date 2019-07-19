using System.Dynamic;
using CSharpAlgorithm.Util;

namespace CSharpAlgorithm.StackQueue {
    public partial class StackQueueSolution {
            // Longest Valid Parentheses
            // Given a string containing just the characters '(' and ')', find the length of the longest valid (well- formed) parentheses substring.
            // For "(()", the longest valid parentheses substring is "()", which has length = 2.
            // Another example is ")()())", where the longest valid parentheses substring is "()()", which has length = 4.

             static public int LongMatchSign_1 (string s) {
                int maxLen = 0;
                for(int i=0;i<s.Length;i++)
                    for(int j=i+1;j<s.Length;j++)
                        if (j-i+1 > maxLen && MatchSignIsValid(s.Substring(i,j-i+1)))
                        {
                            maxLen = j-i+1;
                        }

                return maxLen;
            }

            static public void Test_LongMatchSign_1()
            {
                string s1 = "()()()))(((()))))";

                Expect.Expect1("Test_LongMatchSign_1",LongMatchSign_1,s1,6);
            }
        }
}