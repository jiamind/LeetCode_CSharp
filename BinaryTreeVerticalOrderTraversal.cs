using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BinaryTreeVerticalOrderTraversal;

namespace BinaryTreeVerticalOrderTraversal
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
    /// 314. Binary Tree Vertical Order Traversal
    /// Given a binary tree, return the vertical order traversal of its nodes' values. (ie, from top to bottom, column by column).
    /// If two nodes are in the same row and column, the order should be from left to right.
    /// </summary>
    public class BinaryTreeVerticalOrderTraversal
    {
        /// <summary>
        /// Idea: Level order traverse the tree starting from the root. root will have column number 0
        /// Any left node will have 1 less value in column number, any right node will have 1 more value in column number
        /// Keep track of the min and max column value as we traverse the tree
        /// Save the column and node values combination in the dictionary
        /// Add dictionary values from min to max to the result list
        /// </summary>
        /// <param name="root">the root tree node</param>
        /// <returns>the vertical order of the tree nodes</returns>
        public IList<IList<int>> VerticalOrder(TreeNode root)
        {
            List<IList<int>> result = new List<IList<int>>();
            if (root == null)
            {
                return result;
            }

            Dictionary<int, List<int>> dictionary = new Dictionary<int, List<int>>();

            Queue<TreeNode> nodeQueue = new Queue<TreeNode>();
            Queue<int> columnQueue = new Queue<int>();
            int minColumn = 0, maxColumn = 0;

            nodeQueue.Enqueue(root);
            columnQueue.Enqueue(0);

            while (nodeQueue.Any())
            {
                TreeNode node = nodeQueue.Dequeue();
                int column = columnQueue.Dequeue();
                minColumn = Math.Min(minColumn, column);
                maxColumn = Math.Max(maxColumn, column);

                if (dictionary.ContainsKey(column))
                {
                    dictionary[column].Add(node.val);
                }
                else
                {
                    dictionary[column] = new List<int>() { node.val };
                }

                if (node.left != null)
                {
                    nodeQueue.Enqueue(node.left);
                    columnQueue.Enqueue(column - 1);
                }

                if (node.right != null)
                {
                    nodeQueue.Enqueue(node.right);
                    columnQueue.Enqueue(column + 1);
                }
            }

            for (int i = minColumn; i <= maxColumn; i++)
            {
                result.Add(dictionary[i]);
            }

            return result;
        }
    }
}
