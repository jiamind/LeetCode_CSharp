using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode_CSharp
{
    /// <summary>
    /// 261. Graph Valid Tree
    /// Given n nodes labeled from 0 to n-1 and a list of undirected edges (each edge is a pair of nodes), write a function to check whether these edges make up a valid tree.
    /// Example 1:
    /// Input: n = 5, and edges = [[0, 1], [0, 2], [0, 3], [1, 4]]
    /// Output: true
    /// Example 2:
    /// Input: n = 5, and edges = [[0, 1], [1, 2], [2, 3], [1, 3], [1, 4]]
    /// Output: false
    /// </summary>
    public class GraphValidTree
    {
        /// <summary>
        /// Hint: Use union find
        /// </summary>
        /// <param name="n">the number of nodes</param>
        /// <param name="edges">the edges array</param>
        /// <returns>true if it is a valid tree. Otherwise, return false</returns>
        public bool ValidTree(int n, int[][] edges)
        {
            int[] parents = new int[n];

            for (int i = 0; i < n; i++)
            {
                parents[i] = -1;
            }

            for (int i = 0; i < edges.Length; i++)
            {
                int xParent = findParent(parents, edges[i][0]);
                int yParent = findParent(parents, edges[i][1]);

                if (xParent == yParent)
                {
                    return false;
                }

                parents[xParent] = yParent;
            }

            return edges.Length == n - 1;
        }

        /// <summary>
        /// Find the parent of n. If n has no parent, return n.
        /// </summary>
        /// <param name="parents">the parents array</param>
        /// <param name="n">the n</param>
        /// <returns>the parent of n, or n if it has no parent</returns>
        private int findParent(int[] parents, int n)
        {
            if (parents[n] == -1)
            {
                return n;
            }

            return findParent(parents, parents[n]);
        }
    }
}
