using System;
namespace LeetCode_CSharp
{
    /// <summary>
    /// Write an efficient algorithm that searches for a value in an m x n matrix. This matrix has the following properties:
    /// Integers in each row are sorted in ascending from left to right.
    /// Integers in each column are sorted in ascending from top to bottom.
    /// </summary>
    public class SearchA2DMatrixII
    {
        public bool SearchMatrix(int[,] matrix, int target)
        {
            // Check for null and empty matrix
            if (matrix == null || matrix.GetLength(0) == 0)
            {
                return false;
            }

            int row = matrix.GetLength(0), column = matrix.GetLength(1);
            int r = row - 1, c = 0;
            /// Start from the bottom left cell, move up if the target is smaller than the current value
            /// move right if the target is larger than the current value
            while (r >= 0 && c < column)
            {
                if (matrix[r, c] == target)
                {
                    return true;
                }

                if (matrix[r, c] < target)
                {
                    c++;
                }
                else
                {
                    r--;
                }
            }

            return false;
        }
    }
}
