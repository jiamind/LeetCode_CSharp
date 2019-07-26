using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoundaryOfBinaryTree_NS;

namespace BoundaryOfBinaryTree_NS
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
    /// 545. Boundary of Binary Tree
    /// Given a binary tree, return the values of its boundary in anti-clockwise direction starting from root. Boundary includes left boundary, leaves, and right boundary in order without duplicate nodes.  (The values of the nodes may still be duplicates.)
    /// Left boundary is defined as the path from root to the left-most node.Right boundary is defined as the path from root to the right-most node. If the root doesn't have left subtree or right subtree, then the root itself is left boundary or right boundary. Note this definition only applies to the input binary tree, and not applies to any subtrees.
    /// The left-most node is defined as a leaf node you could reach when you always firstly travel to the left subtree if exists.If not, travel to the right subtree.Repeat until you reach a leaf node.
    /// The right-most node is also defined by the same way with left and right exchanged.
    /// Example 1
    /// Input:
    ///  1
    ///   \
    ///    2
    ///   / \
    ///  3   4
    /// Ouput:
    /// [1, 3, 4, 2]
    /// Explanation:
    /// The root doesn't have left subtree, so the root itself is left boundary.
    /// The leaves are node 3 and 4.
    /// The right boundary are node 1,2,4. Note the anti-clockwise direction means you should output reversed right boundary.
    /// So order them in anti-clockwise without duplicates and we have [1,3,4,2].
    /// Example 2
    /// Input:
    ///        ____1_____
    ///       /          \
    ///      2            3
    ///     / \          / 
    ///     4   5        6   
    ///        / \      / \
    ///       7   8    9  10  
    /// Ouput:
    /// [1,2,4,7,8,9,10,6,3]
    /// Explanation:
    /// The left boundary are node 1,2,4. (4 is the left-most node according to definition)
    /// The leaves are node 4,7,8,9,10.
    /// The right boundary are node 1,3,6,10. (10 is the right-most node).
    /// So order them in anti-clockwise without duplicate nodes we have[1, 2, 4, 7, 8, 9, 10, 6, 3].
    /// </summary>
    public class BoundaryOfBinaryTreeProblem
    {
        List<int> leftBoundary;
        Stack<int> rightBoundary;
        List<int> leaves;

        public IList<int> BoundaryOfBinaryTree(TreeNode root)
        {
            List<int> result = new List<int>();
            if (root == null)
            {
                return result.ToList();
            }

            this.leftBoundary = new List<int>();
            this.rightBoundary = new Stack<int>();

            this.leaves = new List<int>();

            this.TraverseTree(root.left, true, false);
            this.TraverseTree(root.right, false, true);

            foreach (int nodeVal in this.leftBoundary)
            {
                result.Add(nodeVal);
            }

            for (int i = 0; i < this.leaves.Count; i++)
            {
                if (i == 0 && result.Count >= 1 && this.leaves[i] == result[result.Count - 1])
                {
                    continue;
                }

                result.Add(this.leaves[i]);
            }

            int stackCount = this.rightBoundary.Count;
            for (int i = 0; i < stackCount; i++)
            {
                int value = this.rightBoundary.Pop();
                if (i == 0 && result.Count >= 1 && value == result[result.Count - 1])
                {
                    continue;
                }

                result.Add(value);
            }

            // Insert the root to the front of the result
            result.Insert(0, root.val);
            return result;
        }

        private void TraverseTree(TreeNode node, bool isLeftBoundary, bool isRightBoundary)
        {
            if (node == null)
            {
                return;
            }

            if (isLeftBoundary)
            {
                leftBoundary.Add(node.val);
            }

            if (isRightBoundary)
            {
                rightBoundary.Push(node.val);
            }

            if (node.left == null && node.right == null)
            {
                leaves.Add(node.val);
            }
            else if (node.left == null)
            {
                this.TraverseTree(node.right, isLeftBoundary, isRightBoundary);
            }
            else if (node.right == null)
            {
                this.TraverseTree(node.left, isLeftBoundary, isRightBoundary);
            }
            else
            {
                //// This node has both left and right nodes
                //// If this node is on the left boundary, it's right node cannot be on the left boundary (it's left node is)
                //// If this node is on the right boundary, it's left node cannot be on the right boundary (it's right node is)
                this.TraverseTree(node.left, isLeftBoundary, false);
                this.TraverseTree(node.right, false, isRightBoundary);
            }
        }
    }
}
