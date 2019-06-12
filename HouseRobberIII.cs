using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HouseRobberIII_NC;

namespace HouseRobberIII_NC
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
    /// 337. House Robber III
    /// The thief has found himself a new place for his thievery again. There is only one entrance to this area, called the "root." Besides the root, each house has one and only one parent house. After a tour, the smart thief realized that "all houses in this place forms a binary tree". It will automatically contact the police if two directly-linked houses were broken into on the same night.
    /// Determine the maximum amount of money the thief can rob tonight without alerting the police.
    /// Example 1:
    /// Input: [3,2,3,null,3,null,1]
    ///      3
    ///     / \
    ///    2   3
    ///     \   \ 
    ///      3   1
    /// Output: 7 
    /// Explanation: Maximum amount of money the thief can rob = 3 + 3 + 1 = 7.
    /// Example 2:
    /// Input: [3,4,5,1,3,null,1]
    ///      3
    ///     / \
    ///    4   5
    ///   / \   \ 
    ///  1   3   1
    /// Output: 9
    /// Explanation: Maximum amount of money the thief can rob = 4 + 5 = 9.
    /// </summary>
    public class HouseRobberIII
    {
        public int Rob(TreeNode root)
        {
            int[] result = FindMaximumRobMoney(root);
            return Math.Max(result[0], result[1]);
        }

        private int[] FindMaximumRobMoney(TreeNode node)
        {
            if (node == null)
            {
                return new int[2] { 0, 0 };
            }

            int[] leftMax = FindMaximumRobMoney(node.left);
            int[] rightMax = FindMaximumRobMoney(node.right);

            int[] result = new int[2];

            // If the thief does not rob this house (node), the maximum he/she can get is the maximum of the left and right sub tree
            result[0] = Math.Max(leftMax[0], leftMax[1]) + Math.Max(rightMax[0], rightMax[1]);

            // If the thief rob this house (node), he/she cannot rob the left and right child node.
            result[1] = node.val + leftMax[0] + rightMax[0];

            return result;
        }
    }
}
