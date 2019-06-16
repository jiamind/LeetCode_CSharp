using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode_CSharp
{
    /// <summary>
    /// Given a 2D binary matrix filled with 0's and 1's, find the largest rectangle containing only 1's and return its area.
    /// Example:
    /// Input:
    /// [
    ///   ["1","0","1","0","0"],
    ///   ["1","0","1","1","1"],
    ///   ["1","1","1","1","1"],
    ///   ["1","0","0","1","0"]
    /// ]
    /// Output: 6
    /// </summary>
    public class MaximalRectangleProblem
    {
        /// <summary>
        /// Scan from the first row to the last row. Use an array to keep track of the height at each index of each row.
        /// Find the max area at each row
        /// </summary>
        /// <param name="matrix">the input matrix</param>
        /// <returns>the maximum rectangle area</returns>
        public int MaximalRectangle(char[][] matrix)
        {
            if (matrix == null || matrix.Length == 0 || matrix[0].Length == 0)
            {
                return 0;
            }

            int[] rowHeights = new int[matrix[0].Length];
            int max = 0;

            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[0].Length; j++)
                {
                    if (matrix[i][j] == '1')
                    {
                        rowHeights[j]++;
                    }
                    else
                    {
                        rowHeights[j] = 0;
                    }
                }

                max = Math.Max(max, MaxAreaAtRow(rowHeights));
            }

            return max;
        }


        private static int MaxAreaAtRow(int[] rowHeights)
        {
            Stack<int> s = new Stack<int>();
            int maxArea = 0;
            // Iterate through the array
            for (int i = 0; i <= rowHeights.Length; i++)
            {
                // Get the height of the current bar
                int h = (i == rowHeights.Length ? 0 : rowHeights[i]);
                // If the stack is empty, or the current bar is taller than the top in the stack
                // Push it into the stack
                // Otherwise, consider the top bar in the stack is the minimum height of a series of consecutive bars,
                // bounded by the current i and the previous bar in the stack.
                // Update the max height
                if (!s.Any() || h >= rowHeights[s.Peek()])
                {
                    s.Push(i);
                }
                else
                {
                    int tp = s.Pop();
                    maxArea = Math.Max(maxArea, rowHeights[tp] * (s.Any() ? i - 1 - s.Peek() : i));
                    i--;
                }
            }
            return maxArea;
        }
    }
}
