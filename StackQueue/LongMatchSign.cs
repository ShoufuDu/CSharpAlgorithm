using System;
using System.Collections.Generic;
using System.Linq;
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
            for (int i = 0; i < s.Length; i++)
                for (int j = i + 1; j < s.Length; j++)
                    if (j - i + 1 > maxLen && MatchSignIsValid (s.Substring (i, j - i + 1))) {
                        maxLen = j - i + 1;
                    }

            return maxLen;
        }

        // Method 2: Stack, only open parenthesis(left parenthesis) is put into stack,
        // closed parenthesis(right parenthesis) is used to judge whether it is matching
        static public int LongMatchSign_2 (String s) {
            int maxLen = 0;
            int last = -1; // used to track the last unmatched ')'
            Stack<int> signStack = new Stack<int> ();

            for (int i = 0; i < s.Length; i++) {
                if (s[i] == '(') {
                    signStack.Push (i);
                } else {
                    if (signStack.Count == 0) {
                        last = i; //record the last ')'
                    } else // find a match
                    {
                        signStack.Pop ();
                        if (signStack.Count == 0) {
                            maxLen = Math.Max (maxLen, i - last);
                        } else {
                            maxLen = Math.Max (maxLen, i - signStack.Peek ());
                        }
                    }
                }
            }

            return maxLen;
        }

        // f[i] refer to max match length of the subsequence begining from index i to the end of s;
        // f[len-1]===0
        //  0                         i i+1     f[i+1]            match          len-1
        //  |                         |  |-----------------------|  |              |
        //  -  - - - - - - - - - - -  -  -  - - - - - - - - - -  -  -  -  -  -  -  -
        //                                                             |
        //                                                          match+1
        static public int LongMatchSign_Dynamicprogramming (String s) {

            if (string.IsNullOrEmpty (s))
                return 0;

            int[] f = new int[s.Length];
            f[s.Length - 1] = 0;
            int match, maxLen = 0;

            for (int i = s.Length - 2; i >= 0; i--) {
                match = i + f[i + 1] + 1;
                if (s[i] == '(' && match < s.Length && s[match] == ')') {
                    f[i] = f[i + 1] + 2;
                    if (match + 1 < s.Length) {
                        f[i] += f[match + 1];
                    }
                }

                maxLen = Math.Max (maxLen, f[i]);
            }

            return maxLen;
        }

        static public void Test_LongMatchSign_1 () {
            string s1 = "()()()))(((()))))";

            Expect.Expect1 ("Test LongMatchSign_1", LongMatchSign_1, s1, 8);

            Expect.Expect1 ("Test LongMatchSign_2", LongMatchSign_2, s1, 8);

            Expect.Expect1 ("Test LongMatchSign_Dynamicprogramming", LongMatchSign_Dynamicprogramming, s1, 8);

            s1 = "()";

            Expect.Expect1 ("Test LongMatchSign_1", LongMatchSign_1, s1, 2);

            Expect.Expect1 ("Test LongMatchSign_2", LongMatchSign_2, s1, 2);

            Expect.Expect1 ("Test LongMatchSign_Dynamicprogramming", LongMatchSign_Dynamicprogramming, s1, 2);

            s1 = ")";

            Expect.Expect1 ("Test LongMatchSign_1", LongMatchSign_1, s1, 0);

            Expect.Expect1 ("Test LongMatchSign_2", LongMatchSign_2, s1, 0);

            Expect.Expect1 ("Test LongMatchSign_Dynamicprogramming", LongMatchSign_Dynamicprogramming, s1, 0);

            s1 = "(";

            Expect.Expect1 ("Test LongMatchSign_1", LongMatchSign_1, s1, 0);

            Expect.Expect1 ("Test LongMatchSign_2", LongMatchSign_2, s1, 0);

            Expect.Expect1 ("Test LongMatchSign_Dynamicprogramming", LongMatchSign_Dynamicprogramming, s1, 0);

            s1 = "((((())";

            Expect.Expect1 ("Test LongMatchSign_1", LongMatchSign_1, s1, 4);

            Expect.Expect1 ("Test LongMatchSign_2", LongMatchSign_2, s1, 4);

            Expect.Expect1 ("Test LongMatchSign_Dynamicprogramming", LongMatchSign_Dynamicprogramming, s1, 4);
        }
    }
}