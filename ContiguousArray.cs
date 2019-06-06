using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode_CSharp
{
    /// <summary>
    /// 525. Contiguous Array
    /// Given a binary array, find the maximum length of a contiguous subarray with equal number of 0 and 1.
    /// Example 1:
    /// Input: [0,1]
    /// Output: 2
    /// Explanation: [0, 1] is the longest contiguous subarray with equal number of 0 and 1.
    /// Example 2:
    /// Input: [0,1,0]
    /// Output: 2
    /// Explanation: [0, 1] (or[1, 0]) is a longest contiguous subarray with equal number of 0 and 1.
    /// </summary>
    public class ContiguousArray
    {
        /// <summary>
        /// Change all 0s in the array to -1s and sum up all the integers in the array
        /// At any two points where the sums are identical, it means that the sum of all integers in between are 0
        /// Which means the original integers in between have equal number of 0s and 1s
        /// </summary>
        /// <param name="nums">the array of integers</param>
        /// <returns>the max length of subarray that contains equal number of 0s and 1s</returns>
        public int FindMaxLength(int[] nums)
        {
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] == 0)
                {
                    nums[i] = -1;
                }
            }

            Dictionary<int, int> dictionary = new Dictionary<int, int>();
            int sum = 0, maxLength = 0;
            dictionary[0] = -1;

            for (int i = 0; i < nums.Length; i++)
            {
                sum += nums[i];

                if (dictionary.ContainsKey(sum))
                {
                    maxLength = Math.Max(maxLength, i - dictionary[sum]);
                }
                else
                {
                    dictionary[sum] = i;
                }
            }

            return maxLength;
        }
    }
}
