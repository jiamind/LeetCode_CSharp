using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode_CSharp
{
    /// <summary>
    /// 443. String Compression
    /// Given an array of characters, compress it in-place.
    /// The length after compression must always be smaller than or equal to the original array.
    /// Every element of the array should be a character(not int) of length 1.
    /// After you are done modifying the input array in-place, return the new length of the array.
    /// Follow up:
    /// Could you solve it using only O(1) extra space?
    /// Example 1:
    /// Input:
    /// ["a","a","b","b","c","c","c"]
    /// Output:
    /// Return 6, and the first 6 characters of the input array should be: ["a","2","b","2","c","3"]
    /// Explanation:
    /// "aa" is replaced by "a2". "bb" is replaced by "b2". "ccc" is replaced by "c3".
    /// Example 2:
    /// Input:
    /// ["a"]
    /// Output:
    /// Return 1, and the first 1 characters of the input array should be: ["a"]
    /// Explanation:
    /// Nothing is replaced.
    /// Example 3:
    /// Input:
    /// ["a","b","b","b","b","b","b","b","b","b","b","b","b"]
    /// Output:
    /// Return 4, and the first 4 characters of the input array should be: ["a","b","1","2"].
    /// Explanation:
    /// Since the character "a" does not repeat, it is not compressed. "bbbbbbbbbbbb" is replaced by "b12".
    /// Notice each digit has it's own entry in the array.
    /// </summary>
    public class StringCompression
    {
        public int Compress(char[] chars)
        {
            if (chars == null || chars.Length == 0)
            {
                return 0;
            }

            if (chars.Length == 1)
            {
                return 1;
            }

            int readIndex = 1, writeIndex = 0, startIndex = 0;
            char currentChar = chars[0];
            for (; readIndex < chars.Length; readIndex++)
            {
                if (chars[readIndex] != currentChar)
                {
                    chars[writeIndex++] = currentChar;
                    if (readIndex - startIndex > 1)
                    {
                        char[] num = (readIndex - startIndex).ToString().ToCharArray();
                        foreach (char c in num)
                        {
                            chars[writeIndex++] = c;
                        }
                    }

                    startIndex = readIndex;
                    currentChar = chars[readIndex];
                }
            }

            chars[writeIndex++] = currentChar;
            if (readIndex - startIndex > 1)
            {
                char[] num = (readIndex - startIndex).ToString().ToCharArray();
                foreach (char c in num)
                {
                    chars[writeIndex++] = c;
                }
            }

            return writeIndex;
        }
    }
}
