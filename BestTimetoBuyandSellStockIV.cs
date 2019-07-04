using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode_CSharp
{
    /// <summary>
    /// 188. Best Time to Buy and Sell Stock IV
    /// Say you have an array for which the ith element is the price of a given stock on day i.
    /// Design an algorithm to find the maximum profit.You may complete at most k transactions.
    /// Note:
    /// You may not engage in multiple transactions at the same time (ie, you must sell the stock before you buy again).
    /// Example 1:
    /// Input: [2,4,1], k = 2
    /// Output: 2
    /// Explanation: Buy on day 1 (price = 2) and sell on day 2 (price = 4), profit = 4-2 = 2.
    /// Example 2:
    /// Input: [3,2,6,5,0,3], k = 2
    /// Output: 7
    /// Explanation: Buy on day 2 (price = 2) and sell on day 3 (price = 6), profit = 6-2 = 4.
    /// Then buy on day 5 (price = 0) and sell on day 6 (price = 3), profit = 3-0 = 3.
    /// </summary>
    public class BestTimetoBuyandSellStockIV
    {
        public int MaxProfit(int k, int[] prices)
        {
            if (prices == null || prices.Length <= 1 || k <= 0)
            {
                return 0;
            }

            int maxProfit = 0;

            if (k * 2 >= prices.Length)
            {
                for (int i = 1; i < prices.Length; i++)
                {
                    if (prices[i] > prices[i - 1])
                    {
                        maxProfit += prices[i] - prices[i - 1];
                    }
                }

                return maxProfit;
            }

            // dp[i,j]: the max profit when we can make at most k transactions with stock prices range from 0 to j
            int[,] dp = new int[k + 1, prices.Length];
            for (int i = 1; i <= k; i++)
            {
                // the max total profit we made so far in history after purchase the stock 
                int lastMaxProfit = dp[i - 1, 0] - prices[0];
                for (int j = 1; j < prices.Length; j++)
                {
                    // We could either do no transaction here, or sell our stock here and try to make the max profit
                    dp[i, j] = Math.Max(dp[i, j - 1], prices[j] + lastMaxProfit);
                    lastMaxProfit = Math.Max(lastMaxProfit, dp[i - 1, j] - prices[j]);
                }
            }

            return dp[k, prices.Length - 1];
        }
    }
}
