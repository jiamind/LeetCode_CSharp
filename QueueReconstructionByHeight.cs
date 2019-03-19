using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode_CSharp
{
    /// <summary>
    /// Suppose you have a random list of people standing in a queue. 
    /// Each person is described by a pair of integers (h, k), 
    /// where h is the height of the person and k is the number of people in front of this person who have a height greater than or equal to h. 
    /// Write an algorithm to reconstruct the queue.
    /// Note:
    /// The number of people is less than 1,100.
    /// </summary>
    public class QueueReconstructionByHeight
    {
        /// <summary>
        /// Sort the people array by height in decending order. Person with lower count comes first when people are of same height.
        /// Insert each person in the array with count as its index. 
        /// </summary>
        /// <param name="people"></param>
        /// <returns></returns>
        public int[,] ReconstructQueue(int[,] people)
        {
            if (people == null)
            {
                return null;
            }

            List<List<int>> list = people.Cast<int>().Select((x, i) => new { x, index = i / people.GetLength(1) }).GroupBy(x => x.index).Select(x => x.Select(s => s.x).ToList()).ToList();
            PeopleComparer comparer = new PeopleComparer();
            list.Sort(comparer);

            List<List<int>> result = new List<List<int>>();

            foreach (List<int> p in list)
            {
                result.Insert(p[1] > result.Count ? result.Count : p[1], p);
            }

            int[,] array = new int[people.GetLength(0), people.GetLength(1)];
            for (int i = 0; i < people.GetLength(0); i++)
            {
                array[i, 0] = result[i][0];
                array[i, 1] = result[i][1];
            }

            return array;
        }

        public class PeopleComparer : IComparer<List<int>>
        {
            public int Compare(List<int> x, List<int> y)
            {
                if (x[0] == y[0])
                {
                    return x[1] - y[1];
                }

                return y[0] - x[0];
            }
        }
    }
}
