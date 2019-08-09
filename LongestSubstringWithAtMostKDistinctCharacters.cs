using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode_CSharp
{
    /// <summary>
    /// 340. Longest Substring with At Most K Distinct Characters
    /// Given a string, find the length of the longest substring T that contains at most k distinct characters.
    /// Example 1:
    /// Input: s = "eceba", k = 2
    /// Output: 3
    /// Explanation: T is "ece" which its length is 3.
    /// Example 2:
    /// Input: s = "aa", k = 1
    /// Output: 2
    /// Explanation: T is "aa" which its length is 2.
    /// </summary>
    public class LongestSubstringWithAtMostKDistinctCharacters
    {
        public int LengthOfLongestSubstringKDistinct(string s, int k)
        {
            if (s == null)
            {
                return 0;
            }

            int startIndex = 0, endIndex = 0;
            int longest = 0;
            Dictionary<char, int> dictionary = new Dictionary<char, int>();

            while (endIndex < s.Length)
            {
                if (!dictionary.ContainsKey(s[endIndex]))
                {
                    dictionary.Add(s[endIndex], 1);
                }
                else
                {
                    dictionary[s[endIndex]]++;
                }

                if (dictionary.Count <= k)
                {
                    longest = Math.Max(longest, endIndex - startIndex + 1);
                }

                while (dictionary.Count > k)
                {
                    if (--dictionary[s[startIndex]] == 0)
                    {
                        dictionary.Remove(s[startIndex]);
                    }

                    startIndex++;
                }

                endIndex++;
            }

            return longest;
        }
    }
}
