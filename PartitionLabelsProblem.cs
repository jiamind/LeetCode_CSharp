using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode_CSharp
{
    /// <summary>
    /// 763. Partition Labels
    /// A string S of lowercase letters is given. We want to partition this string into as many parts as possible so that each letter appears in at most one part, and return a list of integers representing the size of these parts.
    /// Example 1:
    /// Input: S = "ababcbacadefegdehijhklij"
    /// Output: [9,7,8]
    /// Explanation:
    /// The partition is "ababcbaca", "defegde", "hijhklij".
    /// This is a partition so that each letter appears in at most one part.
    /// A partition like "ababcbacadefegde", "hijhklij" is incorrect, because it splits S into less parts.
    /// </summary>
    public class PartitionLabelsProblem
    {
        public IList<int> PartitionLabels(string S)
        {
            int[] lastSeen = new int[26];

            //// Store the last index of each character
            for (int i = 0; i < S.Length; i++)
            {
                lastSeen[S[i] - 'a'] = i;
            }

            List<int> result = new List<int>();

            int startIndex = 0, furthestIndex = 0;

            //// Scan the string from the left
            //// To partition a string, the partition should cover all the last seen characters of the characters scanned so far.
            for (int i = 0; i < S.Length; i++)
            {
                furthestIndex = Math.Max(furthestIndex, lastSeen[S[i] - 'a']);

                if (i >= furthestIndex)
                {
                    result.Add(furthestIndex - startIndex + 1);
                    startIndex = furthestIndex + 1;
                }
            }

            return result;
        }
    }
}
