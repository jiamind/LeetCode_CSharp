using System;
using CountCompleteTreeNodes;

namespace CountCompleteTreeNodes
{
    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int x)
        {
            val = x;
        }
    }
}

namespace LeetCode_CSharp
{
    /// <summary>
    /// 222. Count Complete Tree Nodes
    /// Given a complete binary tree, count the number of nodes.
    /// Note:
    /// Definition of a complete binary tree from Wikipedia:
    /// In a complete binary tree every level, except possibly the last, is completely filled, 
    /// and all nodes in the last level are as far left as possible.
    /// It can have between 1 and 2h nodes inclusive at the last level h.
    /// </summary>
    public class CountCompleteTreeNodes
    {
        public int CountNodes(TreeNode root)
        {
            if (root == null)
            {
                return 0;
            }

            int leftHeight = GetHeight(root.left);
            int rightHeight = GetHeight(root.right);

            // If the height of the left tree is equal to the height of the right tree
            // It means that the last node is in the right tree
            // Otherwise, it means the last node is in the left tree
            if (leftHeight == rightHeight)
            {
                // Sum the nodes in the left tree and recursively call on the right tree
                return (1 << leftHeight) + CountNodes(root.right);
            }
            else
            {
                // Sum the nodes in the right tree and recursively call on the left tree
                return (1 << rightHeight) + CountNodes(root.left);
            }
        }

        /// <summary>
        /// Get the height of the tree by counting the height of the left tree
        /// </summary>
        /// <returns>The height.</returns>
        /// <param name="root">Tree Root Node</param>
        private int GetHeight(TreeNode root)
        {
            if (root == null)
            {
                return 0;
            }

            return 1 + GetHeight(root.left);
        }
    }
}
