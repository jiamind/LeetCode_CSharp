using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode_CSharp
{
    /// <summary>
    /// Amazon Online Assessment
    /// </summary>
    public class RobotRemovesObstacle
    {
        public int removeObstacle(int numRows, int numColumns, int[,] lot)
        {
            Queue<int[]> queue = new Queue<int[]>();
            bool[,] visited = new bool[numRows, numColumns];

            queue.Enqueue(new int[] { 0, 0, 0 });

            while (queue.Any())
            {
                int[] cell = queue.Dequeue();
                int row = cell[0], column = cell[1], distance = cell[2];
                if (visited[row, column])
                {
                    continue;
                }

                visited[row, column] = true;

                if (lot[row, column] == 9)
                {
                    return distance;
                }

                if (row - 1 >= 0 && (lot[row - 1, column] == 1))
                {
                    queue.Enqueue(new int[] { row - 1, column, distance + 1 });
                }

                if (row + 1 < numRows && lot[row + 1, column] == 1)
                {
                    queue.Enqueue(new int[] { row + 1, column, distance + 1 });
                }

                if (column - 1 >= 0 && lot[row, column - 1] == 1)
                {
                    queue.Enqueue(new int[] { row, column - 1, distance + 1 });
                }

                if (column + 1 < numColumns && lot[row, column + 1] == 1)
                {
                    queue.Enqueue(new int[] { row, column + 1, distance + 1 });
                }
            }

            return -1;
        }
    }
}
