using System;
using System.Collections.Generic;

namespace LeetCode_CSharp
{
    using System.Linq;

    public class Program
    {
        public static void Main(string[] args)
        {
            //RunLargestRectangleInHistogram();
            //RunMaxPointsOnALine();
            //RunEvaluateReversePolishNotation();
            //RunMinStack();
            //RunBasicCalculator();
            //RunSummaryRangesProblem();
            //RunMaximumProductSubarray();
            //RunMeetingRoomsIIProblem();
            //RunFruitIntoBasketProblem();
            //RunUniqueEmailAddressesProblem();
            //RunPerfectSquareProblem();
            //RunWiggleSortProblem();
            RunBurstBalloons();

            Console.ReadKey();
        }

        #region LargestRectangleInHistogram
        public static void RunLargestRectangleInHistogram()
        {
            LargestRectangleInHistogram test = new LargestRectangleInHistogram();
            int[] input = { 2, 1, 5, 6, 2, 3 };
            int output = test.LargestRectangleArea2(input);
            Console.WriteLine(output);
        }
        #endregion

        #region MaxPointsOnALine
        public static void RunMaxPointsOnALine()
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
        public static void RunEvaluateReversePolishNotation()
        {
            EvaluateReversePolishNotation test = new EvaluateReversePolishNotation();
            string[] input = { "10", "6", "9", "3", "+", "-11", "*", "/", "*", "17", "+", "5", "+" };
            int output = test.EvalRPN(input);
            Console.WriteLine(output);
        }
        #endregion

        #region MaximumProductSubarray
        public static void RunMaximumProductSubarray()
        {
            MaximumProductSubarray test = new MaximumProductSubarray();
            int[] input = { 2, 3, -2, 4 };
            int output = test.MaxProduct(input);
            Console.WriteLine(output);
        }
        #endregion

        #region MinStack
        public static void RunMinStack()
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
        public static void RunBasicCalculator()
        {
            BasicCalculator test = new BasicCalculator();
            string s = "(5-(1+(5)))";
            Console.WriteLine(test.Calculate(s));
        }
        #endregion

        #region SummaryRangesProblem
        public static void RunSummaryRangesProblem()
        {
            SummaryRangesProblem test = new SummaryRangesProblem();
            int[] nums = new int[] { 0, 2, 3, 4, 6, 8, 9 };

            IList<string> result = test.SummaryRanges(nums);
            Console.Write("[");
            foreach (string str in result)
            {
                Console.Write(str + ", ");
            }
            Console.Write("]");
        }
        #endregion

        #region MeetingRoomsIIProblem
        public static void RunMeetingRoomsIIProblem()
        {
            MeetingRoomsII test = new MeetingRoomsII();
            Interval[] intervals = new[] { new Interval(0, 30), new Interval(5, 10), new Interval(15, 20) };
            Console.WriteLine(test.MinMeetingRooms(intervals));
        }
        #endregion

        #region FruitIntoBasketsProblem
        public static void RunFruitIntoBasketProblem()
        {
            FruitIntoBaskets test = new FruitIntoBaskets();
            int[] tree = new[] { 3, 3, 3, 1, 2, 1, 1, 2, 3, 3, 4 };
            Console.WriteLine(test.TotalFruit(tree));
        }
        #endregion

        #region UniqueEmailAddressesProblem
        public static void RunUniqueEmailAddressesProblem()
        {
            UniqueEmailAddresses test = new UniqueEmailAddresses();
            string[] emails = new[] { "test.email+alex@leetcode.com", "test.e.mail+bob.cathy@leetcode.com", "testemail+david@lee.tcode.com" };
            Console.WriteLine(test.NumUniqueEmails(emails));
        }
        #endregion

        #region PerfectSquaresProblem
        public static void RunPerfectSquareProblem()
        {
            PerfectSquares test = new PerfectSquares();
            Console.WriteLine(test.NumSquares(13));
        }
        #endregion

        #region WiggleSortProblem
        public static void RunWiggleSortProblem()
        {
            WiggleSortProblem test = new WiggleSortProblem();
            int[] nums = { 3, 5, 2, 1, 6, 4 };
            test.WiggleSort(nums);
            PrintEnumerable(nums);
        }
        #endregion

        #region BurstBalloonsProblem
        public static void RunBurstBalloons()
        {
            BurstBalloons test = new BurstBalloons();
            int[] nums = { 3, 1, 5, 8 };
            Console.WriteLine(test.MaxCoins(nums));
        }
        #endregion

        #region HelperMethods
        public static void PrintEnumerable<T>(IEnumerable<T> enumerable)
        {
            List<string> strArray = enumerable.Select(value => value.ToString()).ToList();
            string joined = string.Join(",", strArray);
            Console.Write("[");
            Console.Write(joined);
            Console.Write("]");
        }
        #endregion
    }
}
