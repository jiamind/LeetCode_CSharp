using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode_CSharp
{
    /// <summary>
    /// 72. Edit Distance
    /// Given two words word1 and word2, find the minimum number of operations required to convert word1 to word2.
    /// You have the following 3 operations permitted on a word:
    /// Insert a character
    /// Delete a character
    /// Replace a character
    /// Example 1:
    /// Input: word1 = "horse", word2 = "ros"
    /// Output: 3
    /// Explanation: 
    /// horse -> rorse(replace 'h' with 'r')
    /// rorse -> rose(remove 'r')
    /// rose -> ros(remove 'e')
    /// </summary>
    public class EditDistance
    {
        public int MinDistance(string word1, string word2)
        {
            char[] array1 = word1.ToCharArray();
            char[] array2 = word2.ToCharArray();

            //// Create a 2D dynamic programming array to store the minimum edit distance at each i, j comparison (i, j are index in word1 and word2)
            ////   w1 012345678
            //// w2  |---------> 
            ////    0|012345678
            ////    1|1++++++++ 
            ////    2|2++++++++
            ////    3|3++++++++
            ////    4|4++++++++
            ////    5|5++++++++
            ////    6|6++++++++
            int[,] dp = new int[array1.Length + 1, array2.Length + 1];

            //// When word2 is empty, we have to delete every character in word1 to get word2
            //// It takes word1.Length steps (edit distance)
            for (int i = 0; i < array1.Length + 1; i++)
            {
                dp[i, 0] = i;
            }

            //// When word1 is empty, we have to insert every character in word2 to get word2
            //// It takes word2.Length steps (edit distance)
            for (int i = 0; i < array2.Length + 1; i++)
            {
                dp[0, i] = i;
            }

            for (int w2Index = 1; w2Index < array2.Length + 1; w2Index++)
            {
                for (int w1Index = 1; w1Index < array1.Length + 1; w1Index++)
                {
                    //// If the current character w1Index, w2Index in word1 and word2 are the same, then we don't need to edit the current characters
                    //// The edit distances remains the same as without them
                    //// Otherwise, there are three ways to edit word1
                    //// 1) replace the character at w1Index in word1 with the character at w2Index in word2 (1 edit distance), plus whatever the edit distance is for word1 and word2 without the characters at the w1Index and w2Index
                    //// 2) delete the charater at w1Index in word1 (1 edit distance), plus whatever the edit distance is for word1 without the character at w1Index and word2
                    //// 3) insert the same character in word2 as it is at w1Index in word1 (1 edit distance), plus whatever the edit distance is for word1 and word2 without the character at w2Index
                    if (array1[w1Index - 1] == array2[w2Index - 1])
                    {
                        dp[w1Index, w2Index] = dp[w1Index - 1, w2Index - 1];
                    }
                    else
                    {
                        dp[w1Index, w2Index] = Math.Min(Math.Min(dp[w1Index - 1, w2Index - 1], dp[w1Index, w2Index - 1]), dp[w1Index - 1, w2Index]) + 1;
                    }
                }
            }

            return dp[array1.Length, array2.Length];
        }
    }
}
