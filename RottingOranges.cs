using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode_CSharp
{
    /// <summary>
    /// 994. Rotting Oranges
    /// In a given grid, each cell can have one of three values:
    /// the value 0 representing an empty cell;
    /// the value 1 representing a fresh orange;
    /// the value 2 representing a rotten orange.
    /// Every minute, any fresh orange that is adjacent (4-directionally) to a rotten orange becomes rotten.
    /// Return the minimum number of minutes that must elapse until no cell has a fresh orange.If this is impossible, return -1 instead.
    /// Example 1:
    /// Input: [[2,1,1], [1,1,0], [0,1,1]]
    /// Output: 4
    /// Example 2:
    /// Input: [[2,1,1],[0,1,1],[1,0,1]]
    /// Output: -1
    /// Explanation:  The orange in the bottom left corner(row 2, column 0) is never rotten, because rotting only happens 4-directionally.
    /// Example 3:
    /// Input: [[0,2]]
    /// Output: 0
    /// Explanation:  Since there are already no fresh oranges at minute 0, the answer is just 0.
    /// </summary>
    public class RottingOranges
    {
        public int OrangesRotting(int[][] grid)
        {
            if (grid == null || grid.Length == 0 || grid[0].Length == 0)
            {
                return 0;
            }

            Queue<int[]> rottenOranges = new Queue<int[]>();
            int[][] directions = new int[4][]
            {
                new int[2] {-1,0},
                new int[2] {1,0},
                new int[2] {0,-1},
                new int[2] {0,1}
            };

            for (int i = 0; i < grid.Length; i++)
            {
                for (int j = 0; j < grid[0].Length; j++)
                {
                    if (grid[i][j] == 2)
                    {
                        rottenOranges.Enqueue(new int[2] { i, j });
                    }
                }
            }

            int rounds = 0;

            while (rottenOranges.Any())
            {
                int count = rottenOranges.Count();
                for (int i = 0; i < count; i++)
                {
                    int[] orange = rottenOranges.Dequeue();
                    int row = orange[0], column = orange[1];
                    foreach (int[] direction in directions)
                    {
                        if (row + direction[0] < grid.Length && row + direction[0] >= 0 && column + direction[1] < grid[0].Length && column + direction[1] >= 0 && grid[row + direction[0]][column + direction[1]] == 1)
                        {
                            grid[row + direction[0]][column + direction[1]] = 2;
                            rottenOranges.Enqueue(new int[2] { (row + direction[0]), column + direction[1] });
                        }
                    }
                }

                rounds++;
            }

            for (int i = 0; i < grid.Length; i++)
            {
                for (int j = 0; j < grid[0].Length; j++)
                {
                    if (grid[i][j] == 1)
                    {
                        return -1;
                    }
                }
            }

            // When there's no rotten orange at the very beginning, return 0 instead of -1
            return Math.Max(rounds - 1, 0);
        }
    }
}
