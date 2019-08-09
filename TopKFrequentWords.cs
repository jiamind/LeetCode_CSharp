using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode_CSharp
{
    /// <summary>
    /// 692. Top K Frequent Words
    /// Given a non-empty list of words, return the k most frequent elements.
    /// Your answer should be sorted by frequency from highest to lowest.If two words have the same frequency, then the word with the lower alphabetical order comes first.
    /// Example 1:
    /// Input: ["i", "love", "leetcode", "i", "love", "coding"], k = 2
    /// Output: ["i", "love"]
    /// Explanation: "i" and "love" are the two most frequent words.
    /// Note that "i" comes before "love" due to a lower alphabetical order.
    /// Example 2:
    /// Input: ["the", "day", "is", "sunny", "the", "the", "the", "sunny", "is", "is"], k = 4
    /// Output: ["the", "is", "sunny", "day"]
    /// Explanation: "the", "is", "sunny" and "day" are the four most frequent words,
    /// with the number of occurrence being 4, 3, 2 and 1 respectively.
    /// </summary>
    public class TopKFrequentWords
    {
        public IList<string> TopKFrequent(string[] words, int k)
        {
            Dictionary<string, int> dictionary = new Dictionary<string, int>();

            foreach (string word in words)
            {
                if (!dictionary.ContainsKey(word))
                {
                    dictionary.Add(word, 1);
                }
                else
                {
                    dictionary[word]++;
                }
            }

            return dictionary.OrderBy(x => x, new WordComparer()).Take(k).Select(x => x.Key).ToList();
        }

        private class WordComparer : IComparer<KeyValuePair<string, int>>
        {
            public int Compare(KeyValuePair<string, int> x, KeyValuePair<string, int> y)
            {
                if (x.Value == y.Value)
                {
                    return string.Compare(x.Key, y.Key, StringComparison.Ordinal);
                }

                return y.Value - x.Value;
            }
        }
    }
}
