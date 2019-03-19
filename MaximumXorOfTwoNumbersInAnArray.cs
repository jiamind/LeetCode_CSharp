using System;

namespace LeetCode_CSharp
{
    /// <summary>
    /// Given a non-empty array of numbers, a0, a1, a2, … , an-1, where 0 ≤ ai < 2^31.
    /// Find the maximum result of ai XOR aj, where 0 ≤ i, j<n.
    /// Could you do this in O(n) runtime?
    /// </summary>
    public class MaximumXorOfTwoNumbersInAnArray
    {
        public class Node
        {
            public int? Value { get; set; }

            public Node[] List { get; set; }

            public Node(int? value = null)
            {
                this.Value = value;
                this.List = new Node[2];
            }
        }

        /// <summary>
        /// Use Trie.
        /// Insert each num into the Trie. Then iteration through each num from most significant bit to least significant bit, find its reverse bit in trie.
        /// </summary>
        /// <param name="nums">the input number array</param>
        /// <returns></returns>
        public int FindMaximumXOR(int[] nums)
        {
            Node root = new Node();
            Node p = root;

            foreach (int num in nums)
            {
                for (int j = 0; j < 31; j++)
                {
                    int v = (num & (1 << (30 - j))) > 0 ? 1 : 0;
                    if (p.List[v] == null)
                    {
                        p.List[v] = new Node();
                    }
                    
                    p = p.List[v];
                }

                p.Value = num;
                p = root;
            }

            int max = int.MinValue;

            foreach (int num in nums)
            {
                for (int j = 0; j < 31; j++)
                {
                    int v = (num & (1 << (30 - j))) > 0 ? 0 : 1;
                    if (p.List[v] == null)
                    {
                        p = p.List[Math.Abs(v - 1)];
                    }
                    else
                    {
                        p = p.List[v];
                    }
                }

                max = Math.Max(max, num ^ p.Value.Value);
                p = root;
            }

            return max;
        }
    }
}
