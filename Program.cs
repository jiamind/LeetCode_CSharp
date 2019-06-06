using System;
using System.Collections.Generic;

namespace LeetCode_CSharp
{
    using System.Linq;
    using global::CountCompleteTreeNodes;

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
            //RunBurstBalloons();
            //RunCountOfSmallerNumbersAfterSelf();
            //RunRemoveDuplicateLettersProblem();
            //RunPowerOfThree();
            //RunPalindromePairsProblem();
            //RunReverseVowelsOfAString();
            //RunLongestAbsoluteFilePath();
            //RunQueueReconstructionByHeight();
            //RunMaximumXorOfTwoNumbersInAnArray();
            //RunDecodeStringProblem();
            //RunAddStringProblem();
            //RunFindAllNumbersDisappearedInAnArray();
            //RunIslandPerimeterProblem();
            //RunSubarraySumEqualsK();
            //RunRobotReturnToOrigin();
            //RunDailyTemperatures();
            //RunOddEvenJump();
            //RunMostStonesRemovedWithSameRowOrColumn();
            //RunBackspaceStringCompare();
            //RunEvaluateDivision();
            //RunCountCompleteTreeNodes();
            //RunCrackingTheSafe();
            //RunAddAndSearchWord();
            //RunAlienDictionary();
            RunContiguousArray();

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

        #region CountOfSmallerNumbersAfterSelf
        public static void RunCountOfSmallerNumbersAfterSelf()
        {
            CountOfSmallerNumbersAfterSelf test = new CountOfSmallerNumbersAfterSelf();
            int[] nums = { 5, 2, 6, 1 };
            IList<int> result = test.CountSmaller(nums);
            PrintEnumerable(result);
        }
        #endregion

        #region RemoveDuplicateLettersProblem
        public static void RunRemoveDuplicateLettersProblem()
        {
            RemoveDuplicateLettersProblem test = new RemoveDuplicateLettersProblem();
            string s = "abacb";
            Console.WriteLine(test.RemoveDuplicateLetters(s));
        }
        #endregion

        #region PowerOfThree
        public static void RunPowerOfThree()
        {
            PowerOfThree test = new PowerOfThree();
            int n = 45;
            Console.WriteLine(test.IsPowerOfThree(n));
        }
        #endregion

        #region PalindromePairs
        public static void RunPalindromePairsProblem()
        {
            PalindromePairsProblem test = new PalindromePairsProblem();
            //string[] s = { "abcd", "dcba", "lls", "s", "sssll" };
            string[] s = { "a", "b", "c", "ab", "ac", "aa" };
            IList<IList<int>> result = test.PalindromePairs(s);
            foreach (IList<int> pair in result)
            {
                PrintEnumerable(pair);
                Console.WriteLine();
            }
        }
        #endregion

        #region ReverseVowelsOfAString
        public static void RunReverseVowelsOfAString()
        {
            ReverseVowelsOfAString test = new ReverseVowelsOfAString();
            string s = "OE";
            string result = test.ReverseVowels(s);
            Console.WriteLine(result);
        }
        #endregion

        #region LongestAbsoluteFilePath
        public static void RunLongestAbsoluteFilePath()
        {
            LongestAbsoluteFilePath test = new LongestAbsoluteFilePath();
            string input = "dir\n\tsubdir1\n\t\tfile1.ext\n\t\tsubsubdir1\n\tsubdir2\n\t\tsubsubdir2\n\t\t\tfile2.ext";
            Console.WriteLine(test.LengthLongestPath(input));
        }
        #endregion

        #region QueueReconstructionByHeight
        public static void RunQueueReconstructionByHeight()
        {
            QueueReconstructionByHeight test = new QueueReconstructionByHeight();
            //int[,] input = new int[,] { { 7, 0 }, { 4, 4 }, { 7, 1 }, { 5, 0 }, { 6, 1 }, { 5, 2 } };
            int[,] input = new int[,] { { 8, 2 }, { 4, 2 }, { 4, 5 }, { 2, 0 }, { 7, 2 }, { 1, 4 }, { 9, 1 }, { 3, 1 }, { 9, 0 }, { 1, 0 } };
            int[,] result = test.ReconstructQueue(input);

            for (int i = 0; i < result.GetLength(0); i++)
            {
                Console.WriteLine("[" + result[i, 0] + "," + result[i, 1] + "]");
            }
        }
        #endregion

        #region MaximumXorOfTwoNumbersInAnArray
        public static void RunMaximumXorOfTwoNumbersInAnArray()
        {
            MaximumXorOfTwoNumbersInAnArray test = new MaximumXorOfTwoNumbersInAnArray();
            int[] nums = { 3, 10, 5, 25, 2, 8 };
            Console.WriteLine(test.FindMaximumXOR(nums));
        }
        #endregion

        #region DecodeStringProblem
        public static void RunDecodeStringProblem()
        {
            DecodeStringProblem test = new DecodeStringProblem();
            string input = "2[abc]3[cd]ef";
            Console.WriteLine(test.DecodeString(input));
        }
        #endregion

        #region AddStringProblem
        public static void RunAddStringProblem()
        {
            AddStringsProblem test = new AddStringsProblem();
            string num1 = "999999";
            string num2 = "99";
            Console.WriteLine(test.AddStrings(num1, num2));
        }
        #endregion

        #region FindAllNumbersDisappearedInAnArray
        public static void RunFindAllNumbersDisappearedInAnArray()
        {
            FindAllNumbersDisappearedInAnArray test = new FindAllNumbersDisappearedInAnArray();
            int[] input = { 4, 3, 2, 7, 8, 2, 3, 1 };
            PrintEnumerable(test.FindDisappearedNumbers(input));
        }
        #endregion

        #region IslandPerimeterProblem
        public static void RunIslandPerimeterProblem()
        {
            IslandPerimeterProblem test = new IslandPerimeterProblem();
            int[,] input = { { 0, 1, 0, 0 }, { 1, 1, 1, 0 }, { 0, 1, 0, 0 }, { 1, 1, 0, 0 } };
            Console.WriteLine(test.IslandPerimeter(input));
        }
        #endregion

        #region SubarraySumEqualsK
        public static void RunSubarraySumEqualsK()
        {
            SubarraySumEqualsK test = new SubarraySumEqualsK();
            int[] nums = { 1, 1, 1 };
            int k = 2;
            Console.WriteLine(test.SubarraySum(nums, k));
        }
        #endregion

        #region RobotReturnToOrigin
        public static void RunRobotReturnToOrigin()
        {
            RobotReturnToOrigin test = new RobotReturnToOrigin();
            string input = "LL";
            Console.WriteLine(test.JudgeCircle(input));
        }
        #endregion

        #region DailyTemperaturesProblem
        public static void RunDailyTemperatures()
        {
            DailyTemperaturesProblem test = new DailyTemperaturesProblem();
            int[] T = { 73, 74, 75, 71, 69, 72, 76, 73 };
            PrintEnumerable<int>(test.DailyTemperatures(T));
        }
        #endregion

        #region OddEvenJump
        public static void RunOddEvenJump()
        {
            OddEvenJump test = new OddEvenJump();
            int[] A = { 5, 1, 3, 4, 2 };
            Console.WriteLine(test.OddEvenJumps(A));
        }
        #endregion

        #region MostStonesRemovedWithSameRowOrColumn
        public static void RunMostStonesRemovedWithSameRowOrColumn()
        {
            MostStonesRemovedWithSameRowOrColumn test = new MostStonesRemovedWithSameRowOrColumn();
            int[][] stones = new int[][]{
               new int[] {0,0},
               new int[] {0,1},
               new int[] {1,0},
               new int[] {1,2},
               new int[] {2,1},
               new int[] {2,2},
            };

            Console.WriteLine(test.RemoveStones(stones));
        }
        #endregion

        #region EvaluateDivision
        public static void RunEvaluateDivision()
        {
            EvaluateDivision test = new EvaluateDivision();
            string[][] equations = new string[][]
            {
                new string[] { "a", "b" },
                new string[] { "b", "c" }
            };
            double[] values = { 2.0, 3.0 };
            string[][] queries = new string[][]
            {
                new string[] { "a", "c" },
                new string[] { "b", "a" },
                new string[] { "a", "e" },
                new string[] { "a", "a" },
                new string[] { "x", "x" }
            };

            PrintEnumerable<double>(test.CalcEquation(equations, values, queries));
        }
        #endregion

        #region BackspaceStringCompare
        public static void RunBackspaceStringCompare()
        {
            BackspaceStringCompare test = new BackspaceStringCompare();
            string S = "ab#c##", T = "ad#c##";
            Console.WriteLine(test.BackspaceCompare(S, T));
        }
        #endregion

        #region CountCompleteTreeNodes
        public static void RunCountCompleteTreeNodes()
        {
            CountCompleteTreeNodes test = new CountCompleteTreeNodes();
            TreeNode root = new TreeNode(1);
            TreeNode node2 = new TreeNode(2);
            TreeNode node3 = new TreeNode(3);
            TreeNode node4 = new TreeNode(4);
            TreeNode node5 = new TreeNode(5);
            TreeNode node6 = new TreeNode(6);

            root.left = node2;
            root.right = node3;
            node2.left = node4;
            node2.right = node5;
            node3.left = node6;

            Console.WriteLine(test.CountNodes(root));
        }
        #endregion

        #region CrackingTheSafe
        public static void RunCrackingTheSafe()
        {
            CrackingTheSafe test = new CrackingTheSafe();
            Console.WriteLine(test.CrackSafe(2, 2));
        }
        #endregion

        #region AddAndSearchWord
        public static void RunAddAndSearchWord()
        {
            WordDictionary test = new WordDictionary();
            test.AddWord("bad");
            test.AddWord("dad");
            Console.WriteLine(test.Search("mad"));
            Console.WriteLine(test.Search("pad"));
            Console.WriteLine(test.Search(".ad"));
            Console.WriteLine(test.Search("b.."));
        }
        #endregion

        #region AlienDictionary
        public static void RunAlienDictionary()
        {
            AlienDictionary test = new AlienDictionary();
            string[] words = { "wrt", "wrf", "er", "ett", "rftt" };
            Console.WriteLine(test.AlienOrder(words));
        }
        #endregion

        #region ContiguousArray
        public static void RunContiguousArray()
        {
            ContiguousArray test = new ContiguousArray();
            int[] input = { 0, 1 };
            Console.WriteLine(test.FindMaxLength(input));
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
