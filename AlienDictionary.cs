using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode_CSharp
{
    /// <summary>
    /// 269. Alien Dictionary
    /// There is a new alien language which uses the latin alphabet. However, the order among letters are unknown to you. You receive a list of non-empty words from the dictionary, where words are sorted lexicographically by the rules of this new language. Derive the order of letters in this language.
    /// Example 1:
    /// Input:
    /// [
    /// "wrt",
    /// "wrf",
    /// "er",
    /// "ett",
    /// "rftt"
    /// ]
    /// Output: "wertf"
    /// </summary>
    public class AlienDictionary
    {
        /// <summary>
        /// Iterate through each character in the words, keep track of the number of characters should be placed before each character, 
        /// as well as the characters should be placed after each character
        /// </summary>
        /// <param name="words">the input word array</param>
        /// <returns>the lexicographical order of the language</returns>
        public string AlienOrder(string[] words)
        {
            Dictionary<char, int> numberOfCharactersBefore = new Dictionary<char, int>();
            Dictionary<char, HashSet<char>> charactersAfter = new Dictionary<char, HashSet<char>>();

            // Initiaze the two dictionarys
            foreach (string word in words)
            {
                char[] array = word.ToCharArray();
                for (int i = 0; i < array.Length; i++)
                {
                    numberOfCharactersBefore[array[i]] = 0;
                    charactersAfter[array[i]] = new HashSet<char>();
                }
            }

            //// Compare each character of the current and the next word
            //// Record the first pair of characters x, y that differs (means x should be placed before y)
            for (int i = 0; i < words.Length - 1; i++)
            {
                char[] current = words[i].ToCharArray();
                char[] next = words[i + 1].ToCharArray();

                int minLength = Math.Min(current.Length, next.Length);
                for (int j = 0; j < minLength; j++)
                {
                    if (current[j] != next[j])
                    {
                        if (!charactersAfter[current[j]].Contains(next[j]))
                        {
                            numberOfCharactersBefore[next[j]]++;
                            charactersAfter[current[j]].Add(next[j]);
                        }
                        break;
                    }
                }
            }

            StringBuilder sb = new StringBuilder();
            PrintLexicoOrder(sb, numberOfCharactersBefore, charactersAfter);

            //// The length of the output string should be the same as the number of distinct characters in the input words.
            //// One character appears exactly once in the lexicographical order output string
            //// Otherwise, the language is not valid
            return sb.Length == numberOfCharactersBefore.Count ? sb.ToString() : string.Empty;
        }

        /// <summary>
        /// Print the lexicographical order of the language using the dictionarys
        /// </summary>
        /// <param name="sb">the string builder</param>
        /// <param name="numberOfCharactersBefore">the dictionary of number of characters before each character</param>
        /// <param name="charactersAfter">the dictionary of characters after each character</param>
        private void PrintLexicoOrder(StringBuilder sb, Dictionary<char, int> numberOfCharactersBefore, Dictionary<char, HashSet<char>> charactersAfter)
        {
            // We find the next character to print (the next character should have no characters before it)
            if (numberOfCharactersBefore.Any(pair => pair.Value == 0))
            {
                char c = numberOfCharactersBefore.Where(pair => pair.Value == 0).First().Key;
                sb.Append(c);

                // Make the number of characters before it to be negative so that we won't find it in the future
                numberOfCharactersBefore[c]--;

                // All the characters after the current character shall now have one less character before them
                HashSet<char> set = charactersAfter[c];
                foreach (char a in set)
                {
                    numberOfCharactersBefore[a]--;
                }

                PrintLexicoOrder(sb, numberOfCharactersBefore, charactersAfter);
            }
        }
    }
}
