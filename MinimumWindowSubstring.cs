using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode_CSharp
{
    /// <summary>
    /// 76. Minimum Window Substring
    /// Given a string S and a string T, find the minimum window in S which will contain all the characters in T in complexity O(n).
    /// Example:
    /// Input: S = "ADOBECODEBANC", T = "ABC"
    /// Output: "BANC"
    /// Note:
    /// If there is no such window in S that covers all characters in T, return the empty string "".
    /// If there is such window, you are guaranteed that there will always be only one unique minimum window in S.
    /// </summary>
    public class MinimumWindowSubstring
    {
        public string MinWindow(string s, string t)
        {
            // Store each character in the string t and the number of times it appears in string t
            Dictionary<char, int> charCountDictionary = new Dictionary<char, int>();
            foreach (char c in t)
            {
                if (!charCountDictionary.ContainsKey(c))
                {
                    charCountDictionary.Add(c, 0);
                }

                charCountDictionary[c]++;
            }

            int count = t.Length;
            int minLength = s.Length;
            int leftIndex = -1;
            int left = 0, right = 0;

            while (right < s.Length)
            {
                if (charCountDictionary.ContainsKey(s[right]))
                {
                    if (charCountDictionary[s[right]]-- > 0)
                    {
                        count--;
                    }

                    while (count == 0)
                    {
                        while (!charCountDictionary.ContainsKey(s[left]))
                        {
                            left++;
                        }

                        if (right - left + 1 <= minLength)
                        {
                            minLength = right - left + 1;
                            leftIndex = left;
                        }

                        if (++charCountDictionary[s[left]] > 0)
                        {
                            count++;
                        }

                        left++;
                    }
                }

                right++;
            }

            return leftIndex == -1 ? string.Empty : s.Substring(leftIndex, minLength);
        }
    }
}
