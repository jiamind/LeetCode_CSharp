using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode_CSharp
{
    /// <summary>
    /// Given a list of daily temperatures T, return a list such that, for each day in the input, tells you how many days you would have to wait until a warmer temperature. If there is no future day for which this is possible, put 0 instead.
    /// For example, given the list of temperatures T = [73, 74, 75, 71, 69, 72, 76, 73], your output should be[1, 1, 4, 2, 1, 1, 0, 0].
    /// Note: The length of temperatures will be in the range[1, 30000]. Each temperature will be an integer in the range[30, 100].
    /// </summary>
    public class DailyTemperaturesProblem
    {
        /// <summary>
        /// Iterate through the array backwards. Pop any index in the stack whose value in the array is less than the current value 
        /// (since we only need to find the next closest warmer day for the days before the current day)
        /// </summary>
        /// <param name="T">input array of temperatures of the day</param>
        /// <returns>array represents how far the next warmer day is</returns>
        public int[] DailyTemperatures(int[] T)
        {
            int[] result = new int[T.Length];
            Stack<int> stack = new Stack<int>();

            for (int i = T.Length - 1; i >= 0; i--)
            {
                while (stack.Count != 0 && T[i] >= T[stack.Peek()])
                {
                    stack.Pop();
                }

                result[i] = stack.Count == 0 ? 0 : stack.Peek() - i;
                stack.Push(i);
            }

            return result;
        }
    }
}
