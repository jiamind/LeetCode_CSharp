using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode_CSharp
{
    public class AutocompleteSystem
    {
        public class TrieNode
        {
            public char Character { get; set; }
            public int Times { get; set; }
            public TrieNode[] Neighbors { get; set; }
            public Dictionary<string, int> Top { get; set; }

            public TrieNode(char c)
            {
                this.Character = c;
                this.Times = 0;
                this.Neighbors = new TrieNode[27];
                this.Top = new Dictionary<string, int>();
            }
        }

        TrieNode root, currentNode;
        string current;

        public AutocompleteSystem(string[] sentences, int[] times)
        {
            this.root = new TrieNode('*');
            this.currentNode = this.root;
            this.current = string.Empty;
            for (int i = 0; i < sentences.Length; i++)
            {
                this.InsertSentence(sentences[i], times[i]);
            }
        }

        public IList<string> Input(char c)
        {
            if (c != '#')
            {
                if (c == ' ')
                {
                    if (currentNode.Neighbors[26] == null)
                    {
                        currentNode.Neighbors[26] = new TrieNode(c);
                    }

                    currentNode = currentNode.Neighbors[26];
                }
                else
                {
                    if (currentNode.Neighbors[c - 'a'] == null)
                    {
                        currentNode.Neighbors[c - 'a'] = new TrieNode(c);
                    }

                    currentNode = currentNode.Neighbors[c - 'a'];
                }

                current += c;
                return currentNode.Top.Keys.ToList();
            }
            else
            {
                this.InsertSentence(current, 1);
                this.currentNode = this.root;
                this.current = string.Empty;
                return new List<string>();
            }
        }

        private void InsertSentence(string sentence, int time)
        {
            TrieNode node = this.root;
            foreach (char c in sentence)
            {
                if (c == ' ')
                {
                    if (node.Neighbors[26] == null)
                    {
                        node.Neighbors[26] = new TrieNode(c);
                    }

                    node = node.Neighbors[26];
                }
                else
                {
                    if (node.Neighbors[c - 'a'] == null)
                    {
                        node.Neighbors[c - 'a'] = new TrieNode(c);
                    }

                    node = node.Neighbors[c - 'a'];
                }
            }

            node.Times += time;
            this.UpdateTopThree(sentence, node.Times);
        }

        private void UpdateTopThree(string sentence, int time)
        {
            TrieNode node = root;
            foreach(char c in sentence)
            {
                if (c == ' ')
                {
                    node = node.Neighbors[26];
                }
                else
                {
                    node = node.Neighbors[c - 'a'];
                }

                if (node.Top.ContainsKey(sentence))
                {
                    node.Top[sentence] = time;
                }
                else
                {
                    node.Top.Add(sentence, time);
                }

                node.Top = node.Top.OrderBy(s => s, new SentenceComparer()).ToDictionary(pair => pair.Key, pair => pair.Value);
                if (node.Top.Count > 3)
                {
                    node.Top = node.Top.Take(3).ToDictionary(pair => pair.Key, pair => pair.Value);
                }
            }
        }

        private class SentenceComparer : IComparer<KeyValuePair<string, int>>
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
