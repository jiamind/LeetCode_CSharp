using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode_CSharp
{
    public class VerifyAnAlienDictionary
    {
        /// <summary>
        /// 953. Verifying an Alien Dictionary
        /// In an alien language, surprisingly they also use english lowercase letters, but possibly in a different order. The order of the alphabet is some permutation of lowercase letters.
        /// Given a sequence of words written in the alien language, and the order of the alphabet, return true if and only if the given words are sorted lexicographicaly in this alien language.
        /// Example 1:
        /// Input: words = ["hello", "leetcode"], order = "hlabcdefgijkmnopqrstuvwxyz"
        /// Output: true
        /// Explanation: As 'h' comes before 'l' in this language, then the sequence is sorted.
        /// Example 2:
        /// Input: words = ["word", "world", "row"], order = "worldabcefghijkmnpqstuvxyz"
        /// Output: false
        /// Explanation: As 'd' comes after 'l' in this language, then words[0] > words[1], hence the sequence is unsorted.
        /// Example 3:
        /// Input: words = ["apple", "app"], order = "abcdefghijklmnopqrstuvwxyz"
        /// Output: false
        /// Explanation: The first three characters "app" match, and the second string is shorter (in size.) According to lexicographical rules "apple" > "app", because 'l' > '∅', where '∅' is defined as the blank character which is less than any other character(More info).
        /// </summary>
        /// <param name="words">the words array</param>
        /// <param name="order">the order of the alien letters</param>
        /// <returns>true if and only if the given words are sorted lexicographicaly in this alien language. Otherwise, return false.</returns>
        public bool IsAlienSorted(string[] words, string order)
        {
            if (words == null || words.Length <= 1)
            {
                return true;
            }

            // Store the character with its index in the dictionary into the array
            int[] orderArray = new int[26];
            for (int i = 0; i < order.Length; i++)
            {
                orderArray[order[i] - 'a'] = i;
            }

            for (int i = 0; i < words.Length - 1; i++)
            {
                int j = 0;

                // Ignore all the identical characters
                while (j < Math.Min(words[i].Length, words[i + 1].Length) && words[i][j] == words[i + 1][j])
                {
                    j++;
                }

                // If we've scanned to the end of the second word, it means the first word is longer than the second word and it should come after the second word, the order of the two words is wrong.
                if (j == words[i + 1].Length)
                {
                    return false;
                }

                // If we stop at somewhere in these two words, and the character in the first word has greater index than the character in the second word, the order of the two words is wrong.
                if (j < Math.Min(words[i].Length, words[i + 1].Length) && orderArray[words[i][j] - 'a'] > orderArray[words[i + 1][j] - 'a'])
                {
                    return false;
                }
            }

            return true;
        }
    }
}
