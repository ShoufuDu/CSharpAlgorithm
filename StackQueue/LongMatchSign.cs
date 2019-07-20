using System.Linq;
using System;
using System.Collections.Generic;
using CSharpAlgorithm.Util;

namespace CSharpAlgorithm.StackQueue {
    public partial class StackQueueSolution {
            // Longest Valid Parentheses
            // Given a string containing just the characters '(' and ')', find the length of the longest valid (well- formed) parentheses substring.
            // For "(()", the longest valid parentheses substring is "()", which has length = 2.
            // Another example is ")()())", where the longest valid parentheses substring is "()()", which has length = 4.

            // Method 1: The brute-force
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

            // Method 2: Stack
            static public int LongMatchSign_2(String s){
                int maxLen = 0;
                int last = -1; // used to track the last unmatched ')'
                Stack<int> signStack = new Stack<int>();

                for(int i=0;i<s.Length;i++)
                {
                    if(s[i]=='('){
                        signStack.Push(i);
                    }
                    else
                    {
                        if(signStack.Count == 0)
                        {
                            last = i; //record the last ')'
                        }
                        else // find a match
                        {
                            signStack.Pop();
                            if(signStack.Count==0)
                            {
                                maxLen = Math.Max(maxLen,i-last);
                            }
                            else
                            {
                                maxLen = Math.Max(maxLen,i-signStack.Peek());
                            }
                        }
                    }
                }

                return maxLen;
            }

            static public void Test_LongMatchSign_1()
            {
                string s1 = "()()()))(((()))))";

                Expect.Expect1("Test LongMatchSign_1",LongMatchSign_1,s1,8);

                Expect.Expect1("Test LongMatchSign_2",LongMatchSign_2,s1,8);
            }
        }
}