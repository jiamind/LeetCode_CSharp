using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConstructBinaryTreeFromInOrderAndPostOrderTraversal;

namespace ConstructBinaryTreeFromInOrderAndPostOrderTraversal
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
    /// 106. Construct Binary Tree from Inorder and Postorder Traversal
    /// Given inorder and postorder traversal of a tree, construct the binary tree.
    ///Note:
    ///You may assume that duplicates do not exist in the tree.
    ///For example, given
    ///inorder = [9, 3, 15, 20, 7]
    ///postorder = [9, 15, 7, 20, 3]
    ///Return the following binary tree:
    ///    3
    ///   / \
    /// 9  20
    ///    /  \
    ///   15   7
    /// </summary>
    public class ConstructBinaryTreeFromInOrderAndPostOrderTraversal
    {
        /// <summary>
        /// Treat each element in the postorder list as the root. (The last element in the postorder list is the root)
        /// Find the index of that element in the inorder list.
        /// Then everything before that index in the inorder list is the left subtree, everything after that index is the right subtree
        /// Recursively build the tree
        /// </summary>
        /// <param name="inorder">the in order array</param>
        /// <param name="postorder">the post order array</param>
        /// <returns>the root node of the tree</returns>
        public TreeNode BuildTree(int[] inorder, int[] postorder)
        {
            Dictionary<int, int> inorderDictionary = new Dictionary<int, int>();

            for (int i = 0; i < inorder.Length; i++)
            {
                inorderDictionary.Add(inorder[i], i);
            }

            return BuildTree(postorder, postorder.Length - 1, inorderDictionary, 0, inorder.Length - 1);
        }

        private TreeNode BuildTree(int[] postOrder, int postOrderIndex, Dictionary<int, int> inOrderDictionary, int inOrderStart, int inOrderEnd)
        {
            // If we reach the beginning of the postorder list, or the starting position of inorder list is greater than the end position of inorder list
            if (postOrderIndex < 0 || inOrderStart > inOrderEnd)
            {
                return null;
            }

            int inOrderIndex = inOrderDictionary[postOrder[postOrderIndex]];

            TreeNode node = new TreeNode(postOrder[postOrderIndex]);

            //// Link the left node
            //// The starting position in the postorder list would be the current position minus the number of right sub nodes minus 1
            //// The starting position in the inorder list remains the same. The ending position is just before the index (current root in inorder list)
            node.left = BuildTree(postOrder, postOrderIndex - (inOrderEnd - inOrderIndex) - 1, inOrderDictionary, inOrderStart, inOrderIndex - 1);

            //// Link the right node
            //// The starting position in the postorder list is just before the current root in the postorder list (postorder: left -> [right] -> root)
            //// The starting position in the inorder list is just after the index (current root in the inorder list)
            //// The ending position in the inorder list remains the same
            node.right = BuildTree(postOrder, postOrderIndex - 1, inOrderDictionary, inOrderIndex + 1, inOrderEnd);

            return node;
        }
    }
}
