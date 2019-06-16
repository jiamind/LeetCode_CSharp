using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode_CSharp
{
    /// <summary>
    /// Given a string, find the length of the longest substring without repeating characters.
    /// Example 1:
    /// Input: "abcabcbb"
    /// Output: 3 
    /// Explanation: The answer is "abc", with the length of 3. 
    /// Example 2:
    /// Input: "bbbbb"
    /// Output: 1
    /// Explanation: The answer is "b", with the length of 1.
    /// Example 3:
    /// Input: "pwwkew"
    /// Output: 3
    /// Explanation: The answer is "wke", with the length of 3. 
    ///              Note that the answer must be a substring, "pwke" is a subsequence and not a substring.
    /// </summary>
    public class LongestSubstringWithoutRepeatingCharacters
    {
        public int LengthOfLongestSubstring(string s)
        {
            // Store the character with its last seen index
            Dictionary<char, int> charIndexDict = new Dictionary<char, int>();
            int max = 0;

            // The left index of the longest substring without repeating characters
            int left = 0;

            for (int right = 0; right < s.Length; right++)
            {
                //// If we've seen this character and the last time we saw this character is within the current substring
                //// Update the max length and the start index of the substring
                if (charIndexDict.ContainsKey(s[right]) && charIndexDict[s[right]] >= left)
                {
                    max = Math.Max(max, right - left);
                    left = charIndexDict[s[right]] + 1;
                }

                charIndexDict[s[right]] = right;
            }

            return Math.Max(max, s.Length - left);
        }
    }
}
