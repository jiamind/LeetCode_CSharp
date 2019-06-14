using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlattenBinaryTreeToLinkedList_NS;

namespace FlattenBinaryTreeToLinkedList_NS
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
    /// 114. Flatten Binary Tree to Linked List
    /// Given a binary tree, flatten it to a linked list in-place.
    /// For example, given the following tree:
    ///     1
    ///    / \
    ///   2   5
    ///  / \   \
    /// 3   4   6
    /// The flattened tree should look like:
    /// 1
    ///  \
    ///   2
    ///    \
    ///     3
    ///      \
    ///       4
    ///        \
    ///         5
    ///          \
    ///           6
    /// </summary>
    public class FlattenBinaryTreeToLinkedList
    {
        public void Flatten(TreeNode root)
        {
            FlattenTree(root);
        }

        /// <summary>
        /// Flatten the tree to the right, and return the last node of the flattened tree
        /// </summary>
        /// <param name="node">the root node of the tree</param>
        /// <returns>the last node of the flattened tree</returns>
        private TreeNode FlattenTree(TreeNode node)
        {
            if (node == null)
            {
                return null;
            }

            TreeNode lastLeft = FlattenTree(node.left);
            TreeNode lastRight = FlattenTree(node.right);

            if (lastLeft == null && lastRight == null)
            {
                return node;
            }

            if (lastLeft != null)
            {
                TreeNode temp = node.right;
                node.right = node.left;
                lastLeft.right = temp;
                node.left = null;
            }

            return lastRight == null ? lastLeft : lastRight;
        }
    }
}
