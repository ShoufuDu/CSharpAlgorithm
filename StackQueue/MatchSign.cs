using System.Collections.Generic;
using CSharpAlgorithm.Util;

namespace CSharpAlgorithm.StackQueue {

    // Given a string containing just the characters '(', ')', '{', '}', '[' and ']', determine if the input string is valid.
    // The brackets must close in the correct order, "()" and "()[]" are all valid but "(]" and "([)]" are not.
    public partial class StackQueueSolution {

        public static readonly Dictionary<char, char> signs = new Dictionary<char, char> { { '(', ')' },
            { '[', ']' },
            { '{', '}' }
        };
        public static bool MatchSignIsValid (string s) {

            Stack<char> stack = new Stack<char> ();

            stack.Push (s[0]);

            for (int i = 1; i < s.Length; i++) {
                if (stack.Count == 0) {
                    stack.Push (s[i]);
                    continue;
                }

                if (IsMatch (stack.Peek (), s[i])) {
                    stack.Pop ();
                } else {
                    stack.Push (s[i]);
                }
            }

            if (stack.Count == 0)
                return true;
            else
                return false;

        }

        public static bool IsMatch (char a, char b) {
            char c;
            if (signs.TryGetValue (a, out c) && c == b)
                return true;
            else
                return false;
        }

        public static void TestMatchSign () {
            const string testString = "()()[{()}]";
            Expect.Expect1 ("TestMatchSign", MatchSignIsValid, testString, true);

            const string testStr1 = "[(]}";
            Expect.Expect1 ("TestMatchSign", MatchSignIsValid, testStr1, false);

            const string testStr3 = "[{[()]}]";
            Expect.Expect1 ("TestMatchSign", MatchSignIsValid, testStr3, true);
        }
    }
}