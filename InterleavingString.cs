using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode_CSharp
{
    /// <summary>
    /// Given s1, s2, s3, find whether s3 is formed by the interleaving of s1 and s2.
    /// Example 1:
    /// Input: s1 = "aabcc", s2 = "dbbca", s3 = "aadbbcbcac"
    /// Output: true
    /// Example 2:
    /// Input: s1 = "aabcc", s2 = "dbbca", s3 = "aadbbbaccc"
    /// Output: false
    /// </summary>
    public class InterleavingString
    {
        public bool IsInterleave(string s1, string s2, string s3)
        {
            if (s1.Length + s2.Length != s3.Length)
            {
                return false;
            }

            //// Create a 2D dynamic program array
            //// The value of dp[i][j] indicates whether s1 till position i and s2 till position j so far is interleaving.
            //// i+j is the position in s3
            bool[,] dp = new bool[s1.Length + 1, s2.Length + 1];

            dp[0, 0] = true;

            //// If there is no character in s2, s3 till the previous character needs to be interleaving
            //// and the current character in s1 needs to be the same as the current character in s3
            //// in order to say s3 till the current position is interleaving
            for (int i = 1; i < s1.Length + 1; i++)
            {
                dp[i, 0] = dp[i - 1, 0] && (s1[i - 1] == s3[i - 1]);
            }

            //// If there is no character in s1, s3 till the previous character needs to be interleaving
            //// and the current character in s2 needs to be the same as the current character in s3,
            //// in order to say s3 till at the current position is interleaving
            for (int i = 1; i < s2.Length + 1; i++)
            {
                dp[0, i] = dp[0, i - 1] && (s2[i - 1] == s3[i - 1]);
            }

            for (int s2Index = 1; s2Index < s2.Length + 1; s2Index++)
            {
                for (int s1Index = 1; s1Index < s1.Length + 1; s1Index++)
                {
                    //// If both s1 and s2 has characters, this position would either come from previous character in s1 or s2
                    //// If it comes from previous s1, dp[i-1][j] should be interleaving (true) and the current character in s1 should be the same as s3,
                    //// Or, if it comes from previous s2, dp[i][j-1] should be interleaving (true) and the current character in s2 should be the same as s3,
                    //// in order to say s3 till the current position is interleaving
                    dp[s1Index, s2Index] = ((s1[s1Index - 1] == s3[s1Index + s2Index - 1]) && dp[s1Index - 1, s2Index]) || ((s2[s2Index - 1] == s3[s1Index + s2Index - 1]) && dp[s1Index, s2Index - 1]);
                }
            }

            return dp[s1.Length, s2.Length];
        }
    }
}
