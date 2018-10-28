using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode_CSharp
{
    /// <summary>
    /// Implement a basic calculator to evaluate a simple expression string.
    /// The expression string may contain open(and closing parentheses ), the plus + or minus sign -, non-negative integers and empty spaces.
    /// </summary>
    public class BasicCalculator
    {
        public int Calculate(string s)
        {
            Stack<char> stack = new Stack<char>();
            foreach (char c in s)
            {
                // Skip empty space
                if (c == ' ')
                {
                    continue;
                }

                if (c == ')')
                {
                    Stack<char> subStack = new Stack<char>();
                    while (stack.Peek() != '(')
                    {
                        // Reverse the stack before calculation
                        subStack.Push(stack.Pop());
                    }

                    stack.Pop();
                    char[] subResult = this.CalculateSub(subStack);
                    // If the sub result is negative, adjust the previous operator if there is any
                    if (subResult[0] == '-' && stack.Count != 0)
                    {
                        char preOp = stack.Pop();
                        if (preOp == '-')
                        {
                            subResult[0] = '+';
                        }
                    }

                    foreach (char sr in subResult)
                    {
                        stack.Push(sr);
                    }
                }
                else
                {
                    stack.Push(c);
                }
            }

            // Reverse the stack before calculation
            Stack<char> rev = new Stack<char>();
            while (stack.Count != 0)
            {
                rev.Push(stack.Pop());
            }
            char[] resultChar = CalculateSub(rev);
            string resultString = new string(resultChar);
            return Int32.Parse(resultString);
        }

        /// <summary>
        /// Calculate the number operations in the stack
        /// There should be no parenthesises '(' or ')' in the stack
        /// </summary>
        /// <param name="stack">a stack containing the number operations in order</param>
        /// <returns>the char array representing the result in order</returns>
        private char[] CalculateSub(Stack<char> stack)
        {
            int result = 0, num = 0;
            bool isNegative = false;
            StringBuilder sb = new StringBuilder();
            bool prevOpIsPlus = true;
            while (stack.Count != 0)
            {
                char c = stack.Pop();
                if (c == '+' || c == '-')
                {
                    // The length of the string builder is 0 when the first number in the stack is a negative number
                    num = sb.Length == 0 ? 0 : Int32.Parse(sb.ToString());
                    sb.Clear();
                    result = prevOpIsPlus ? result + num : result - num;
                    prevOpIsPlus = c == '+';
                }
                else
                {
                    sb.Append(c);
                }
            }

            num = Int32.Parse(sb.ToString());
            result = prevOpIsPlus ? result + num : result - num;
            // Return '0' if the result is 0
            if (result == 0)
            {
                return new char[] { '0' };
            }

            sb.Clear();
            // Mark if the result is negative
            if (result < 0)
            {
                isNegative = true;
                result *= -1;
            }

            while (result > 0)
            {
                sb.Append(result % 10);
                result /= 10;
            }

            // Append the negative sign
            if (isNegative)
            {
                sb.Append('-');
            }

            char[] resultArray = sb.ToString().ToCharArray();
            Array.Reverse(resultArray);
            return resultArray;
        }
    }
}
