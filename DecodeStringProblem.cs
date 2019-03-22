using System.Text;

namespace LeetCode_CSharp
{
    /// <summary>
    /// Given an encoded string, return it's decoded string.
    /// The encoding rule is: k[encoded_string], where the encoded_string inside the square brackets is being repeated exactly k times.Note that k is guaranteed to be a positive integer.
    /// You may assume that the input string is always valid; No extra white spaces, square brackets are well-formed, etc.
    /// Furthermore, you may assume that the original data does not contain any digits and that digits are only for those repeat numbers, k.For example, there won't be input like 3a or 2[4].
    /// </summary>
    public class DecodeStringProblem
    {
        /// <summary>
        /// Use recursive method. Call this method for each inner k[encoded_string]
        /// </summary>
        /// <param name="s">the input string</param>
        /// <returns>the decoded string</returns>
        public string DecodeString(string s)
        {
            if (s == null)
            {
                return null;
            }

            char[] array = s.ToCharArray();
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < array.Length; i++)
            {
                if (this.IsDigit(array[i]))
                {
                    int repeatTimes = this.GetNextNumber(array, ref i);
                    i++;
                    string str = this.DecodeString(this.GetNextString(array, ref i));
                    for (int j = 0; j < repeatTimes; j++)
                    {
                        sb.Append(str);
                    }
                }
                else
                {
                    sb.Append(array[i]);
                }
            }

            return sb.ToString();
        }

        /// <summary>
        /// Check if the character is a digit.
        /// </summary>
        /// <param name="c">the input character</param>
        /// <returns>true if the character is a digit. Otherwise return false.</returns>
        private bool IsDigit(char c)
        {
            if (int.TryParse(c.ToString(), out int _))
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Get the next number in the array from the starting index. 
        /// The current index must point to a digit.
        /// After method exits, the index should point to '['.
        /// </summary>
        /// <param name="array">the character array</param>
        /// <param name="index">the starting index</param>
        /// <returns>the next number</returns>
        private int GetNextNumber(char[] array, ref int index)
        {
            StringBuilder sb = new StringBuilder();
            while (this.IsDigit(array[index]))
            {
                sb.Append(array[index]);
                index++;
            }

            return int.Parse(sb.ToString());
        }

        /// <summary>
        /// Get the next string in the array from the starting index with its brackets "[]". 
        /// The current index must point to the first character of the string.
        /// After method exits, the index should point to ']'.
        /// </summary>
        /// <param name="array">the input array</param>
        /// <param name="index">the index</param>
        /// <returns>the next string</returns>
        private string GetNextString(char[] array, ref int index)
        {
            StringBuilder sb = new StringBuilder();
            int c = 0;
            while (array[index] != ']' || c != 0)
            {
                sb.Append(array[index]);
                if (array[index] == '[')
                {
                    c++;
                }
                else if (array[index] == ']')
                {
                    c--;
                }

                index++;
            }

            return sb.ToString();
        }
    }
}
