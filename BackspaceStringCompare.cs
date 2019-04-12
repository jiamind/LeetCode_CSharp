using System;

namespace LeetCode_CSharp
{
    /// <summary>
    /// 844 - Backspace String Compare
    /// Given two strings S and T, return if they are equal when both are typed into empty text editors. # means a backspace character.
    /// </summary>
    public class BackspaceStringCompare
    {
        /// <summary>
        /// Iterate backwards on <paramref name="S"/> and <paramref name="T"/>. Store the number of pending deletes on each string and move the pointer backwards accordingly.
        /// </summary>
        /// <param name="S">the input string S</param>
        /// <param name="T">the input string T</param>
        /// <returns>true if the two strings are equal when both are typed into empty text editors. Otherwise, return false.</returns>
        public bool BackspaceCompare(string S, string T)
        {
            if (string.IsNullOrEmpty(S) && string.IsNullOrEmpty(T))
            {
                return true;
            }

            if (string.IsNullOrEmpty(S) || string.IsNullOrEmpty(T))
            {
                return false;
            }

            int i = S.Length - 1, j = T.Length - 1;
            int iDeletes = 0, jDeletes = 0;

            while (i >= -1 && j >= -1)
            {
                if (i >= 0 && S[i] == '#')
                {
                    iDeletes++;
                    i--;
                    continue;
                }

                if (j >= 0 && T[j] == '#')
                {
                    jDeletes++;
                    j--;
                    continue;
                }

                if (iDeletes > 0)
                {
                    i = Math.Max(i - 1, -1);
                    iDeletes--;
                    continue;
                }

                if (jDeletes > 0)
                {
                    j = Math.Max(j - 1, -1);
                    jDeletes--;
                    continue;
                }

                if (i == -1 && j == -1)
                {
                    return true;
                }

                if (i == -1 || j == -1)
                {
                    return false;
                }

                if (S[i] != T[j])
                {
                    return false;
                }

                i--;
                j--;
            }

            return true;
        }
    }
}
