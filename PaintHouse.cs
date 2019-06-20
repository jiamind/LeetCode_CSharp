using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode_CSharp
{
    /// <summary>
    /// 256. Paint House
    /// There are a row of n houses, each house can be painted with one of the three colors: red, blue or green. The cost of painting each house with a certain color is different. You have to paint all the houses such that no two adjacent houses have the same color.
    /// The cost of painting each house with a certain color is represented by a n x 3 cost matrix.For example, costs[0][0] is the cost of painting house 0 with color red; costs[1][2] is the cost of painting house 1 with color green, and so on... Find the minimum cost to paint all houses.
    /// Note:
    /// All costs are positive integers.
    ///    Example:
    ///    Input: [[17,2,17], [16,16,5], [14,3,19]]
    /// Output: 10
    /// Explanation: Paint house 0 into blue, paint house 1 into green, paint house 2 into blue.
    ///              Minimum cost: 2 + 5 + 3 = 10.
    /// </summary>
    public class PaintHouse
    {
        public int MinCost(int[][] costs)
        {
            if (costs == null || costs.Length == 0 || costs[0].Length == 0)
            {
                return 0;
            }

            /// Store the total minimum costs of painting all previous houses and the current house with the chosen color
            int[][] totalCosts = new int[costs.Length][];

            totalCosts[0] = costs[0];

            for (int i = 1; i < totalCosts.Length; i++)
            {
                int[] cost = new int[3];
                cost[0] = Math.Min(totalCosts[i - 1][1], totalCosts[i - 1][2]) + costs[i][0];
                cost[1] = Math.Min(totalCosts[i - 1][0], totalCosts[i - 1][2]) + costs[i][1];
                cost[2] = Math.Min(totalCosts[i - 1][0], totalCosts[i - 1][1]) + costs[i][2];
                totalCosts[i] = cost;
            }

            return Math.Min(Math.Min(totalCosts[totalCosts.Length - 1][0], totalCosts[totalCosts.Length - 1][1]), totalCosts[totalCosts.Length - 1][2]);
        }
    }
}
