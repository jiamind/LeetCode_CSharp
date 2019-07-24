using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode_CSharp
{
    /// <summary>
    /// 675. Cut Off Trees for Golf Event
    /// You are asked to cut off trees in a forest for a golf event. The forest is represented as a non-negative 2D map, in this map:
    /// 0 represents the obstacle can't be reached.
    /// 1 represents the ground can be walked through.
    /// The place with number bigger than 1 represents a tree can be walked through, and this positive number represents the tree's height.
    /// You are asked to cut off all the trees in this forest in the order of tree's height - always cut off the tree with lowest height first. And after cutting, the original place has the tree will become a grass (value 1).
    /// You will start from the point (0, 0) and you should output the minimum steps you need to walk to cut off all the trees. If you can't cut off all the trees, output -1 in that situation.
    /// You are guaranteed that no two trees have the same height and there is at least one tree needs to be cut off.
    /// Example 1:
    /// Input: 
    /// [
    ///  [1,2,3],
    ///  [0,0,4],
    ///  [7,6,5]
    /// ]
    /// Output: 6
    /// Example 2:
    /// Input: 
    /// [
    ///  [1,2,3],
    ///  [0,0,0],
    ///  [7,6,5]
    /// ]
    /// Output: -1
    /// Example 3:
    ///I nput: 
    /// [
    ///  [2,3,4],
    ///  [0,0,5],
    ///  [8,7,6]
    /// ]
    /// Output: 6
    /// Explanation: You started from the point (0,0) and you can cut off the tree in (0,0) directly without walking.
    /// </summary>
    public class CutOffTreesForGolfEvent
    {
        /// <summary>
        /// Note: This solution in C# results in TLE in LeetCode. However, the approach is correct.
        /// Store the location of each tree in a dictionary and sort by the height of the tree (or use priority queue)
        /// Calculate the minimum distance to travel between each two trees using BFS. If we can get to any of the trees, return -1
        /// Sum all the distances and return
        /// </summary>
        /// <param name="forest">the forest 2D array</param>
        /// <returns>the minimum steps needed to cut off all the trees</returns>
        public int CutOffTree(IList<IList<int>> forest)
        {
            Dictionary<int, int[]> treeCoordinates = new Dictionary<int, int[]>();
            for (int i = 0; i < forest.Count; i++)
            {
                for (int j = 0; j < forest[0].Count; j++)
                {
                    if (forest[i][j] > 1)
                    {
                        treeCoordinates[forest[i][j]] = new int[2] { i, j };
                    }
                }
            }

            treeCoordinates = treeCoordinates.OrderBy(tc => tc.Key).Select((tc, i) => new { Index = i, Value = tc.Value }).ToDictionary(tc => tc.Index, tc => tc.Value);

            int sumDistance = 0;
            int currentRow = 0, currentColumn = 0;
            for (int i = 0; i < treeCoordinates.Count; i++)
            {
                int distance = this.GetDistance(forest, currentRow, currentColumn, treeCoordinates[i][0], treeCoordinates[i][1]);
                //int distance = this.HadLocks(forest, currentRow, currentColumn, treeCoordinates[i][0], treeCoordinates[i][1]);
                if (distance < 0)
                {
                    return -1;
                }

                sumDistance += distance;
                forest[treeCoordinates[i][0]][treeCoordinates[i][1]] = 1;
                currentRow = treeCoordinates[i][0];
                currentColumn = treeCoordinates[i][1];
            }

            return sumDistance;
        }

        private int GetDistance(IList<IList<int>> forest, int startRow, int startColumn, int endRow, int endColumn)
        {
            Queue<int[]> queue = new Queue<int[]>();
            bool[,] visited = new bool[forest.Count, forest[0].Count];
            int[][] directions = new int[4][]
            {
                new int[] {1 , 0},
                new int[] {-1 , 0},
                new int[] {0 , 1},
                new int[] {0 , -1}
            };
            queue.Enqueue(new int[] { startRow, startColumn, 0 });

            while (queue.Any())
            {
                int[] pos = queue.Dequeue();
                int row = pos[0], column = pos[1], distance = pos[2];

                foreach (int[] direction in directions)
                {
                    int newRow = row + direction[0];
                    int newColumn = column + direction[1];
                    int newDistance = distance + 1;

                    if (newRow >= 0 && newRow < forest.Count && newColumn >= 0 && newColumn < forest[0].Count && !visited[newRow, newColumn])
                    {
                        if (newRow == endRow && newColumn == endColumn)
                        {
                            return newDistance;
                        }

                        if (forest[newRow][newColumn] >= 1)
                        {
                            queue.Enqueue(new int[] { newRow, newColumn, newDistance });
                        }
                    }
                }

                visited[row, column] = true;
            }

            return -1;
        }

        //public int HadLocks(IList<IList<int>> forest, int startRow, int startColumn, int endRow, int endColumn)
        //{
        //    int rowCount = forest.Count, columnCount = forest[0].Count;
        //    int[][] directions = new int[4][]
        //    {
        //        new int[] {-1 , 0},
        //        new int[] {1 , 0},
        //        new int[] {0 , -1},
        //        new int[] {0 , 1}
        //    };
        //    HashSet<int> processed = new HashSet<int>();
        //    LinkedList<int[]> linkedList = new LinkedList<int[]>();
        //    linkedList.AddFirst(new int[] { 0, startRow, startColumn });
        //    while (linkedList.Any())
        //    {
        //        int[] cur = linkedList.First();
        //        linkedList.RemoveFirst();
        //        int detours = cur[0], row = cur[1], column = cur[2];
        //        if (!processed.Contains(row * columnCount + column))
        //        {
        //            processed.Add(row * columnCount + column);
        //            if (row == endRow && column == endColumn)
        //            {
        //                return Math.Abs(startRow - endRow) + Math.Abs(startColumn - endColumn) + 2 * detours;
        //            }
        //            for (int di = 0; di < 4; ++di)
        //            {
        //                int nr = row + directions[di][0];
        //                int nc = column + directions[di][1];
        //                bool closer;
        //                if (di <= 1) closer = di == 0 ? row > endRow : row < endRow;
        //                else closer = di == 2 ? column > endColumn : column < endColumn;
        //                if (0 <= nr && nr < rowCount && 0 <= nc && nc < columnCount && forest[nr][nc] > 0)
        //                {
        //                    if (closer) linkedList.AddFirst(new int[] { detours, nr, nc });
        //                    else linkedList.AddLast(new int[] { detours + 1, nr, nc });
        //                }
        //            }
        //        }
        //    }
        //    return -1;
        //}
    }
}
