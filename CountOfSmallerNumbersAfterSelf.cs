using System.Collections.Generic;

namespace LeetCode_CSharp
{
    /// <summary>
    /// You are given an integer array nums and you have to return a new counts array. 
    /// The counts array has the property where counts[i] is the number of smaller elements to the right of nums[i].
    /// Input: [5,2,6,1]
    /// Output: [2,1,1,0]
    /// </summary>
    class CountOfSmallerNumbersAfterSelf
    {
        public class Node
        {
            public int Value { get; set; }

            /// <summary>
            /// The number of integers that are to the right of the current node and smaller than the current value
            /// </summary>
            public int Count { get; set; } = 1;

            public Node Left { get; set; }

            public Node Right { get; set; }

            public Node(int value)
            {
                this.Value = value;
            }
        }

        /// <summary>
        /// Use binary search tree. Insert the numbers from the last to the beginning.
        /// </summary>
        /// <param name="nums">the array of integers</param>
        /// <returns>A 'counts' array which has the property where counts[i] is the number of smaller elements to the right of nums[i]</returns>
        public IList<int> CountSmaller(int[] nums)
        {
            List<int> result = new List<int>();

            if (nums == null || nums.Length == 0)
            {
                return result;
            }

            result.Add(0);
            if (nums.Length == 1)
            {
                return result;
            }

            Node root = new Node(nums[nums.Length - 1]);
            for (int i = nums.Length - 2; i >= 0; i--)
            {
                int count = AddNum(root, nums[i]);
                result.Add(count);
            }

            result.Reverse();
            return result;
        }

        /// <summary>
        /// Add the number to the binary search tree. Increment the count on the nodes along the path if the number is less than the parent.
        /// If the number is greater than the value of any node along the path, increment the result by the count of the node
        /// </summary>
        /// <param name="root">the root of the binary search tree</param>
        /// <param name="num">the integer to be added</param>
        /// <returns>the number of integers that are smaller to the right of the number to be added</returns>
        private int AddNum(Node root, int num)
        {
            int count = 0;
            while (true)
            {
                if (num <= root.Value)
                {
                    root.Count++;
                    if (root.Left == null)
                    {
                        root.Left = new Node(num);
                        break;
                    }

                    root = root.Left;
                }
                else
                {
                    count += root.Count;
                    if (root.Right == null)
                    {
                        root.Right = new Node(num);
                        break;
                    }

                    root = root.Right;
                }
            }

            return count;
        }
    }
}
