using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LargestBSTSubtree_NS;

namespace LargestBSTSubtree_NS
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
    /// 333. Largest BST Subtree
    /// Given a binary tree, find the largest subtree which is a Binary Search Tree (BST), where largest means subtree with largest number of nodes in it.
    /// Note:
    /// A subtree must include all of its descendants.
    /// Example:
    /// Input: [10,5,15,1,8,null,7]
    ///    10 
    ///    / \ 
    ///   5  15 
    ///  / \   \ 
    /// 1   8   7
    /// Output: 3
    /// Explanation: The Largest BST Subtree in this case is the highlighted one.
    ///             The return value is the subtree's size, which is 3.
    /// </summary>
    public class LargestBSTSubtreeProblem
    {
        private int max = 0;

        public int LargestBSTSubtree(TreeNode root)
        {
            this.Find(root);
            return max;
        }

        /// <summary>
        /// Find the largest binary search tree from the node
        /// </summary>
        /// <param name="node">the tree node</param>
        /// <returns>an integer array of length 3. The first num indicates if the tree is a valid BST(1) or not(-1), the second num is the least value in the tree, the third num is the largest value in the tree. </returns>
        public int[] Find(TreeNode node)
        {
            if (node == null)
            {
                return null;
            }

            int[] left = Find(node.left);
            int[] right = Find(node.right);

            if (left == null && right == null)
            {
                // If there's no left or right subtree, this is a valid BST, the min and max value are both node.val
                max = Math.Max(max, 1);
                return new int[3] { 1, node.val, node.val };
            }
            else if (left == null)
            {
                // If there's no left subtree, this is a valid BST only if the right subtree is a valid BST, and node.val is less than the least value in the right subtree
                if (right[0] != -1 && right[1] > node.val)
                {
                    int count = 1 + right[0];
                    max = Math.Max(max, count);
                    return new int[3] { count, node.val, right[2] };
                }

                return new int[3] { -1, 0, 0 };
            }
            else if (right == null)
            {
                // If there's no right subtree, this is a valid BST only if the left subtree is a valid BST, and node.val is greater than the largest value in the left subtree
                if (left[0] != -1 && left[2] < node.val)
                {
                    int count = 1 + left[0];
                    max = Math.Max(max, count);
                    return new int[3] { count, left[1], node.val };
                }

                return new int[3] { -1, 0, 0 };
            }
            else
            {
                //// If there's left and right subtree, this is a valid BST only if 
                //// 1)the left subtree is a valid BST, 
                //// 2)the right subtree is a valid subtree, 
                //// 3)node.val is greater that the largest value in the left subtree, 
                //// 4)and node.val is smaller than the largest value in the right subtree
                if ((left[0] != -1) && (right[0] != -1) && (node.val > left[2]) && (node.val < right[1]))
                {
                    int count = 1 + left[0] + right[0];
                    max = Math.Max(max, count);
                    return new int[3] { count, left[1], right[2] };
                }

                return new int[3] { -1, 0, 0 };
            }
        }
    }
}
