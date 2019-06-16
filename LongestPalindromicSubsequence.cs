using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode_CSharp
{
    /// <summary>
    /// 516. Longest Palindromic Subsequence
    /// Given a string s, find the longest palindromic subsequence's length in s. You may assume that the maximum length of s is 1000.
    /// Example 1:
    /// Input:
    /// "bbbab"
    /// Output:
    /// 4
    /// One possible longest palindromic subsequence is "bbbb".
    /// Example 2:
    /// Input:
    /// "cbbd"
    /// Output:
    /// 2
    /// One possible longest palindromic subsequence is "bb".
    /// </summary>
    public class LongestPalindromicSubsequence
    {
        public int LongestPalindromeSubseq(string s)
        {
            int[,] dp = new int[s.Length, s.Length];

            //// Use two pointers (i,j) and iterate through the string
            //// dp[i,j] stores the longest palindrome subsequence in the substring from index i to j
            for (int j = 0; j < s.Length; j++)
            {
                dp[j, j] = 1;
                for (int i = j - 1; i >= 0; i--)
                {
                    if (s[i] == s[j])
                    {
                        // If the characters at the start and end index are the same, the new longest palindrome subsequence is the previous length without the two characters plus 2
                        dp[i, j] = dp[i + 1, j - 1] + 2;
                    }
                    else
                    {
                        dp[i, j] = Math.Max(dp[i + 1, j], dp[i, j - 1]);
                    }
                }
            }
            return dp[0, s.Length - 1];
        }
    }
}
