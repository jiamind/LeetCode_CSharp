using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode_CSharp
{
    /// <summary>
    /// 973. K Closest Points to Origin
    /// We have a list of points on the plane.  Find the K closest points to the origin (0, 0).
    /// (Here, the distance between two points on a plane is the Euclidean distance.)
    /// You may return the answer in any order.The answer is guaranteed to be unique (except for the order that it is in.)
    /// Example 1:
    /// Input: points = [[1,3],[-2,2]], K = 1
    /// Output: [[-2,2]]
    /// Explanation: 
    /// The distance between(1, 3) and the origin is sqrt(10).
    /// The distance between(-2, 2) and the origin is sqrt(8).
    /// Since sqrt(8) < sqrt(10), (-2, 2) is closer to the origin.
    /// We only want the closest K = 1 points from the origin, so the answer is just[[-2, 2]].
    /// Example 2:
    /// Input: points = [[3,3],[5,-1],[-2,4]], K = 2
    /// Output: [[3,3],[-2,4]]
    /// (The answer [[-2, 4],[3,3]] would also be accepted.)
    /// Note:
    /// 1 <= K <= points.length <= 10000
    /// -10000 < points[i][0] < 10000
    /// -10000 < points[i][1] < 10000
    /// </summary>
    public class KClosestPointsToOrigin
    {
        /// <summary>
        /// Use quick select algorithm
        /// </summary>
        /// <param name="points">the points array</param>
        /// <param name="K">number of closest points</param>
        /// <returns>the K closest points</returns>
        public int[][] KClosest(int[][] points, int K)
        {
            int[][] result = new int[K][];
            if (points.Length == 1 && K == 1)
            {
                Array.Copy(points, result, K);
                return result;
            }

            int left = 0, right = points.Length - 1;

            while (left < right)
            {
                int pivot = Partition(points, left, right);
                if (pivot == K)
                {
                    break;
                }
                else if (pivot < K)
                {
                    left = pivot + 1;
                }
                else
                {
                    right = pivot - 1;
                }
            }

            Array.Copy(points, result, K);
            return result;
        }

        private int Partition(int[][] points, int start, int end)
        {
            Random rand = new Random();
            int pivot = rand.Next(start, end + 1);
            Swap(points, pivot, end);

            int left = start;
            for (int right = start; right < end; right++)
            {
                if (GetDistance(points[right]) < GetDistance(points[end]))
                {
                    Swap(points, left, right);
                    left++;
                }
            }

            Swap(points, left, end);

            return left;
        }

        private int GetDistance(int[] point)
        {
            return point[0] * point[0] + point[1] * point[1];
        }

        private void Swap(int[][] points, int i, int j)
        {
            int pi0 = points[i][0], pi1 = points[i][1];
            points[i][0] = points[j][0];
            points[i][1] = points[j][1];
            points[j][0] = pi0;
            points[j][1] = pi1;
        }
    }
}
