using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode_CSharp
{
    /// <summary>
    /// 115. Distinct Subsequences
    /// Given a string S and a string T, count the number of distinct subsequences of S which equals T.
    /// A subsequence of a string is a new string which is formed from the original string by deleting some(can be none) of the characters without disturbing the relative positions of the remaining characters. (ie, "ACE" is a subsequence of "ABCDE" while "AEC" is not).
    /// Example 1:
    /// Input: S = "rabbbit", T = "rabbit"
    /// Output: 3
    /// </summary>
    public class DistinctSubsequences
    {
        public int NumDistinct(string s, string t)
        {
            char[] sArray = s.ToCharArray();
            char[] tArray = t.ToCharArray();

            //// Create a dynamic programing 2D array to store the result (number of distinct subsequence so far at each index comparision)
            //// 0 in the dp means empty string, so we need array length + 1 for the array size
            int[,] dp = new int[sArray.Length + 1, tArray.Length + 1];

            //// S  0123.....j
            //// T +----------+
            //// 0 |1111111111|
            //// 1 |0         |
            //// 2 |0         |
            //// 3 |0         |
            //// . |0         |
            //// . |0         |
            //// i |0         |
            //// When t is an empty string, it is a subsequence of s, but only 1 way
            //// Therefore, mark all s positions to 1 when t is at 0
            for (int i = 0; i <= sArray.Length; i++)
            {
                dp[i, 0] = 1;
            }

            //// When s is an empty string, there is no way t is a subsequence of s
            //// Except both s and t are empty string, so dp[0][0] remains 1
            //// Mark all t positions to 0 (except the 0 position)
            for (int i = 1; i <= tArray.Length; i++)
            {
                dp[0, i] = 0;
            }

            for (int tIndex = 1; tIndex <= tArray.Length; tIndex++)
            {
                for (int sIndex = 1; sIndex <= sArray.Length; sIndex++)
                {
                    //// If the current character in s and t are not the same
                    //// (Note: sIndex and tIndex are indexes in the dp, the corresponding index in the character array is sIndex-1 and tIndex-1)
                    //// The number of subsequence remains the same as comparing the same tIndex with previous sIndex
                    //// Because we cannot use the current character in s to match with current character in t, it must be deleted
                    ////
                    //// If the current character in s and t are the same, there are two ways to deal with the current character in s: 1) ignore it (delete it) or 2) use it (match with the current character in t)
                    //// 1) The number of subsequence is the number when comparing the same t with previous s
                    //// 2) Without the current t, the number of subsequence comparing the previous s (because the current charatcer in t is matched with the current character in s, we can't use it to match any other characters in s)
                    if (sArray[sIndex - 1] != tArray[tIndex - 1])
                    {
                        dp[sIndex, tIndex] = dp[sIndex - 1, tIndex];
                    }
                    else
                    {
                        dp[sIndex, tIndex] = dp[sIndex - 1, tIndex - 1] + dp[sIndex - 1, tIndex];
                    }
                }
            }

            return dp[sArray.Length, tArray.Length];
        }
    }
}
