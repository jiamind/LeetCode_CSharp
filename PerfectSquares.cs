using System;

namespace LeetCode_CSharp
{
    /// <summary>
    /// Given a positive integer n, find the least number of perfect square numbers (for example, 1, 4, 9, 16, ...) which sum to n.
    /// </summary>
    class PerfectSquares
    {
        /// <summary>
        /// dp[n] indicates the min number of perfect square numbers needed to sum to n
        /// dp[0] = 0
        /// dp[1] = dp[1 - 1*1] + 1 = dp[0] + 1 = 1
        /// dp[2] = dp[2 - 1*1] + 1 = dp[1] + 1 = 2
        /// dp[3] = dp[3 - 1*1] + 1 = dp[2] + 1 = 3
        /// dp[4] = Min(dp[4 - 1*1] + 1, dp[4 - 2*2] + 1)
        /// dp[n] = Min(dp[n - 1*1] + 1, dp[n - 2*2] + 1, ..., dp[n - i*i] + 1), i >= 1 && i*i <= n
        /// </summary>
        /// <param name="n">the number to sum to</param>
        /// <returns>the least number of perfect square numbers</returns>
        public int NumSquares(int n)
        {
            int[] dp = new int[n + 1];
            dp[0] = 0;
            for (int i = 1; i <= n; i++)
            {
                int min = i;
                for (int j = 1; j * j <= i; j++)
                {
                    min = Math.Min(dp[i - j * j] + 1, min);
                }

                dp[i] = min;
            }

            return dp[n];
        }

        /// <summary>
        /// LC - TLE
        /// </summary>
        /// <param name="n">the number to sum to</param>
        /// <returns>the least number of perfect square numbers</returns>
        public int NumSquares2(int n)
        {
            switch (n)
            {
                case 0:
                    return 0;
                case 1:
                    return 1;
                case 2:
                    return 2;
                case 3:
                    return 3;
                default:
                    int min = n;
                    for (int i = 1; i * i <= n; i++)
                    {
                        int result = this.NumSquares(n - i * i) + 1;
                        min = Math.Min(result, min);
                    }

                    return min;
            }
        }
    }
}
