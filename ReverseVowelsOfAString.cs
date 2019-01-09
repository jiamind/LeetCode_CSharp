using System.Collections.Generic;

namespace LeetCode_CSharp
{
    /// <summary>
    /// Write a function that takes a string as input and reverse only the vowels of a string.
    /// Input: "hello"
    /// Output: "holle"
    /// </summary>
    class ReverseVowelsOfAString
    {
        /// <summary>
        /// Scan from both side of the string. Swap any pair of vowels
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public string ReverseVowels(string s)
        {
            HashSet<char> vowels = new HashSet<char>();
            vowels.Add('a');
            vowels.Add('e');
            vowels.Add('i');
            vowels.Add('o');
            vowels.Add('u');
            vowels.Add('A');
            vowels.Add('E');
            vowels.Add('I');
            vowels.Add('O');
            vowels.Add('U');
            char[] charArray = s.ToCharArray();
            int i = 0, j = charArray.Length - 1;
            while (j > i)
            {
                while (!vowels.Contains(charArray[i]))
                {
                    i++;
                    if (i >= charArray.Length)
                    {
                        break;
                    }
                }

                while (!vowels.Contains(charArray[j]))
                {
                    j--;
                    if (j <= -1)
                    {
                        break;
                    }
                }

                if (i >= j)
                {
                    break;
                }

                if (i != charArray.Length && j != -1)
                {
                    char temp = charArray[i];
                    charArray[i] = charArray[j];
                    charArray[j] = temp;
                }

                i++;
                j--;
            }

            return new string(charArray);
        }
    }
}
