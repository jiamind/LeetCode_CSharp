using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode_CSharp
{
    /// <summary>
    /// 348. Design Tic-Tac-Toe
    /// Design a Tic-tac-toe game that is played between two players on a n x n grid.
    /// You may assume the following rules:
    /// A move is guaranteed to be valid and is placed on an empty block.
    /// Once a winning condition is reached, no more moves is allowed.
    /// A player who succeeds in placing n of their marks in a horizontal, vertical, or diagonal row wins the game.
    /// </summary>
    public class TicTacToe
    {

        private int[] rowSum;
        private int[] columnSum;
        private int diagonal;
        private int antiDiagonal;
        private int n;

        /** Initialize your data structure here. */
        public TicTacToe(int n)
        {
            rowSum = new int[n];
            columnSum = new int[n];
            diagonal = 0;
            antiDiagonal = 0;
            this.n = n;
        }

        /** Player {player} makes a move at ({row}, {col}).
            @param row The row of the board.
            @param col The column of the board.
            @param player The player, can be either 1 or 2.
            @return The current winning condition, can be either:
                    0: No one wins.
                    1: Player 1 wins.
                    2: Player 2 wins. */
        public int Move(int row, int col, int player)
        {
            // When play 1 moves, put value 1; when play 2 moves, put value -1
            // Keep track of the sum of values at each row and column, diagonal and anti-diagonal
            // If the absolute value of sum at any row, column, diagonal, or anti-diagonal equals the length of the board
            // The player wins
            int value = player == 1 ? 1 : -1;

            rowSum[row] += value;
            columnSum[col] += value;

            if (row == col)
            {
                diagonal += value;
            }

            if (row + col == n - 1)
            {
                antiDiagonal += value;
            }

            if (Math.Abs(rowSum[row]) == n || Math.Abs(columnSum[col]) == n || Math.Abs(diagonal) == n || Math.Abs(antiDiagonal) == n)
            {
                return player;
            }

            return 0;
        }
    }
}
