namespace LeetCode_CSharp
{
    /// <summary>
    /// Given a string which contains only lowercase letters, remove duplicate letters so that every letter appear once and only once. 
    /// You must make sure your result is the smallest in lexicographical order among all possible results.
    /// Input: "bcabc"
    /// Output: "abc"
    /// Input: "cbacdcbc"
    /// Output: "acdb"
    /// </summary>
    class RemoveDuplicateLettersProblem
    {
        /// <summary>
        /// Scan the string from the beginning
        /// If there is a character which is unique, we must take it
        /// Otherwise, find the smallest character while scanning. When we scan pass all the duplicates of one character, we must take the smallest character
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public string RemoveDuplicateLetters(string s)
        {
            int[] freq = new int[26];
            foreach (char c in s)
            {
                freq[c - 'a']++;
            }

            int pos = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] < s[pos])
                {
                    pos = i;
                }

                if (--freq[s[i] - 'a'] == 0)
                {
                    break;
                }
            }

            return s.Length == 0 ? "" : s[pos] + RemoveDuplicateLetters(s.Substring(pos + 1).Replace(s[pos].ToString(), string.Empty));
        }
    }
}
