using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode_CSharp
{
    /// <summary>
    /// 161. One Edit Distance
    /// Given two strings s and t, determine if they are both one edit distance apart.
    /// Note: 
    /// There are 3 possiblities to satisify one edit distance apart:
    /// Insert a character into s to get t
    /// Delete a character from s to get t
    /// Replace a character of s to get t
    /// Example 1:
    /// Input: s = "ab", t = "acb"
    /// Output: true
    /// Explanation: We can insert 'c' into s to get t.
    /// Example 2:
    /// Input: s = "cab", t = "ad"
    /// Output: false
    /// Explanation: We cannot get t from s by only one step.
    /// Example 3:
    /// Input: s = "1203", t = "1213"
    /// Output: true
    /// Explanation: We can replace '0' with '1' to get t.
    /// </summary>
    public class OneEditDistance
    {
        /// <summary>
        /// Idea: Iterate through the string (with the minimum characters). If we find different characters at the same index:
        /// 1) two strings have the same length. Then we replace this character. Therefore, all other characters have to be the same in these two strings
        /// 2) s string is longer than t string. Then we delete this character in s string. Therefore, all other characters have to be the same in these two strings
        /// 3) t string is longer than s string. Then we delete this character in t string. Therefore, all ither characters have to be the same in these two strings
        /// </summary>
        /// <param name="s">the first string</param>
        /// <param name="t">the second string</param>
        /// <returns>return true if the two strings are one distance apart. Otherwise, return false.</returns>
        public bool IsOneEditDistance(string s, string t)
        {
            int minLength = Math.Min(s.Length, t.Length);
            for (int i = 0; i < minLength; i++)
            {
                if (s[i] != t[i])
                {
                    if (s.Length == t.Length)
                    {
                        return s.Substring(i + 1, s.Length - i - 1).Equals(t.Substring(i + 1, t.Length - i - 1));
                    }
                    else if (s.Length > t.Length)
                    {
                        return s.Substring(i + 1, s.Length - i - 1).Equals(t.Substring(i, t.Length - i));
                    }
                    else
                    {
                        return s.Substring(i, s.Length - i).Equals(t.Substring(i + 1, t.Length - i - 1));
                    }
                }
            }

            return Math.Abs(s.Length - t.Length) == 1;
        }
    }
}
