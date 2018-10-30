using System;

namespace LeetCode_CSharp
{
    /// <summary>
    /// Given an integer array nums, find the contiguous subarray within an array (containing at least one number) which has the largest product
    /// </summary>
    public class MaximumProductSubarray
    {
        /// <summary>
        /// Find the max product of a given int array
        /// </summary>
        /// <returns>the max product</returns>
        /// <param name="nums">the int array</param>
        public int MaxProduct(int[] nums)
        {
            if (nums == null || nums.Length == 0)
            {
                return 0;
            }

            //// Initialize the max and min product so far with the first element in the array
            int prevMax = nums[0];
            int prevMin = nums[0];
            int globalMax = prevMax;

            for (int i = 1; i < nums.Length; i++)
            {
                int current = nums[i];
                //// The updated max product can be previous max product(positive) times the current int value(positive), 
                //// or previous min product(negative) times current int value(negative)
                int currentMax = Math.Max(Math.Max(prevMax * current, prevMin * current), current);
                int currentMin = Math.Min(Math.Min(prevMax * current, prevMin * current), current);
                globalMax = Math.Max(currentMax, globalMax);

                prevMax = currentMax;
                prevMin = currentMin;
            }

            return globalMax;
        }
    }
}
