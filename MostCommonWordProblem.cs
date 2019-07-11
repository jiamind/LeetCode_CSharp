using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode_CSharp
{
    /// <summary>
    /// 819. Most Common Word
    /// Given a paragraph and a list of banned words, return the most frequent word that is not in the list of banned words.  It is guaranteed there is at least one word that isn't banned, and that the answer is unique.
    /// Words in the list of banned words are given in lowercase, and free of punctuation.Words in the paragraph are not case sensitive.The answer is in lowercase.
    /// Example:
    /// Input: 
    /// paragraph = "Bob hit a ball, the hit BALL flew far after it was hit."
    /// banned = ["hit"]
    /// Output: "ball"
    /// Explanation: 
    /// "hit" occurs 3 times, but it is a banned word.
    /// "ball" occurs twice (and no other word does), so it is the most frequent non-banned word in the paragraph.
    /// Note that words in the paragraph are not case sensitive,
    /// that punctuation is ignored (even if adjacent to words, such as "ball,"), 
    /// and that "hit" isn't the answer even though it occurs more because it is banned.
    /// </summary>
    public class MostCommonWordProblem
    {
        public string MostCommonWord(string paragraph, string[] banned)
        {
            HashSet<string> bannedSet = new HashSet<string>(banned.Select(w => w.ToLower()));
            Dictionary<string, int> wordFreq = new Dictionary<string, int>();
            StringBuilder sb = new StringBuilder();

            string result = string.Empty;
            int freq = 0;
            paragraph += '.';

            foreach (char c in paragraph)
            {
                if (char.IsLetter(c))
                {
                    sb.Append(c);
                }
                else
                {
                    if (sb.Length > 0)
                    {
                        string word = sb.ToString().ToLower();
                        sb = new StringBuilder();

                        if (bannedSet.Contains(word))
                        {
                            continue;
                        }

                        if (wordFreq.ContainsKey(word))
                        {
                            wordFreq[word]++;
                        }
                        else
                        {
                            wordFreq[word] = 1;
                        }

                        if (wordFreq[word] > freq)
                        {
                            result = word;
                            freq = wordFreq[word];
                        }
                    }
                }
            }

            return result;
        }
    }
}
