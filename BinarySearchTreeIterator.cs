using System;
using System.Collections.Generic;
using System.Linq;
using BinarySearchTreeIterator;

namespace BinarySearchTreeIterator
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
    /// 173. Binary Search Tree Iterator
    /// Implement an iterator over a binary search tree (BST). Your iterator will be initialized with the root node of a BST.
    /// Calling next() will return the next smallest number in the BST.
    /// </summary>
    public class BSTIterator
    {
        private Stack<TreeNode> leftNodes = new Stack<TreeNode>();

        public BSTIterator(TreeNode root)
        {
            this.PushAllLeftNodes(root);
        }

        /** @return the next smallest number */
        public int Next()
        {
            TreeNode node = leftNodes.Pop();
            this.PushAllLeftNodes(node.right);
            return node.val;
        }

        /** @return whether we have a next smallest number */
        public bool HasNext()
        {
            return leftNodes.Any();
        }

        /// <summary>
        /// Push all the left node to the stack recursively starting from the given node
        /// </summary>
        /// <param name="node">the starting node</param>
        private void PushAllLeftNodes(TreeNode node)
        {
            TreeNode temp = node;
            while (temp != null)
            {
                leftNodes.Push(temp);
                temp = temp.left;
            }
        }
    }
}
