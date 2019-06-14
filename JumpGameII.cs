using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode_CSharp
{
    /// <summary>
    /// 45. Jump Game II
    /// Given an array of non-negative integers, you are initially positioned at the first index of the array.
    /// Each element in the array represents your maximum jump length at that position.
    /// Your goal is to reach the last index in the minimum number of jumps.
    /// Example:
    /// Input: [2,3,1,1,4]
    /// Output: 2
    /// Explanation: The minimum number of jumps to reach the last index is 2.
    /// Jump 1 step from index 0 to 1, then 3 steps to the last index.
    /// </summary>
    public class JumpGameII
    {
        public int Jump(int[] nums)
        {
            if (nums == null || nums.Length <= 1)
            {
                return 0;
            }

            int minSteps = 0;

            // Last farthest reachable index by taken the current minStep
            int lastMaxReachable = 0;

            // The farthest reachable index so far from the beginning
            int maxReachable = 0;

            for (int i = 0; i < nums.Length - 1; i++)
            {
                // Update the farthest reachable index so far
                maxReachable = Math.Max(maxReachable, i + nums[i]);

                //// If the current index is the farthest index we can reach under the current minStep
                //// We will take another step so that we can reach further
                if (i == lastMaxReachable)
                {
                    lastMaxReachable = maxReachable;
                    minSteps++;
                }
            }

            return minSteps;
        }
    }
}
