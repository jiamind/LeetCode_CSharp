using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode_CSharp
{
    public class MostStonesRemovedWithSameRowOrColumn
    {
        public int island = 0;
        
        /// <summary>
        /// dict[x,y]: y is the parent of x 
        /// </summary>
        public Dictionary<int, int> dict = new Dictionary<int, int>();

        public int RemoveStones(int[][] stones)
        {
            for (int i = 0; i < stones.GetLength(0); i++)
            {
                Union(stones[i][0], ~stones[i][1]);
            }

            return stones.GetLength(0) - island;
        }

        /// <summary>
        /// Find the absolute parent of <paramref name="x"/>
        /// </summary>
        /// <param name="x">the value x</param>
        /// <returns>the absolute parent of <paramref name="x"/> </returns>
        public int Find(int x)
        {
            if (!dict.ContainsKey(x))
            {
                dict[x] = x;
                island++;
            }

            //if (dict[x] != x)
            //{
            //    dict[x] = Find(dict[x]);
            //}

            //return dict[x];

            // If x is not the (absolute) parent of itself, find and return the absolute parent
            if (dict[x] != x)
            {
                return Find(dict[x]);
            }

            return x;
        }

        /// <summary>
        /// Union y as the parent of x
        /// </summary>
        /// <param name="x">the value x</param>
        /// <param name="y">the value y</param>
        public void Union(int x, int y)
        {
            x = Find(x);
            y = Find(y);

            if (x != y)
            {
                dict[x] = y;
                island--;
            }
        }
    }
}
