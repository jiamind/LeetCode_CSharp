using System;

namespace LeetCode_CSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            //RunLargestRectangleInHistogram();
            //RunMaxPointsOnALine();
            //RunEvaluateReversePolishNotation();
            //RunMinStack();
            RunBasicCalculator();
        }

        #region LargestRectangleInHistogram
        static void RunLargestRectangleInHistogram()
        {
            LargestRectangleInHistogram test = new LargestRectangleInHistogram();
            int[] input = { 2, 1, 5, 6, 2, 3 };
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

        #region EvaluateReversePolishNotation
        static void RunEvaluateReversePolishNotation()
        {
            EvaluateReversePolishNotation test = new EvaluateReversePolishNotation();
            string[] input = { "10", "6", "9", "3", "+", "-11", "*", "/", "*", "17", "+", "5", "+" };
            int output = test.EvalRPN(input);
            Console.WriteLine(output);
        }
        #endregion

        #region MinStack
        static void RunMinStack()
        {
            MinStack test = new MinStack();
            test.Push(0);
            test.Push(1);
            test.Push(0);
            test.GetMin();
            test.Pop();
            test.GetMin();
        }
        #endregion

        #region BasicCalculator
        static void RunBasicCalculator()
        {
            BasicCalculator test = new BasicCalculator();
            string s = "(5-(1+(5)))";
            Console.WriteLine(test.Calculate(s));
            Console.ReadKey();
        }
        #endregion
    }
}
