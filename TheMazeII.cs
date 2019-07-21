using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode_CSharp
{
    /// <summary>
    /// 505. The Maze II
    /// There is a ball in a maze with empty spaces and walls. The ball can go through empty spaces by rolling up, down, left or right, but it won't stop rolling until hitting a wall. When the ball stops, it could choose the next direction.
    /// Given the ball's start position, the destination and the maze, find the shortest distance for the ball to stop at the destination. The distance is defined by the number of empty spaces traveled by the ball from the start position (excluded) to the destination (included). If the ball cannot stop at the destination, return -1.
    /// The maze is represented by a binary 2D array. 1 means the wall and 0 means the empty space.You may assume that the borders of the maze are all walls.The start and destination coordinates are represented by row and column indexes.
    /// Example 1:
    /// Input 1: a maze represented by a 2D array
    /// 0 0 1 0 0
    /// 0 0 0 0 0
    /// 0 0 0 1 0
    /// 1 1 0 1 1
    /// 0 0 0 0 0
    /// Input 2: start coordinate (rowStart, colStart) = (0, 4)
    /// Input 3: destination coordinate (rowDest, colDest) = (4, 4)
    /// Output: 12
    /// Explanation: One shortest way is : left -> down -> left -> down -> right -> down -> right.
    /// The total distance is 1 + 1 + 3 + 1 + 2 + 2 + 2 = 12.
    /// </summary>
    public class TheMazeII
    {
        public int ShortestDistance(int[][] maze, int[] start, int[] destination)
        {
            int?[,] visited = new int?[maze.Length, maze[0].Length];
            Queue<int[]> queue = new Queue<int[]>();
            int[] startPos = new int[] { start[0], start[1] };
            queue.Enqueue(startPos);
            visited[start[0], start[1]] = 0;

            while (queue.Any())
            {
                int[] position = queue.Dequeue();

                // Move up
                int rowIndex = position[0], columnIndex = position[1], distance = visited[rowIndex, columnIndex].Value;
                while (rowIndex - 1 >= 0 && maze[rowIndex - 1][columnIndex] != 1)
                {
                    rowIndex--;
                    distance++;
                }

                if (visited[rowIndex, columnIndex] == null || visited[rowIndex, columnIndex].Value > distance)
                {
                    visited[rowIndex, columnIndex] = distance;
                    queue.Enqueue(new int[] { rowIndex, columnIndex, distance });
                }

                // Move down
                rowIndex = position[0]; columnIndex = position[1]; distance = visited[rowIndex, columnIndex].Value;
                while (rowIndex + 1 <= maze.Length - 1 && maze[rowIndex + 1][columnIndex] != 1)
                {
                    rowIndex++;
                    distance++;
                }

                if (visited[rowIndex, columnIndex] == null || visited[rowIndex, columnIndex].Value > distance)
                {
                    visited[rowIndex, columnIndex] = distance;
                    queue.Enqueue(new int[] { rowIndex, columnIndex, distance });
                }

                // Move left
                rowIndex = position[0]; columnIndex = position[1]; distance = visited[rowIndex, columnIndex].Value;
                while (columnIndex - 1 >= 0 && maze[rowIndex][columnIndex - 1] != 1)
                {
                    columnIndex--;
                    distance++;
                }

                if (visited[rowIndex, columnIndex] == null || visited[rowIndex, columnIndex].Value > distance)
                {
                    visited[rowIndex, columnIndex] = distance;
                    queue.Enqueue(new int[] { rowIndex, columnIndex, distance });
                }

                // Move right
                rowIndex = position[0]; columnIndex = position[1]; distance = visited[rowIndex, columnIndex].Value;
                while (columnIndex + 1 <= maze[0].Length - 1 && maze[rowIndex][columnIndex + 1] != 1)
                {
                    columnIndex++;
                    distance++;
                }

                if (visited[rowIndex, columnIndex] == null || visited[rowIndex, columnIndex].Value > distance)
                {
                    visited[rowIndex, columnIndex] = distance;
                    queue.Enqueue(new int[] { rowIndex, columnIndex, distance });
                }
            }

            return visited[destination[0], destination[1]] == null ? -1 : visited[destination[0], destination[1]].Value;
        }
    }
}