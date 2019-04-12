using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode_CSharp
{
    /// <summary>
    /// 399 - Evaluate Division
    /// Equations are given in the format A / B = k, where A and B are variables represented as strings, and k is a real number (floating point number). Given some queries, return the answers. If the answer does not exist, return -1.0.
    /// Example:
    /// Given a / b = 2.0, b / c = 3.0. 
    /// queries are: a / c = ?, b / a = ?, a / e = ?, a / a = ?, x / x = ? . 
    /// return [6.0, 0.5, -1.0, 1.0, -1.0 ].
    /// The input is: vector<pair<string, string>> equations, vector<double>& values, vector<pair<string, string>> queries, where equations.size() == values.size(), and the values are positive.This represents the equations.Return vector<double>.
    /// </summary>
    public class EvaluateDivision
    {
        /// <summary>
        /// Treat A / B = k as a directed edge from A to B with cost k. Problem of A / X can be solved by multiply the cost of all edges on the path from A to X
        /// </summary>
        /// <param name="equations">the equation array</param>
        /// <param name="values">the values of the equation</param>
        /// <param name="queries">the query array</param>
        /// <returns>the result of the query</returns>
        public double[] CalcEquation(string[][] equations, double[] values, string[][] queries)
        {
            Dictionary<string, List<string>> edgeDict = new Dictionary<string, List<string>>();
            Dictionary<string, List<double>> costDict = new Dictionary<string, List<double>>();
            List<double> results = new List<double>();

            for (int i = 0; i < equations.GetLength(0); i++)
            {
                if (!edgeDict.ContainsKey(equations[i][0]))
                {
                    edgeDict[equations[i][0]] = new List<string>() { equations[i][1] };
                    costDict[equations[i][0]] = new List<double>() { values[i] };
                }
                else
                {
                    edgeDict[equations[i][0]].Add(equations[i][1]);
                    costDict[equations[i][0]].Add(values[i]);
                }

                if (!edgeDict.ContainsKey(equations[i][1]))
                {
                    edgeDict[equations[i][1]] = new List<string>() { equations[i][0] };
                    costDict[equations[i][1]] = new List<double>() { 1 / values[i] };
                }
                else
                {
                    edgeDict[equations[i][1]].Add(equations[i][0]);
                    costDict[equations[i][1]].Add(1 / values[i]);
                }
            }

            for (int i = 0; i < queries.GetLength(0); i++)
            {
                double result = 0;
                result = dfs(queries[i][0], queries[i][1], edgeDict, costDict, new HashSet<string>(), 1);
                if (result == 0)
                {
                    result = -1;
                }

                results.Add(result);
            }

            return results.ToArray();
        }

        public double dfs(string start, string end, Dictionary<string, List<string>> edgeDict, Dictionary<string, List<double>> costDict, HashSet<string> visited, double value)
        {
            if (visited.Contains(start))
            {
                return 0;
            }

            if (!edgeDict.ContainsKey(start))
            {
                return 0;
            }

            if (start.Equals(end))
            {
                return value;
            }

            visited.Add(start);
            List<string> nodes = edgeDict[start];
            List<double> costs = costDict[start];
            double result = 0;

            for (int i = 0; i < nodes.Count; i++)
            {
                result = dfs(nodes[i], end, edgeDict, costDict, visited, value * costs[i]);
                if (result != 0)
                {
                    break;
                }
            }

            visited.Remove(start);
            return result;
        }
    }
}
