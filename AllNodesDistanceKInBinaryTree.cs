using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AllNodesdistanceKInBinaryTree_NS;

namespace AllNodesdistanceKInBinaryTree_NS
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
    /// 863. All Nodes Distance K in Binary Tree
    /// We are given a binary tree (with root node root), a target node, and an integer value K.
    /// Return a list of the values of all nodes that have a distance K from the target node.The answer can be returned in any order.
    /// Example 1:
    /// Input: root = [3, 5, 1, 6, 2, 0, 8, null, null, 7, 4], target = 5, K = 2
    /// Output: [7,4,1]
    /// Explanation: 
    /// The nodes that are a distance 2 from the target node (with value 5)
    /// have values 7, 4, and 1.
    /// Note that the inputs "root" and "target" are actually TreeNodes.
    /// The descriptions of the inputs above are just serializations of these objects.
    /// </summary>
    public class AllNodesDistanceKInBinaryTree
    {
        List<int> result = new List<int>();

        public IList<int> DistanceK(TreeNode root, TreeNode target, int K)
        {
            if (root == null || target == null)
            {
                return null;
            }

            result.AddRange(NodeValuesOfDistance(target, K));
            FindNode(root, target, K);

            return result;
        }

        /// <summary>
        /// Find the target node and populate the result list with nodes that have distance K to the target node and they are not in the subtree of target node
        /// </summary>
        /// <param name="node">the root node</param>
        /// <param name="target">the target node</param>
        /// <param name="K">the distance k</param>
        /// <returns>the distance between the target node and the root node. Returns -1 if the target node is not under the root node</returns>
        private int FindNode(TreeNode node, TreeNode target, int K)
        {
            if (node == null)
            {
                return -1;
            }

            if (node.val == target.val)
            {
                return 0;
            }

            int left = FindNode(node.left, target, K);
            int right = FindNode(node.right, target, K);

            // If the target node is in the left subtree
            if (left >= 0)
            {
                // If the distance between the current node and the target node is K
                if (left + 1 == K)
                {
                    result.Add(node.val);
                }

                // If the distance between the current node and the target node is less than K, search the right subtree
                if (left + 1 < K && node.right != null)
                {
                    result.AddRange(NodeValuesOfDistance(node.right, K - left - 2));
                }

                return left + 1;
            }

            if (right >= 0)
            {
                if (right + 1 == K)
                {
                    result.Add(node.val);
                }

                if (right + 1 < K && node.left != null)
                {
                    result.AddRange(NodeValuesOfDistance(node.left, K - right - 2));
                }

                return right + 1;
            }

            return -1;
        }

        private List<int> NodeValuesOfDistance(TreeNode node, int distance)
        {
            List<int> result = new List<int>();
            if (distance == 0)
            {
                result.Add(node.val);
                return result;
            }

            Queue<Tuple<TreeNode, int>> queue = new Queue<Tuple<TreeNode, int>>();
            queue.Enqueue(new Tuple<TreeNode, int>(node, distance));

            while (queue.Any())
            {
                Tuple<TreeNode, int> tuple = queue.Dequeue();
                TreeNode currentNode = tuple.Item1;
                int currentDistance = tuple.Item2;

                if (currentDistance == 0)
                {
                    result.Add(currentNode.val);
                }
                else
                {
                    if (currentNode.left != null)
                    {
                        queue.Enqueue(new Tuple<TreeNode, int>(currentNode.left, currentDistance - 1));
                    }

                    if (currentNode.right != null)
                    {
                        queue.Enqueue(new Tuple<TreeNode, int>(currentNode.right, currentDistance - 1));
                    }
                }
            }

            return result;
        }
    }
}
