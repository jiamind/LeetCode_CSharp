using System.Collections.Generic;

namespace LeetCode_CSharp
{
    public class Point
    {
        public int x;
        public int y;
        public Point() { x = 0; y = 0; }
        public Point(int a, int b) { x = a; y = b; }
    }

    /// <summary>
    /// Given n points on a 2D plane, find the maximum number of points that lie on the same straight line.
    /// </summary>
    public class MaxPointsOnALine
    {
        /// <summary>
        /// Iterate through each pair of points. 
        /// Calculate slop and store the number of points which has same slop in a dictionary
        /// </summary>
        /// <returns>The maximum number of points on a line</returns>
        /// <param name="points">an array of points</param>
        public int MaxPoints(Point[] points)
        {
            int globalMax = 0;
            for (int i = 0; i < points.Length; i++)
            {
                Dictionary<decimal, int> dict = new Dictionary<decimal, int>();
                int numOfSamePoints = 1;

                for (int j = i + 1; j < points.Length; j++)
                {
                    // Consider the situations where points are the same (0/0), x axis of points are the same (/0)
                    if (points[i].x == points[j].x && points[i].y == points[j].y)
                    {
                        numOfSamePoints++;
                    }
                    else if (points[i].x == points[j].x)
                    {
                        dict[decimal.MaxValue] = dict.ContainsKey(decimal.MaxValue) ? dict[decimal.MaxValue] + 1 : 1;
                    }
                    else
                    {
                        decimal slop = ((decimal)points[j].y - (decimal)points[i].y) / ((decimal)points[j].x - (decimal)points[i].x);
                        dict[slop] = dict.ContainsKey(slop) ? dict[slop] + 1 : 1;
                    }
                }

                // Iterate through the dictionary, find local max
                int localMax = 0;
                foreach (KeyValuePair<decimal, int> tuple in dict)
                {
                    localMax = tuple.Value > localMax ? tuple.Value : localMax;
                }
                // Update local max with number of same points
                localMax += numOfSamePoints;
                // Update global max
                globalMax = localMax > globalMax ? localMax : globalMax;
            }

            return globalMax;
        }
    }
}