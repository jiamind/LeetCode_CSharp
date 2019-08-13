using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode_CSharp
{
    /// <summary>
    /// 540. Single Element in a Sorted Array
    /// Given a sorted array consisting of only integers where every element appears exactly twice except for one element which appears exactly once. Find this single element that appears only once.
    /// Example 1:
    /// Input: [1,1,2,3,3,4,4,8,8]
    /// Output: 2
    /// Example 2:
    /// Input: [3,3,7,7,10,11,11]
    /// Output: 10
    /// </summary>
    public class SingleElementInASortedArray
    {
        public int SingleNonDuplicate(int[] nums)
        {
            int left = 0, right = nums.Length - 1;
            while (left < right)
            {
                int mid = left + (right - left) / 2;

                if (mid % 2 == 1)
                {
                    mid--;
                }

                if (nums[mid] != nums[mid + 1])
                {
                    right = mid;
                }
                else
                {
                    left = mid + 2;
                }
            }

            // Or nums[right]
            return nums[left];
        }
    }
}
