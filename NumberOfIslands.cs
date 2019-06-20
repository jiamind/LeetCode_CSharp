using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode_CSharp
{
    /// <summary>
    /// 200. Number of Islands
    /// Given a 2d grid map of '1's (land) and '0's (water), count the number of islands. An island is surrounded by water and is formed by connecting adjacent lands horizontally or vertically. You may assume all four edges of the grid are all surrounded by water.
    /// Example 1:
    /// Input:
    /// 11110
    /// 11010
    /// 11000
    /// 00000
    /// Output: 1
    /// Example 2:
    /// Input:
    /// 11000
    /// 11000
    /// 00100
    /// 00011
    /// Output: 3
    /// </summary>
    public class NumberOfIslands
    {
        /// <summary>
        /// Iterate each cell in the 2d array. Use dfs on unvisited islands and mark all adjacent islands as visited
        /// </summary>
        /// <param name="grid">the 2d grid map</param>
        /// <returns>the number of island in the map</returns>
        public int NumIslands(char[][] grid)
        {
            if (grid == null || grid.Length == 0 || grid[0].Length == 0)
            {
                return 0;
            }

            bool[,] visited = new bool[grid.Length, grid[0].Length];
            int count = 0;
            for (int i = 0; i < grid.Length; i++)
            {
                for (int j = 0; j < grid[0].Length; j++)
                {
                    if (grid[i][j] == '1' && !visited[i, j])
                    {
                        count++;
                        MarkIslandVisited(grid, i, j, visited);
                    }
                }
            }

            return count;
        }

        public void MarkIslandVisited(char[][] grid, int r, int c, bool[,] visited)
        {
            if (grid[r][c] == '1' && !visited[r, c])
            {
                visited[r, c] = true;

                if (r > 0)
                {
                    MarkIslandVisited(grid, r - 1, c, visited);
                }

                if (r < grid.Length - 1)
                {
                    MarkIslandVisited(grid, r + 1, c, visited);
                }

                if (c > 0)
                {
                    MarkIslandVisited(grid, r, c - 1, visited);
                }

                if (c < grid[0].Length - 1)
                {
                    MarkIslandVisited(grid, r, c + 1, visited);
                }
            }
        }
    }
}
