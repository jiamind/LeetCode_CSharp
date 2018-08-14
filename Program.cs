using System;

namespace LeetCode_CSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            //RunLargestRectangleInHistogram();
            RunMaxPointsOnALine();
        }

        #region LargestRectangleInHistogram
        static void RunLargestRectangleInHistogram()
        {
            LargestRectangleInHistogram test = new LargestRectangleInHistogram();
            int[] input = new int[] { 2, 1, 5, 6, 2, 3 };
            int output = test.LargestRectangleArea2(input);
            Console.WriteLine(output);
        }
        #endregion

        #region MaxPointsOnALine
        static void RunMaxPointsOnALine()
        {
            MaxPointsOnALine test = new MaxPointsOnALine();
            Point[] points = new Point[3];
            points[0] = new Point(0, 0);
            points[1] = new Point(94911151, 94911150);
            points[2] = new Point(94911152, 94911151);
            int output = test.MaxPoints(points);
            Console.WriteLine(output);
        }
        #endregion
    }
}
