using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode_CSharp
{
    /// <summary>
    /// 47. Permutations II
    /// Given a collection of numbers that might contain duplicates, return all possible unique permutations.
    /// Example:
    /// Input: [1,1,2]
    /// Output:
    /// [
    ///   [1,1,2],
    ///   [1,2,1],
    ///   [2,1,1]
    /// ]
    /// </summary>
    public class PermutationII
    {
        public List<IList<int>> permuteUnique(int[] nums)
        {
            // Create an empty result
            List<IList<int>> result = new List<IList<int>>();
            // If nums is null or the length of nums is 0, return the empty result
            if (nums == null || nums.Length == 0) return result;
            Array.Sort(nums);
            // Call recursive backtrack
            Backtrack(nums, result, new List<int>(), new bool[nums.Length]);
            return result;
        }

        public static void Backtrack(int[] nums, List<IList<int>> result, List<int> list, bool[] used)
        {
            // If the list size equals the length of nums, it means we have all the numbers in the list
            // Add a copy of the list to the result list (Since we will remove the last element from the list later)
            if (list.Count() == nums.Length)
            {
                result.Add(new List<int>(list));
                return;
            }
            // Iterate through the nums
            for (int i = 0; i < nums.Length; i++)
            {
                // If the number is already used, or it's same as the previous number and we use the previous number in the previous iteration (e.g. the previous number is not used yet in this iteration), skip it
                if (used[i] || i > 0 && nums[i] == nums[i - 1] && !used[i - 1]) continue;
                // Add the number to the list
                list.Add(nums[i]);
                // Mark the number as used
                used[i] = true;
                // Call recursive backtrack
                Backtrack(nums, result, list, used);
                // Remove the last element (we just added) from the list
                list.Remove(list.Count() - 1);
                // Mark that number as not used
                used[i] = false;
            }
        }
    }
}
