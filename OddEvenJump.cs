using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode_CSharp
{
    /// <summary>
    /// 975 - Odd Even Jump
    /// You are given an integer array A.  From some starting index, you can make a series of jumps.  The (1st, 3rd, 5th, ...) jumps in the series are called odd numbered jumps, and the (2nd, 4th, 6th, ...) jumps in the series are called even numbered jumps.
    /// You may from index i jump forward to index j(with i < j) in the following way:
    /// During odd numbered jumps(ie.jumps 1, 3, 5, ...), you jump to the index j such that A[i] <= A[j] and A[j] is the smallest possible value.If there are multiple such indexes j, you can only jump to the smallest such index j.
    /// During even numbered jumps (ie.jumps 2, 4, 6, ...), you jump to the index j such that A[i] >= A[j] and A[j] is the largest possible value.If there are multiple such indexes j, you can only jump to the smallest such index j.
    /// (It may be the case that for some index i, there are no legal jumps.)
    /// A starting index is good if, starting from that index, you can reach the end of the array(index A.length - 1) by jumping some number of times(possibly 0 or more than once.)
    /// Return the number of good starting indexes.
    /// </summary>
    public class OddEvenJump
    {
        /// <summary>
        /// Note: This solution in c# will cause TLE in LC. Use TreeMap in Java to get O(NlogN) time complexity.
        /// higher[i] = true means the next odd move from index i can reach the end of the array. 
        /// lower[i] = true means the next even move from index i can reach the end of the array.
        /// Iterate backwards on array A, find the next higher value and next lower value of index i. Set higher[i] and lower[i] accordingly.
        /// </summary>
        /// <param name="A">the input array</param>
        /// <returns>number of possible starting indexes</returns>
        public int OddEvenJumps(int[] A)
        {
            if (A == null)
            {
                return 0;
            }

            if (A.Length == 1)
            {
                return 1;
            }

            SortedDictionary<int, int> dict = new SortedDictionary<int, int>();
            int count = 1;
            bool[] higher = new bool[A.Length];
            bool[] lower = new bool[A.Length];
            higher[A.Length - 1] = true;
            lower[A.Length - 1] = true;
            dict.Add(A[A.Length - 1], A.Length - 1);

            for (int i = A.Length - 2; i >= 0; i--)
            {
                var hi = dict.FirstOrDefault(pair => pair.Key >= A[i]);
                var low = dict.LastOrDefault(pair => pair.Key <= A[i]);
                if (!hi.Equals(default(KeyValuePair<int, int>)))
                {
                    higher[i] = lower[hi.Value];
                }

                if (!low.Equals(default(KeyValuePair<int, int>)))
                {
                    lower[i] = higher[low.Value];
                }

                if (higher[i])
                {
                    count++;
                }

                if (dict.ContainsKey(A[i]))
                {
                    // If this is a dup value, override the existing one since we only care about the smallest index for the same value.
                    dict[A[i]] = i;
                }
                else
                {
                    dict.Add(A[i], i);
                }
            }

            return count;
        }
    }
}
