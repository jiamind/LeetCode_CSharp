namespace LeetCode_CSharp
{
    /// <summary>
    /// Given an unsorted array nums, reorder it in-place such that nums[0] <= nums[1] >= nums[2] <= nums[3]...
    /// </summary>
    class WiggleSortProblem
    {
        /// <summary>
        /// Iterate through the array with step = 2, compare 3 consecutive values at a time
        /// Swap the greater value of the first two to the mid
        /// Swap the greater value of the last two to the mid
        /// </summary>
        /// <param name="nums"></param>
        public void WiggleSort(int[] nums)
        {
            for (int i = 0; i < nums.Length; i += 2)
            {
                if (i == nums.Length - 1)
                {
                    return;
                }

                if (i + 1 == nums.Length - 1)
                {
                    if (nums[i] > nums[i + 1])
                    {
                        Swap(nums, i, i + 1);
                    }

                    return;
                }

                if (nums[i] > nums[i + 1])
                {
                    Swap(nums, i, i + 1);
                }

                if (nums[i + 2] > nums[i + 1])
                {
                    Swap(nums, i + 2, i + 1);
                }
            }
        }

        /// <summary>
        /// Swap the two values in an integer array
        /// </summary>
        /// <param name="nums">the integer array</param>
        /// <param name="i">the index of the first value in the array</param>
        /// <param name="j">the index of the second value in the array</param>
        private void Swap(int[] nums, int i, int j)
        {
            int temp = nums[i];
            nums[i] = nums[j];
            nums[j] = temp;
        }
    }
}
