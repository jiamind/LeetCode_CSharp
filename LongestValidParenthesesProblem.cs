using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode_CSharp
{
    /// <summary>
    /// 32. Longest Valid Parentheses
    /// Given a string containing just the characters '(' and ')', find the length of the longest valid (well-formed) parentheses substring.
    /// Example 1:
    /// Input: "(()"
    /// Output: 2
    /// Explanation: The longest valid parentheses substring is "()"
    /// Example 2:
    /// Input: ")()())"
    /// Output: 4
    /// Explanation: The longest valid parentheses substring is "()()"
    /// </summary>
    public class LongestValidParenthesesProblem
    {
        /// <summary>
        /// Push the index of all left parentheses '(' to the stack
        /// If we are at a right parentheses ')', push its index only if the stack is empty or the top in the stack is also a right parentheses ')'
        /// Otherwise (the top in the stack is a left parentheses), pop the top and update the max with the new top index in the stack
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public int LongestValidParentheses(string s)
        {
            int max = 0;
            int len = 0;
            Stack<int> stack = new Stack<int>();

            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == '(')
                {
                    stack.Push(i);
                }
                else if (s[i] == ')')
                {
                    if (!stack.Any() || (s[stack.Peek()] == ')'))
                    {
                        stack.Push(i);
                    }
                    else if (s[stack.Peek()] == '(')
                    {
                        stack.Pop();
                        max = Math.Max(max, i - (stack.Any() ? stack.Peek() : -1));
                    }
                }
            }

            return max;
        }
    }
}
