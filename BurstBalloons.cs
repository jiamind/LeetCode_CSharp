using System;

namespace LeetCode_CSharp
{
    /// <summary>
    /// Given n balloons, indexed from 0 to n-1. Each balloon is painted with a number on it represented by array nums. 
    /// You are asked to burst all the balloons. If the you burst balloon i you will get nums[left] * nums[i] * nums[right] coins. 
    /// Here left and right are adjacent indices of i. After the burst, the left and right then becomes adjacent.
    /// Find the maximum coins you can collect by bursting the balloons wisely.
    /// Note: You may imagine nums[-1] = nums[n] = 1. They are not real therefore you can not burst them.
    /// 0 ≤ n ≤ 500, 0 ≤ nums[i] ≤ 100
    /// </summary>
    class BurstBalloons
    {
        /// <summary>
        /// Use dynamic programming and divide and conquer
        /// Think backwards (from the last balloon to burst)
        /// </summary>
        /// <param name="nums">array of integers that represents the coins in each of the balloon</param>
        /// <returns>the max coins you can get</returns>
        public int MaxCoins(int[] nums)
        {
            // Burst any 0 value balloon first (0 value), and add value 1 to the head and tail of the array
            int[] array = new int[nums.Length + 2];
            int i = 1;
            foreach (int num in nums)
            {
                if (num > 0)
                {
                    array[i++] = num;
                }
            }

            array[0] = array[i++] = 1;
            
            // Create a 2D array to memorize the max coin we can get from balloons x + 1 to y - 1 inclusive
            // x and y are indexes of the balloons, 0 <= x < y <= nums.Length + 2
            int[,] mem = new int[i, i];

            return Burst(array, 0, i - 1, mem);
        }

        /// <summary>
        /// The max coin we can get if we burst balloons from left + 1 to right - 1 inclusive
        /// </summary>
        /// <param name="nums">array of integers that represents the coins in each of the balloon</param>
        /// <param name="left">the left to the starting balloon to burst</param>
        /// <param name="right">the right to the ending balloon to burst</param>
        /// <param name="mem">the memory</param>
        /// <returns>the max coins you can get</returns>
        private int Burst(int[] nums, int left, int right, int[,] mem)
        {
            // If no balloon, return 0
            if (left + 1 == right)
            {
                return 0;
            }

            // Direct return if it is in the memory
            if (mem[left, right] > 0)
            {
                return mem[left, right];
            }

            // Any balloon can be the last balloon to burst, we need to find the max coin we can get, hence iterate
            // Treat each balloon as the last balloon to burst
            int maxCoin = 0;
            for (int i = left + 1; i < right; i++)
            {
                maxCoin = Math.Max(maxCoin, nums[left] * nums[i] * nums[right] + Burst(nums, left, i, mem) + Burst(nums, i, right, mem));
            }

            mem[left, right] = maxCoin;

            return maxCoin;
        }
    }
}
