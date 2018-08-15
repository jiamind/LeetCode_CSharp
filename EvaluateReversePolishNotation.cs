using System.Collections.Generic;

namespace LeetCode_CSharp
{
    /// <summary>
    /// Evaluate the value of an arithmetic expression in Reverse Polish Notation.
    /// Valid operators are +, -, *, /. Each operand may be an integer or another expression.
    /// Note:
    /// Division between two integers should truncate toward zero.
    /// The given RPN expression is always valid. That means the expression would always evaluate to a result and there won't be any divide by zero operation.
    /// </summary>
    class EvaluateReversePolishNotation
    {
        // Defines valid operations
        public static List<string> operators = new List<string>() { "+", "-", "*", "/" };

        /// <summary>
        /// Evaluates the value of an arithmetic expression in Reverse Polish Notation
        /// </summary>
        /// <returns>the value of the evaluation</returns>
        /// <param name="tokens">array of tokens</param>
        public int EvalRPN(string[] tokens)
        {
            // Create a stack to store numbers and evaluation results
            Stack<int> stack = new Stack<int>();
            foreach (string token in tokens)
            {
                // Push numbers to the stack
                // If the token is a valid operator, pop the last two values, evaluate and push the result
                if (!operators.Contains(token))
                {
                    stack.Push(int.Parse(token));
                }
                else
                {
                    int rightValue = stack.Pop();
                    int leftValue = stack.Pop();
                    stack.Push(Evaluate(leftValue, rightValue, token));
                }
            }

            // The stack should always end up with one value, which is the result of the whole evaluation
            return stack.Pop();
        }

        /// <summary>
        /// Evaluate using the specified leftValue, rightValue and operation.
        /// </summary>
        /// <returns>The value of the evaluation.</returns>
        /// <param name="leftValue">Left value.</param>
        /// <param name="rightValue">Right value.</param>
        /// <param name="op">Operator.</param>
        private static int Evaluate(int leftValue, int rightValue, string op)
        {
            switch (op)
            {
                case "+":
                    return leftValue + rightValue;
                case "-":
                    return leftValue - rightValue;
                case "*":
                    return leftValue * rightValue;
                case "/":
                    return leftValue / rightValue;
            }

            return 0;
        }
    }
}