using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode_CSharp
{
    /// <summary>
    /// 1000. Minimum Cost to Merge Stones
    /// There are N piles of stones arranged in a row.  The i-th pile has stones[i] stones.
    ///A move consists of merging exactly K consecutive piles into one pile, and the cost of this move is equal to the total number of stones in these K piles.
    ///Find the minimum cost to merge all piles of stones into one pile.If it is impossible, return -1.
    ///Example 1:
    ///Input: stones = [3, 2, 4, 1], K = 2
    ///Output: 20
    ///Explanation: 
    ///We start with[3, 2, 4, 1].
    ///We merge [3, 2] for a cost of 5, and we are left with[5, 4, 1].
    ///We merge [4, 1] for a cost of 5, and we are left with[5, 5].
    ///We merge [5, 5] for a cost of 10, and we are left with[10].
    ///The total cost was 20, and this is the minimum possible.
    ///Example 2:
    ///Input: stones = [3, 2, 4, 1], K = 3
    ///Output: -1
    ///Explanation: After any merge operation, there are 2 piles left, and we can't merge anymore.  So the task is impossible.
    ///Example 3:
    ///Input: stones = [3, 5, 1, 2, 6], K = 3
    ///Output: 25
    ///Explanation: 
    ///We start with[3, 5, 1, 2, 6].
    ///We merge [5, 1, 2] for a cost of 8, and we are left with[3, 8, 6].
    ///We merge [3, 8, 6] for a cost of 17, and we are left with[17].
    ///The total cost was 25, and this is the minimum possible.
    /// </summary>
    public class MinimumCostToMergeStones
    {
        int?[,,] dp;

        public int MergeStones(int[] stones, int K)
        {
            int[] stoneCounts = new int[stones.Length + 1];
            stoneCounts[1] = stones[0];

            for (int i = 2; i < stoneCounts.Length; i++)
            {
                stoneCounts[i] = stoneCounts[i - 1] + stones[i - 1];
            }

            dp = new int?[stones.Length, stones.Length, stones.Length + 1];

            int result = Merge(0, stones.Length - 1, 1, K, stoneCounts);
            return result < Int32.MaxValue ? result : -1;
        }

        /// <summary>
        /// Cost of merging stones from index i to index j into c piles
        /// </summary>
        /// <param name="i">the starting index i</param>
        /// <param name="j">the ending index j</param>
        /// <param name="c">the number of piles</param>
        /// <param name="K">the number of consecutive piles to merge</param>
        /// <param name="stoneCounts">the sum of the number of stones to each index</param>
        /// <returns>the cost of merging stones</returns>
        private int Merge(int i, int j, int c, int K, int[] stoneCounts)
        {
            if ((j - i + 1 - c) % (K - 1) != 0)
            {
                return Int32.MaxValue;
            }

            if (i == j)
            {
                return c == 1 ? 0 : Int32.MaxValue;
            }

            if (c == 1)
            {
                return Merge(i, j, K, K, stoneCounts) + stoneCounts[j + 1] - stoneCounts[i];
            }

            if (dp[i, j, c] != null)
            {
                return dp[i, j, c].Value;
            }

            int min = Int32.MaxValue;
            for (int mid = i; mid < j; mid += (K - 1))
            {
                min = Math.Min(min, Merge(i, mid, 1, K, stoneCounts) + Merge(mid + 1, j, c - 1, K, stoneCounts));
            }

            dp[i, j, c] = min;

            return min;
        }
    }
}
