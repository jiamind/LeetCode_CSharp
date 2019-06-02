using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode_CSharp
{
    /// <summary>
    /// 211. Add and Search Word - Data structure design
    /// Design a data structure that supports the following two operations:
    /// void addWord(word)
    /// bool search(word)
    /// search(word) can search a literal word or a regular expression string containing only letters a-z or .. A.means it can represent any one letter.
    /// </summary>
    public class WordDictionary
    {
        public class TrieNode
        {
            public TrieNode[] Neighbors { get; set; }

            public bool IsEnd { get; set; }

            public TrieNode()
            {
                this.Neighbors = new TrieNode[26];
            }
        }

        private TrieNode root;

        /** Initialize your data structure here. */
        public WordDictionary()
        {
            this.root = new TrieNode();
        }

        /** Adds a word into the data structure. */
        public void AddWord(string word)
        {
            TrieNode p = root;
            char[] charArray = word.ToCharArray();
            foreach (char c in charArray)
            {
                if (p.Neighbors[c - 'a'] == null)
                {
                    p.Neighbors[c - 'a'] = new TrieNode();
                }

                p = p.Neighbors[c - 'a'];
            }

            p.IsEnd = true;
        }

        /** Returns if the word is in the data structure. A word could contain the dot character '.' to represent any one letter. */
        public bool Search(string word)
        {
            return Match(root, word.ToCharArray(), 0);
        }

        /// <summary>
        /// Matching the character array starting from the TrieNode
        /// </summary>
        /// <param name="node">the parent TrieNode</param>
        /// <param name="array">the search word character array</param>
        /// <param name="index">the index of the search word character array</param>
        /// <returns>true if character array can be matched. Otherwise, return false.</returns>
        public bool Match(TrieNode node, char[] array, int index)
        {
            if (node == null)
            {
                return false;
            }

            if (index >= array.Length)
            {
                return node.IsEnd;
            }

            if (array[index] == '.')
            {
                for (int i = 0; i < node.Neighbors.Length; i++)
                {
                    if (Match(node.Neighbors[i], array, index + 1))
                    {
                        return true;
                    }
                }

                return false;
            }
            else
            {
                return Match(node.Neighbors[array[index] - 'a'], array, index + 1);
            }
        }
    }
}
