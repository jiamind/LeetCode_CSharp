using System;
using System.Collections.Generic;

namespace LeetCode_CSharp
{
    /// <summary>
    /// Given a list of unique words, find all pairs of distinct indices (i, j) in the given list, so that the concatenation of the two words, 
    /// i.e. words[i] + words[j] is a palindrome.
    /// Input: ["abcd","dcba","lls","s","sssll"]
    /// Output: [[0,1],[1,0],[3,2],[2,4]] 
    /// Explanation: The palindromes are["dcbaabcd", "abcddcba", "slls", "llssssll"]
    /// </summary>
    class PalindromePairsProblem
    {
        /// <summary>
        /// Iterate through all the words, store all the possible palindrome string needed for each word in a dictionary or using trie data structure
        /// </summary>
        /// <param name="words">a list of unique words</param>
        /// <returns>all pairs of distinct indices (i, j) in the given list, so that the concatenation of the two words, i.e. words[i] + words[j] is a palindrome.</returns>
        public IList<IList<int>> PalindromePairs(string[] words)
        {
            IList<IList<int>> result = new List<IList<int>>();
            Dictionary<int, HashSet<int>> resultDict = new Dictionary<int, HashSet<int>>();
            Dictionary<string, IList<int>> dictionary = new Dictionary<string, IList<int>>();

            for (int i = 0; i < words.Length; i++)
            {
                HashSet<string> front = GetFrontPalindromeSubStrings(words[i]);
                //// Use negative numbers to indicate that the string is needed before the word
                //// Use fakeIndex = i + 1 to avoid the case when i is 0 (0 * -1 = 0 * 1 = 0, we can't tell if the word is needed before words[i] or after)
                int fakeIndex = i + 1;
                foreach (string w in front)
                {
                    if (dictionary.ContainsKey(w))
                    {
                        dictionary[w].Add(fakeIndex * -1);
                    }
                    else
                    {
                        dictionary.Add(w, new List<int> { fakeIndex * -1 });
                    }
                }

                HashSet<string> back = GetBackPalindromeSubStrings(words[i]);
                foreach (string w in back)
                {
                    if (dictionary.ContainsKey(w))
                    {
                        dictionary[w].Add(fakeIndex);
                    }
                    else
                    {
                        dictionary.Add(w, new List<int> { fakeIndex });
                    }
                }
            }

            for (int i = 0; i < words.Length; i++)
            {
                if (dictionary.ContainsKey(words[i]))
                {
                    IList<int> indexes = dictionary[words[i]];
                    foreach (int index in indexes)
                    {
                        if (index - 1 == i || (index * -1) - 1 == i)
                        {
                            continue;
                        }

                        if (index < 0)
                        {
                            int realIndex = (index * -1) - 1;
                            if (resultDict.ContainsKey(i) && resultDict[i].Contains(realIndex))
                            {
                                continue;
                            }

                            if (!resultDict.ContainsKey(i))
                            {
                                resultDict.Add(i, new HashSet<int>());
                            }

                            resultDict[i].Add(realIndex);
                        }
                        else
                        {
                            int realIndex = index - 1;
                            if (resultDict.ContainsKey(realIndex) && resultDict[realIndex].Contains(i))
                            {
                                continue;
                            }

                            if (!resultDict.ContainsKey(realIndex))
                            {
                                resultDict.Add(realIndex, new HashSet<int>());
                            }

                            resultDict[realIndex].Add(i);
                        }
                    }
                }
            }

            foreach (KeyValuePair<int, HashSet<int>> pair in resultDict)
            {
                foreach (int i in pair.Value)
                {
                    result.Add(new List<int> { pair.Key, i });
                }
            }

            return result;
        }

        /// <summary>
        /// Get all the possible strings that are needed to be placed BEFORE this string in order to form a palindrome string
        /// </summary>
        /// <param name="s">the string to be checked</param>
        /// <returns>a hash set of possible strings</returns>
        public HashSet<string> GetFrontPalindromeSubStrings(string s)
        {
            HashSet<string> strings = new HashSet<string>();
            string reverse = ReverseString(s);
            strings.Add(reverse);
            strings.Add(reverse.Substring(0, reverse.Length - 1 < 0 ? 0 : (reverse.Length - 1)));
            for (int i = s.Length - 1; i >= 0; i--)
            {
                if (IsPalindromeString(s, 0, i))
                {
                    strings.Add(reverse.Substring(0, s.Length - 1 - i));
                }
            }

            return strings;
        }

        /// <summary>
        /// Get all the possible strings that are needed to be placed AFTER this string in order to form a palindrome string
        /// </summary>
        /// <param name="s">the string to be checked</param>
        /// <returns>a hash set of possible strings</returns>
        public HashSet<string> GetBackPalindromeSubStrings(string s)
        {
            HashSet<string> strings = new HashSet<string>();
            string reverse = ReverseString(s);
            strings.Add(reverse);
            strings.Add(reverse.Substring(reverse.Length < 1 ? 0 : 1, reverse.Length - 1 < 0 ? 0 : (reverse.Length - 1)));
            for (int i = 0; i < s.Length; i++)
            {
                if (IsPalindromeString(s, i, s.Length - 1))
                {
                    if (i == 0)
                    {
                        strings.Add(string.Empty);
                    }
                    else
                    {
                        strings.Add(reverse.Substring(reverse.Length - i, i));
                    }
                }
            }

            return strings;
        }

        /// <summary>
        /// Reverse the string
        /// </summary>
        /// <param name="s">the string to be reversed</param>
        /// <returns>the reversed string</returns>
        private string ReverseString(string s)
        {
            char[] arr = s.ToCharArray();
            Array.Reverse(arr);
            return new string(arr);
        }

        /// <summary>
        /// Check whether the substring from index i to j is a palindrome string
        /// </summary>
        /// <param name="s">the string to be checked</param>
        /// <param name="i">the start index to check on the string</param>
        /// <param name="j">the end index to check on the string</param>
        /// <returns>true if the substring from index i to j is a palindrome string. Otherwise return false</returns>
        private bool IsPalindromeString(string s, int i, int j)
        {
            while (j > i)
            {
                if (s[j] != s[i])
                {
                    return false;
                }

                j--;
                i++;
            }

            return true;
        }
    }
}
