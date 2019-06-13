using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InOrderSuccessorInBST_NS;

namespace InOrderSuccessorInBST_NS
{
    /// <summary>
    /// 285. Inorder Successor in BST
    /// Given a binary search tree and a node in it, find the in-order successor of that node in the BST.
    /// The successor of a node p is the node with the smallest key greater than p.val.
    /// Example 1:
    /// Input: root = [2,1,3], p = 1
    /// Output: 2
    /// Explanation: 1's in-order successor node is 2. Note that both p and the return value is of TreeNode type.
    /// Example 2:
    /// Input: root = [5,3,6,2,4,null,null,1], p = 6
    /// Output: null
    /// Explanation: There is no in-order successor of the current node, so the answer is null.
    /// </summary>
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
    public class InOrderSuccessorInBST
    {
        public TreeNode InorderSuccessor(TreeNode root, TreeNode p)
        {
            TreeNode node = root;
            TreeNode successor = null;

            while (node != null)
            {
                //// If the current node value is greater than p
                //// Mark the node as it could be the last node which has value greater than p. Continue search on the left subtree
                //// Otherwise, continue search on the right subtree.
                if (p.val < node.val)
                {
                    successor = node;
                    node = node.left;
                }
                else
                {
                    node = node.right;
                }
            }

            return successor;
        }
    }
}
