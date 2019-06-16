using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode_CSharp
{
    public class MaximalSquareProblem
    {
        /// <summary>
        /// 221. Maximal Square
        /// Given a 2D binary matrix filled with 0's and 1's, find the largest square containing only 1's and return its area.
        /// Example:
        /// Input: 
        /// 1 0 1 0 0
        /// 1 0 1 1 1
        /// 1 1 1 1 1
        /// 1 0 0 1 0
        /// Output: 4
        /// </summary>
        /// <param name="matrix"></param>
        /// <returns></returns>
        public int MaximalSquare(char[][] matrix)
        {
            if (matrix == null || matrix.Length == 0 || matrix[0].Length == 0)
            {
                return 0;
            }

            // Store the maximum possible square side length when the bottom left corner of the square is (i,j)
            int[,] dp = new int[matrix.Length, matrix[0].Length];
            int maxLength = 0;

            for (int i = 0; i < matrix[0].Length; i++)
            {
                dp[0, i] = int.Parse(matrix[0][i].ToString());
                maxLength = Math.Max(maxLength, dp[0, i]);
            }

            for (int i = 0; i < matrix.Length; i++)
            {
                dp[i, 0] = int.Parse(matrix[i][0].ToString());
                maxLength = Math.Max(maxLength, dp[i, 0]);
            }

            for (int i = 1; i < matrix.Length; i++)
            {
                for (int j = 1; j < matrix[0].Length; j++)
                {
                    if (matrix[i][j] == '1')
                    {
                        dp[i, j] = Math.Min(Math.Min(dp[i - 1, j], dp[i, j - 1]), dp[i - 1, j - 1]) + 1;
                        maxLength = Math.Max(maxLength, dp[i, j]);
                    }
                }
            }

            return maxLength * maxLength;
        }
    }
}
