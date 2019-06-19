using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode_CSharp
{
    /// <summary>
    /// 51. N-Queens
    /// The n-queens puzzle is the problem of placing n queens on an n×n chessboard such that no two queens attack each other.
    /// Given an integer n, return all distinct solutions to the n-queens puzzle.
    /// Each solution contains a distinct board configuration of the n-queens' placement, where 'Q' and '.' both indicate a queen and an empty space respectively.
    /// Example:
    /// Input: 4
    /// Output: [
    ///      [".Q..",  // Solution 1
    ///       "...Q",
    ///       "Q...",
    ///       "..Q."],
    ///      ["..Q.",  // Solution 2
    ///       "Q...",
    ///       "...Q",
    ///       ".Q.."]
    ///      ]
    /// Explanation: There exist two distinct solutions to the 4-queens puzzle as shown above.
    /// </summary>
    public class NQeens
    {
        public IList<IList<string>> SolveNQueens(int n)
        {
            List<IList<string>> result = new List<IList<string>>();

            if (n <= 0)
            {
                return result;
            }

            // Fill the chessboard with '.' (empty space) as the starting state
            char[][] solution = new char[n][];
            for (int i = 0; i < n; i++)
            {
                solution[i] = new char[n];
                for (int j = 0; j < n; j++)
                {
                    solution[i][j] = '.';
                }
            }

            this.Solve(result, solution, 0, n);

            return result;
        }

        private void Solve(List<IList<string>> result, char[][] solution, int currentRow, int n)
        {
            if (currentRow == n)
            {
                //// If row reaches the end, we finished.
                //// Add the list to the result
                List<string> s = new List<string>();
                foreach (char[] array in solution)
                {
                    s.Add(new string(array));
                }

                result.Add(s);
            }
            else
            {
                for (int i = 0; i < n; i++)
                {
                    // We try to fill in a 'Q', to see if it's valid
                    if (IsValid(solution, i, currentRow, n))
                    {
                        // If it is valid, we write down this 'Q'
                        solution[currentRow][i] = 'Q';

                        //// We are finished with this row since only one 'Q' is allowed per row
                        //// We move on to the next row
                        this.Solve(result, solution, currentRow + 1, n);

                        // We finished this round. Remove the 'Q' we just filled. Ready to try the next column position
                        solution[currentRow][i] = '.';
                    }
                }
            }
        }

        private bool IsValid(char[][] solution, int column, int row, int n)
        {
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (solution[i][j] == 'Q' && (Math.Abs(row - i) == Math.Abs(column - j) || (column == j)))
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
