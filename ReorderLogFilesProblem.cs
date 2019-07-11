using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode_CSharp
{
    /// <summary>
    /// 937. Reorder Log Files
    /// You have an array of logs.  Each log is a space delimited string of words.
    ///    For each log, the first word in each log is an alphanumeric identifier.Then, either:
    /// Each word after the identifier will consist only of lowercase letters, or;
    /// Each word after the identifier will consist only of digits.
    /// We will call these two varieties of logs letter-logs and digit-logs.It is guaranteed that each log has at least one word after its identifier.
    /// Reorder the logs so that all of the letter-logs come before any digit-log.The letter-logs are ordered lexicographically ignoring identifier, with the identifier used in case of ties.  The digit-logs should be put in their original order.
    /// Return the final order of the logs.
    /// Example 1:
    /// Input: ["a1 9 2 3 1","g1 act car","zo4 4 7","ab1 off key dog","a8 act zoo"]
    /// Output: ["g1 act car","a8 act zoo","ab1 off key dog","a1 9 2 3 1","zo4 4 7"]
    /// Note:
    /// 0 <= logs.length <= 100
    /// 3 <= logs[i].length <= 100
    /// logs[i] is guaranteed to have an identifier, and a word after the identifier.
    /// </summary>
    public class ReorderLogFilesProblem
    {
        public string[] ReorderLogFiles(string[] logs)
        {
            //// Do not use Array.Sort() here - the implementation performs an unstable sort; that is, if two elements are equal, their order might not be preserved.
            //// https://stackoverflow.com/a/1832706
            logs = logs.OrderBy(l => l, new LogComparer()).ToArray();

            return logs;
        }

        private class LogComparer : IComparer<string>
        {
            public int Compare(string x, string y)
            {
                string[] log1 = x.Split(new char[] { ' ' }, 2);
                string[] log2 = y.Split(new char[] { ' ' }, 2);

                bool isLog1Digit = char.IsDigit(log1[1][0]);
                bool isLog2Digit = char.IsDigit(log2[1][0]);

                if (!isLog1Digit && !isLog2Digit)
                {
                    if (log1[1].CompareTo(log2[1]) == 0)
                    {
                        return log1[0].CompareTo(log2[0]);
                    }

                    return log1[1].CompareTo(log2[1]);
                }

                return isLog1Digit ? (isLog2Digit ? 0 : 1) : -1;
            }
        }
    }
}
