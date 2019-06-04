using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClosestBinarySearchTreeValue;

namespace ClosestBinarySearchTreeValue
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
    /// 270. Closest Binary Search Tree Value
    /// Given a non-empty binary search tree and a target value, find the value in the BST that is closest to the target.
    /// Note:
    /// Given target value is a floating point.
    /// You are guaranteed to have only one unique value in the BST that is closest to the target.
    /// </summary>
    public class ClosestBinarySearchTreeValue
    {
        public int ClosestValue(TreeNode root, double target)
        {
            int closest = root.val;
            TreeNode node = root;

            while (node != null)
            {
                if (Math.Abs(node.val - target) < Math.Abs(closest - target))
                {
                    closest = node.val;
                }

                node = target > node.val ? node.right : node.left;
            }

            return closest;
        }
    }
}
