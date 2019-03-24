using System.Collections.Generic;

namespace LeetCode_CSharp
{
    /// <summary>
    /// 560. Subarray Sum Equals K
    /// Given an array of integers and an integer k, you need to find the total number of continuous subarrays whose sum equals to k.
    /// Example 1:
    /// Input:nums = [1,1,1], k = 2
    /// Output: 2
    /// Note:
    /// The length of the array is in range[1, 20, 000].
    /// The range of numbers in the array is [-1000, 1000] and the range of the integer k is [-1e7, 1e7].
    /// </summary>
    public class SubarraySumEqualsK
    {
        /// <summary>
        /// Iterate through the arrray, calculate the sum from the first number to the ith number and store it in a dictionary along with its occurence. 
        /// Find the occurrence of k = sum[j] - sum[i]
        /// </summary>
        /// <param name="nums">the input nums array</param>
        /// <param name="k">the sum</param>
        /// <returns>the total number of continuous subarrays whose sum equals to <paramref name="k"/></returns>
        public int SubarraySum(int[] nums, int k)
        {
            Dictionary<int, int> dict = new Dictionary<int, int>();
            dict.Add(0, 1);
            int sum = 0, count = 0;

            for (int i = 0; i < nums.Length; i++)
            {
                sum += nums[i];

                if (dict.ContainsKey(sum - k))
                {
                    count += dict[sum - k];
                }

                if (dict.ContainsKey(sum))
                {
                    dict[sum] += 1;
                }
                else
                {
                    dict.Add(sum, 1);
                }
            }

            return count;
        }
    }
}
