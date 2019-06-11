using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode_CSharp
{
    /// <summary>
    /// 282. Expression Add Operators
    /// Given a string that contains only digits 0-9 and a target value, return all possibilities to add binary operators (not unary) +, -, or * between the digits so they evaluate to the target value.
    /// Example 1:
    /// Input: num = "123", target = 6
    /// Output: ["1+2+3", "1*2*3"] 
    /// Example 2:
    /// Input: num = "232", target = 8
    /// Output: ["2*3+2", "2+3*2"]
    /// Example 3:
    /// Input: num = "105", target = 5
    /// Output: ["1*0+5","10-5"]
    /// Example 4:
    /// Input: num = "00", target = 0
    /// Output: ["0+0", "0-0", "0*0"]
    /// Example 5:
    /// Input: num = "3456237490", target = 9191
    /// Output: []
    /// </summary>
    public class ExpressionAddOperators
    {
        public IList<string> AddOperators(string num, int target)
        {
            char[] array = num.ToCharArray();
            List<string> result = new List<string>();

            AddOperatorsHelper(array, 0, string.Empty, 0, 0, target, result);
            return result;
        }

        /// <summary>
        /// Helper method for add operators
        /// </summary>
        /// <param name="array">the array of numbers in char array</param>
        /// <param name="position">the current reading/scanning position</param>
        /// <param name="wholeExpression">the whole expression string</param>
        /// <param name="wholeEvaluation">the evalutation/value of the whole expression</param>
        /// <param name="currentEvaluation">the current evaluation. The current evaluation is the current number if addition is performed, -current number if subtraction is performed. For multiplication, it's the current number times the previous evaluation</param>
        /// <param name="target">the target value</param>
        /// <param name="result">the result string array</param>
        private void AddOperatorsHelper(char[] array, int position, string wholeExpression, long wholeEvaluation, long currentEvaluation, int target, List<string> result)
        {
            if (position == array.Length)
            {
                if (wholeEvaluation == target)
                {
                    result.Add(wholeExpression);
                }
            }
            else
            {
                // From the current position, form any length of new number until reach the end of the array
                for (int i = position; i < array.Length; i++)
                {
                    //// If we are not at the first digit, and the number at current position is 0, this is not a valid number (e.g. 055)
                    //// If we are at the first digit, and it is 0, it is valid since we can add/subtract/multiply 0
                    if (i != position && array[position] == '0')
                    {
                        break;
                    }

                    long currentNumber = long.Parse(new string(array, position, i - position + 1));

                    // If we are at the head of the array, this is the first number and there is no number before
                    if (position == 0)
                    {
                        AddOperatorsHelper(array, i + 1, currentNumber.ToString(), currentNumber, currentNumber, target, result);
                    }
                    else
                    {
                        AddOperatorsHelper(array, i + 1, wholeExpression + "+" + currentNumber, wholeEvaluation + currentNumber, currentNumber, target, result);
                        AddOperatorsHelper(array, i + 1, wholeExpression + "-" + currentNumber, wholeEvaluation - currentNumber, -currentNumber, target, result);
                        AddOperatorsHelper(array, i + 1, wholeExpression + "*" + currentNumber, wholeEvaluation - currentEvaluation + currentEvaluation * currentNumber, currentEvaluation * currentNumber, target, result);
                    }
                }
            }
        }
    }
}
