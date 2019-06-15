using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode_CSharp
{
    /// <summary>
    /// 300. Longest Increasing Subsequence
    /// Given an unsorted array of integers, find the length of longest increasing subsequence.
    /// Example:
    /// Input: [10,9,2,5,3,7,101,18]
    /// Output: 4 
    /// Explanation: The longest increasing subsequence is [2,3,7,101], therefore the length is 4. 
    /// </summary>
    public class LongestIncresingSubsequence
    {
        public int LengthOfLIS(int[] nums)
        {
            //// Use a dp array to store numbers in ascending order while iterating through each number in the nums array
            //// Use binary search on the dp array to put the number in its right position.
            //// A smaller number will replace the larger number at the same index, so that potentially we can fit in more numbers in dp array
            //// The length of the dp array grows only when we scan to the largest number so far, and the length of the dp array is the same as the length of the longest increasing subsequence
            //// Note: dp array is NOT the longest increasing subsequence
            int[] dp = new int[nums.Length];

            int len = 0;

            foreach (int num in nums)
            {
                //// The index of the specified value in the specified array, if value is found; 
                //// otherwise, a negative number. 
                //// If value is not found and value is less than one or more elements in array, the negative number returned is the bitwise complement of the index of the first element that is larger than value. 
                //// If value is not found and value is greater than all elements in array, the negative number returned is the bitwise complement of (the index of the last element plus 1). 
                //// If this method is called with a non-sorted array, the return value can be incorrect and a negative number could be returned, even if value is present in array.
                int index = Array.BinarySearch(dp, 0, len, num);
                if (index < 0)
                {
                    index = ~index;
                }

                dp[index] = num;
                if (index == len)
                {
                    len++;
                }
            }

            return len;
        }
    }
}
