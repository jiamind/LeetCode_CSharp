using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode_CSharp
{
    /// <summary>
    /// 472. Concatenated Words
    /// Given a list of words (without duplicates), please write a program that returns all concatenated words in the given list of words.
    /// A concatenated word is defined as a string that is comprised entirely of at least two shorter words in the given array.
    /// Example:
    /// Input: ["cat","cats","catsdogcats","dog","dogcatsdog","hippopotamuses","rat","ratcatdogcat"]
    /// Output: ["catsdogcats","dogcatsdog","ratcatdogcat"]
    /// Explanation: "catsdogcats" can be concatenated by "cats", "dog" and "cats"; 
    /// "dogcatsdog" can be concatenated by "dog", "cats" and "dog"; 
    /// "ratcatdogcat" can be concatenated by "rat", "cat", "dog" and "cat".
    /// Note:
    /// The number of elements of the given array will not exceed 10,000
    /// The length sum of elements in the given array will not exceed 600,000.
    /// All the input string will only include lower case letters.
    /// The returned elements order does not matter.
    /// </summary>
    public class ConcatenatedWords
    {
        public IList<string> FindAllConcatenatedWordsInADict(string[] words)
        {
            List<string> result = new List<string>();
            HashSet<string> dictionary = new HashSet<string>();

            if (words == null || words.Length <= 1)
            {
                return result;
            }

            // Sort the words array by length, so that when we check if a word is concatenated using other words, we only need to consider the words before it.
            Array.Sort(words, (x, y) => x.Length - y.Length);

            dictionary.Add(words[0]);
            for (int i = 1; i < words.Length; i++)
            {
                if (this.IsConcatenated(words[i], dictionary))
                {
                    result.Add(words[i]);
                }

                dictionary.Add(words[i]);
            }

            return result;

        }

        private bool IsConcatenated(string word, HashSet<string> dictionary)
        {
            // dp[i]: whether word.Substring(0,i) is concatenated
            bool[] dp = new bool[word.Length + 1];
            dp[0] = true;

            for (int i = 1; i < dp.Length; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    if (!dp[j])
                    {
                        continue;
                    }

                    string subString = word.Substring(j, i - j);
                    if (dictionary.Contains(subString))
                    {
                        dp[i] = true;
                        break;
                    }
                }
            }

            return dp[word.Length];
        }
    }
}
