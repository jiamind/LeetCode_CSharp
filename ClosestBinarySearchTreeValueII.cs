using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClosestBinarySearchTreeValueII;

namespace ClosestBinarySearchTreeValueII
{
    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int x) { val = x; }
    }
}

namespace LeetCode_CSharp
{
    /// <summary>
    /// 272. Closest Binary Search Tree Value II
    /// Given a non-empty binary search tree and a target value, find k values in the BST that are closest to the target.
    /// Note:
    /// Given target value is a floating point.
    /// You may assume k is always valid, that is: k ≤ total nodes.
    /// You are guaranteed to have only one unique set of k values in the BST that are closest to the target.
    /// </summary>
    public class ClosestBinarySearchTreeValueII
    {
        /// <summary>
        /// In-order traverse the binary search tree (so that nodes are visited in ascending order of their value)
        /// Store the values that are less than and greater than the target in two data structures (stack and queue for easy pop/dequeue)
        /// Pick the first k values that are closest to the target as we pop/dequeue the value from the stack and queue
        /// </summary>
        /// <param name="root">the root tree node</param>
        /// <param name="target">the target value</param>
        /// <param name="k">the number of values that are closest to the target</param>
        /// <returns>the list of k values that are closest to the target</returns>
        public IList<int> ClosestKValues(TreeNode root, double target, int k)
        {
            List<int> result = new List<int>();
            Stack<int> lessThanTarget = new Stack<int>();
            Queue<int> greaterThanTarget = new Queue<int>();

            Stack<TreeNode> stack = new Stack<TreeNode>();
            TreeNode currentNode = root;

            while (stack.Any() || currentNode != null)
            {
                while (currentNode != null)
                {
                    stack.Push(currentNode);
                    currentNode = currentNode.left;
                }

                currentNode = stack.Pop();

                if (currentNode.val <= target)
                {
                    lessThanTarget.Push(currentNode.val);
                }
                else
                {
                    greaterThanTarget.Enqueue(currentNode.val);
                }

                currentNode = currentNode.right;
            }

            for (int i = 0; i < k; i++)
            {
                if (!lessThanTarget.Any())
                {
                    result.Add(greaterThanTarget.Dequeue());
                }
                else if (!greaterThanTarget.Any())
                {
                    result.Add(lessThanTarget.Pop());
                }
                else
                {
                    int val1 = lessThanTarget.Peek();
                    int val2 = greaterThanTarget.Peek();

                    if ((target - val1) < (val2 - target))
                    {
                        result.Add(lessThanTarget.Pop());
                    }
                    else
                    {
                        result.Add(greaterThanTarget.Dequeue());
                    }
                }
            }

            return result;
        }
    }
}
