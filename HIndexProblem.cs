using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode_CSharp
{
    /// <summary>
    /// 274. H-Index
    /// Given an array of citations (each citation is a non-negative integer) of a researcher, write a function to compute the researcher's h-index.
    /// According to the definition of h-index on Wikipedia: "A scientist has index h if h of his/her N papers have at least h citations each, and the other N − h papers have no more than h citations each."
    /// Example:
    /// Input: citations = [3,0,6,1,5]
    ///     Output: 3 
    /// Explanation: [3,0,6,1,5] means the researcher has 5 papers in total and each of them had
    ///              received 3, 0, 6, 1, 5 citations respectively.
    ///              Since the researcher has 3 papers with at least 3 citations each and the remaining
    ///              two with no more than 3 citations each, her h-index is 3.
    /// Note: If there are several possible values for h, the maximum one is taken as the h-index.
    /// </summary>
    public class HIndexProblem
    {
        /// <summary>
        /// Create an array to store how many times the researcher get i number of citations at each index i
        /// Then scan from the back of that array, and keep track of the total number of citations beyond this point
        /// If we see the total is greater than the current index, it means the researcher have more than i papers which receives i citations
        /// </summary>
        /// <param name="citations">the citations array</param>
        /// <returns>the h index of the researcher</returns>
        public int HIndex(int[] citations)
        {
            if (citations == null || citations.Length == 0)
                return 0;

            int[] numOfCitations = new int[citations.Length + 1];

            for (int i = 0; i < citations.Length; i++)
            {
                if (citations[i] >= citations.Length)
                {
                    numOfCitations[citations.Length]++;
                }
                else
                {
                    numOfCitations[citations[i]]++;
                }
            }

            int total = 0;

            for (int i = numOfCitations.Length - 1; i >= 0; i--)
            {
                total += numOfCitations[i];
                // If the total number of papers which have more than i citations is greater than i, return the index i
                if (total >= i)
                    return i;
            }

            return 0;
        }
    }
}
