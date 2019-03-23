using System;
using System.Collections.Generic;

namespace LeetCode_CSharp
{
    /// <summary>
    /// Given an array of integers where 1 ≤ a[i] ≤ n (n = size of array), some elements appear twice and others appear once.
    /// Find all the elements of[1, n] inclusive that do not appear in this array.
    /// Could you do it without extra space and in O(n) runtime? You may assume the returned list does not count as extra space.
    /// </summary>
    public class FindAllNumbersDisappearedInAnArray
    {
        /// <summary>
        /// For each number x in the array, set nums[x] to negative
        /// </summary>
        /// <param name="nums">the input nums array</param>
        /// <returns>the disappeared numbers</returns>
        public IList<int> FindDisappearedNumbers(int[] nums)
        {
            IList<int> result = new List<int>();

            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[Math.Abs(nums[i]) - 1] > 0)
                {
                    nums[Math.Abs(nums[i]) - 1] = nums[Math.Abs(nums[i]) - 1] * -1;
                }
            }

            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] > 0)
                {
                    result.Add(i + 1);
                }
            }

            return result;
        }
    }
}
