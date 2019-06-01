using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode_CSharp
{
    /// <summary>
    /// 753. Cracking the Safe
    /// There is a box protected by a password. The password is n digits, where each letter can be one of the first k digits 0, 1, ..., k-1.
    /// You can keep inputting the password, the password will automatically be matched against the last n digits entered.
    /// For example, assuming the password is "345", I can open it when I type "012345", but I enter a total of 6 digits.
    /// Please return any string of minimum length that is guaranteed to open the box after the entire string is inputted.
    /// </summary>
    public class CrackingTheSafe
    {
        private StringBuilder sb = new StringBuilder();

        private HashSet<string> visited = new HashSet<string>();

        public string CrackSafe(int n, int k)
        {
            string start = string.Empty;
            for (int i = 0; i < n - 1; i++)
            {
                start += "0";
            }

            Crack(start, k);
            sb.Append(start);
            return sb.ToString();
        }

        private void Crack(string start, int k)
        {
            for (int i = 0; i < k; i++)
            {
                string next = start + i.ToString();
                if (!visited.Contains(next))
                {
                    visited.Add(next);
                    Crack(next.Substring(1), k);
                    sb.Append(i);
                }
            }
        }
    }
}
