using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConstructBinaryTreeFromPreorderAndInorderTraversal;

namespace ConstructBinaryTreeFromPreorderAndInorderTraversal
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
    /// 105. Construct Binary Tree from Preorder and Inorder Traversal
    ///Given preorder and inorder traversal of a tree, construct the binary tree.
    /// Note:
    /// You may assume that duplicates do not exist in the tree.
    /// For example, given
    /// preorder = [3, 9, 20, 15, 7]
    /// inorder = [9, 3, 15, 20, 7]
    /// Return the following binary tree:
    ///    3
    ///   / \
    ///  9  20
    ///    /  \
    ///   15   7
    /// </summary>
    public class ConstructBinaryTreeFromPreorderAndInorderTraversal
    {
        // Treat each element in the preorder list as the root (The first element in the preorder list is the root).
        // Find the index of that element in the inorder list.
        // Then everything before that index in the inorder list is the left subtree, everything after that index is the right subtree
        // Recursively build the tree
        public TreeNode BuildTree(int[] preorder, int[] inorder)
        {
            Dictionary<int, int> inOrderDictionary = new Dictionary<int, int>();

            for (int i = 0; i < inorder.Length; i++)
            {
                inOrderDictionary.Add(inorder[i], i);
            }

            return BuildTree(preorder, 0, inOrderDictionary, 0, inorder.Length - 1);
        }

        private TreeNode BuildTree(int[] preOrder, int preOrderIndex, Dictionary<int, int> inOrderDictionary, int inOrderStart, int inOrderEnd)
        {
            //// If we reach the end of the preorder list, or start scanning position in the inorder list is greater than the end position
            //// Return null
            if (preOrderIndex >= preOrder.Length || inOrderStart > inOrderEnd)
            {
                return null;
            }

            int inOrderIndex = inOrderDictionary[preOrder[preOrderIndex]];

            TreeNode node = new TreeNode(preOrder[preOrderIndex]);

            //// Link the left node. The next root node would be preOrderStart + 1
            //// The starting position in the inOrder list remains the same (scan from the beginning)
            //// The end position in the inOrder list is just before that root index we found in the inorder list
            node.left = BuildTree(preOrder, preOrderIndex + 1, inOrderDictionary, inOrderStart, inOrderIndex - 1);

            //// Link the right node. The next root node would be the current position plus the number of nodes in the left subtree ( index minus the start position in inorder list) plus one
            //// The starting position in the inorder list is just after the index
            //// The end position in th inOrder list remains the same
            node.right = BuildTree(preOrder, preOrderIndex + (inOrderIndex - inOrderStart) + 1, inOrderDictionary, inOrderIndex + 1, inOrderEnd);

            return node;
        }
    }
}
