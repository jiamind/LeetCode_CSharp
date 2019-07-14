using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode_CSharp
{
    /// <summary>
    /// 325. Maximum Size Subarray Sum Equals k
    /// Given an array nums and a target value k, find the maximum length of a subarray that sums to k. If there isn't one, return 0 instead.
    ///Note:
    ///The sum of the entire nums array is guaranteed to fit within the 32-bit signed integer range.
    ///Example 1:
    ///Input: nums = [1, -1, 5, -2, 3], k = 3
    ///Output: 4 
    ///Explanation: The subarray [1, -1, 5, -2] sums to 3 and is the longest.
    ///Example 2:
    ///Input: nums = [-2, -1, 2, 1], k = 1
    ///Output: 2 
    ///Explanation: The subarray [-1, 2] sums to 1 and is the longest.
    /// </summary>
    public class MaximumSizeSubarraySumEqualsK
    {
        public int MaxSubArrayLen(int[] nums, int k)
        {
            Dictionary<int, int> sumIndex = new Dictionary<int, int>();

            int sum = 0, max = 0;

            for (int i = 0; i < nums.Length; i++)
            {
                sum += nums[i];

                if (sum == k)
                {
                    max = i + 1;
                }
                else
                {
                    if (sumIndex.ContainsKey(sum - k))
                    {
                        max = Math.Max(max, i - sumIndex[sum - k]);
                    }
                }

                if (!sumIndex.ContainsKey(sum))
                {
                    sumIndex[sum] = i;
                }
            }

            return max;
        }
    }
}
