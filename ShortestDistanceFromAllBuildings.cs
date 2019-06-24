using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode_CSharp
{
    /// <summary>
    /// 317. Shortest Distance from All Buildings
    /// You want to build a house on an empty land which reaches all buildings in the shortest amount of distance. You can only move up, down, left and right. You are given a 2D grid of values 0, 1 or 2, where:
    /// Each 0 marks an empty land which you can pass by freely.
    /// Each 1 marks a building which you cannot pass through.
    /// Each 2 marks an obstacle which you cannot pass through.
    /// Example:
    /// Input: [[1,0,2,0,1], [0,0,0,0,0], [0,0,1,0,0]]
    /// 1 - 0 - 2 - 0 - 1
    /// |   |   |   |   |
    /// 0 - 0 - 0 - 0 - 0
    /// |   |   |   |   |
    /// 0 - 0 - 1 - 0 - 0
    /// Output: 7 
    /// Explanation: Given three buildings at(0,0), (0,4), (2,2), and an obstacle at(0,2),
    ///              the point(1,2) is an ideal empty land to build a house, as the total
    ///              travel distance of 3+3+1=7 is minimal.So return 7.
    /// Note:
    /// There will be at least one building.If it is not possible to build such house according to the above rules, return -1.
    /// </summary>
    public class ShortestDistanceFromAllBuildings
    {
        /// <summary>
        /// Use BFS from each building to update the distance from each building to each empty land
        /// Note: do not use DFS as empty land may be access through different path from the same building, hence you have to keep track of the minimum
        /// </summary>
        /// <param name="grid">the grid</param>
        /// <returns>the shortest sum of distances from the house to each building</returns>
        public int ShortestDistance(int[][] grid)
        {
            // Each time we update the distance from each building, we only visit empty land that is accessible to all previous buildings (and of course not yet visited from the current building)
            int[,] visitedCount = new int[grid.Length, grid[0].Length];
            int num = 0;

            for (int i = 0; i < grid.Length; i++)
            {
                for (int j = 0; j < grid[0].Length; j++)
                {
                    if (grid[i][j] == 1)
                    {
                        this.UpdateDistance(grid, i, j, visitedCount, num);
                        num++;
                    }
                }
            }

            int min = Int32.MinValue;

            for (int i = 0; i < grid.Length; i++)
            {
                for (int j = 0; j < grid[0].Length; j++)
                {
                    if (visitedCount[i, j] == num)
                    {
                        min = Math.Max(min, grid[i][j]);
                    }
                }
            }

            return min == Int32.MinValue ? -1 : Math.Abs(min);
        }

        private void UpdateDistance(int[][] grid, int i, int j, int[,] visitedCount, int num)
        {
            Queue<int[]> queue = new Queue<int[]>();
            queue.Enqueue(new int[3] { i, j, 0 });

            while (queue.Any())
            {
                int[] cell = queue.Dequeue();
                int r = cell[0], c = cell[1], currentDistance = cell[2] + 1;

                if (r - 1 >= 0 && grid[r - 1][c] <= 0 && visitedCount[r - 1, c] == num)
                {
                    grid[r - 1][c] -= currentDistance;
                    visitedCount[r - 1, c] += 1;
                    queue.Enqueue(new int[3] { r - 1, c, currentDistance });
                }

                if (r + 1 <= grid.Length - 1 && grid[r + 1][c] <= 0 && visitedCount[r + 1, c] == num)
                {
                    grid[r + 1][c] -= currentDistance;
                    visitedCount[r + 1, c] += 1;
                    queue.Enqueue(new int[3] { r + 1, c, currentDistance });
                }

                if (c - 1 >= 0 && grid[r][c - 1] <= 0 && visitedCount[r, c - 1] == num)
                {
                    grid[r][c - 1] -= currentDistance;
                    visitedCount[r, c - 1] += 1;
                    queue.Enqueue(new int[3] { r, c - 1, currentDistance });
                }

                if (c + 1 <= grid[0].Length - 1 && grid[r][c + 1] <= 0 && visitedCount[r, c + 1] == num)
                {
                    grid[r][c + 1] -= currentDistance;
                    visitedCount[r, c + 1] += 1;
                    queue.Enqueue(new int[3] { r, c + 1, currentDistance });
                }
            }
        }
    }
}
