using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode_CSharp
{
    /// <summary>
    /// 785. Is Graph Bipartite?
    /// Given an undirected graph, return true if and only if it is bipartite.
    /// Recall that a graph is bipartite if we can split it's set of nodes into two independent subsets A and B such that every edge in the graph has one node in A and another node in B.
    /// The graph is given in the following form: graph[i] is a list of indexes j for which the edge between nodes i and j exists.Each node is an integer between 0 and graph.length - 1.  There are no self edges or parallel edges: graph[i] does not contain i, and it doesn't contain any element twice.
    /// Example 1:
    /// Input: [[1,3], [0,2], [1,3], [0,2]]
    /// Output: true
    /// Explanation: 
    /// The graph looks like this:
    /// 0----1
    /// |    |
    /// |    |
    /// 3----2
    /// We can divide the vertices into two groups: {0, 2} and {1, 3}.
    /// Example 2:
    /// Input: [[1,2,3], [0,2], [0,1,3], [0,2]]
    /// Output: false
    /// Explanation: 
    /// The graph looks like this:
    /// 0----1
    /// | \  |
    /// |  \ |
    /// 3----2
    /// We cannot find a way to divide the set of nodes into two independent subsets.
    /// </summary>
    public class IsGraphBipartite
    {
        public bool IsBipartite(int[][] graph)
        {
            // Use a int array to keep track of the color assigned to each node in the graph. Null means the node hasn't been assigned a color
            int?[] color = new int?[graph.Length];
            for (int i = 0; i < graph.Length; i++)
            {
                if (color[i] == null)
                {
                    color[i] = 0;
                }
                else
                {
                    continue;
                }

                // Use DFS to assign colors to nodes that are connected with the current node.
                Stack<int> stack = new Stack<int>();
                stack.Push(i);

                while (stack.Any())
                {
                    int n = stack.Pop();
                    foreach (int node in graph[n])
                    {
                        if (color[node] == null)
                        {
                            color[node] = color[n] ^ 1;
                            stack.Push(node);
                        }
                        else if (color[node].Value == color[n].Value)
                        {
                            return false;
                        }
                    }
                }
            }

            return true;
        }
    }
}
