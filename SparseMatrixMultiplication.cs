using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode_CSharp
{
    /// <summary>
    /// 311. Sparse Matrix Multiplication
    /// Given two sparse matrices A and B, return the result of AB.
    /// You may assume that A's column number is equal to B's row number.
    /// Example:
    /// Input:
    /// A = [
    ///   [ 1, 0, 0],
    ///   [-1, 0, 3]
    /// ]
    /// B = [
    ///   [ 7, 0, 0 ],
    ///   [ 0, 0, 0 ],
    ///   [ 0, 0, 1 ]
    /// ]
    /// Output:
    ///      |  1 0 0 |   | 7 0 0 |   |  7 0 0 |
    /// AB = | -1 0 3 | x | 0 0 0 | = | -7 0 3 |
    ///                   | 0 0 1 |
    /// </summary>
    public class SparseMatrixMultiplication
    {
        public int[][] Multiply(int[][] A, int[][] B)
        {
            int rowA = A.Length, columnA = A[0].Length, rowB = B.Length, columnB = B[0].Length;

            int[][] result = new int[rowA][];

            for (int i = 0; i < rowA; i++)
            {
                result[i] = new int[columnB];
            }

            for (int i = 0; i < rowA; i++)
            {
                for (int j = 0; j < columnA; j++)
                {
                    if (A[i][j] != 0)
                    {
                        for (int k = 0; k < columnB; k++)
                        {
                            if (B[j][k] != 0)
                            {
                                result[i][k] += A[i][j] * B[j][k];
                            }
                        }
                    }
                }
            }

            return result;
        }
    }
}
