namespace LeetCode_CSharp
{
    /// <summary>
    /// 463. Island Perimeter
    /// You are given a map in form of a two-dimensional integer grid where 1 represents land and 0 represents water.
    /// Grid cells are connected horizontally/vertically(not diagonally). The grid is completely surrounded by water, and there is exactly one island(i.e., one or more connected land cells).
    /// The island doesn't have "lakes" (water inside that isn't connected to the water around the island). One cell is a square with side length 1. The grid is rectangular, width and height don't exceed 100. Determine the perimeter of the island.
    /// </summary>
    public class IslandPerimeterProblem
    {
        /// <summary>
        /// Count and sum the number of neigbors of 0s that are 1.
        /// Then add the number of 1s in the top row, bottom row, left most column, and right most colum.
        /// </summary>
        /// <param name="grid">the 2d grid</param>
        /// <returns>the island perimeter</returns>
        public int IslandPerimeter(int[,] grid)
        {
            int result = 0;

            for (int i = 0; i < grid.GetLength(0); i++)
            {
                for (int j = 0; j < grid.GetLength(1); j++)
                {
                    if (grid[i, j] == 0)
                    {
                        this.CountNeighorOnes(grid, i, j, ref result);
                    }
                }
            }

            // Top and bottom
            for (int i = 0; i < grid.GetLength(1); i++)
            {
                if (grid[0,i] == 1)
                {
                    result++;
                }

                if (grid[grid.GetLength(0)-1, i] == 1)
                {
                    result++;
                }
            }

            // Left and right most
            for (int i = 0; i < grid.GetLength(0); i++)
            {
                if (grid[i, 0] == 1)
                {
                    result++;
                }

                if (grid[i,grid.GetLength(1) - 1] == 1)
                {
                    result++;
                }
            }

            return result;
        }

        /// <summary>
        /// Count the number of neighbors of 0s that are 1
        /// </summary>
        /// <param name="grid">the input grid</param>
        /// <param name="i">the row index</param>
        /// <param name="j">the column index</param>
        /// <param name="result">the count of neighbors that are 1</param>
        /// <returns></returns>
        private int CountNeighorOnes(int[,] grid, int i, int j, ref int result)
        {
            //Up
            if (j > 0 && grid[i, j - 1] == 1)
            {
                result++;
            }

            // Down
            if (j < grid.GetLength(1) - 1 && grid[i, j + 1] == 1)
            {
                result++;
            }

            // Left
            if (i > 0 && grid[i - 1, j] == 1)
            {
                result++;
            }

            // Down
            if (i < grid.GetLength(0) - 1 && grid[i + 1, j] == 1)
            {
                result++;
            }

            return result;
        }
    }
}
