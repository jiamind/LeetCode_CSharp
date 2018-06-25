using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode_CSharp
{
    class LargestRectangleInHistogram
    {
        /// <summary>
        /// Brute force
        /// Given n non-negative integers representing the histogram's bar height where the width of each bar is 1, 
        /// find the area of largest rectangle in the histogram.
        /// </summary>
        /// <param name="heights">n non-negative integers representing the histogram's bar height</param>
        /// <returns>area of largest rectangle in the histogram</returns>
        public int LargestRectangleArea(int[] heights)
        {
            // If heights is null or nothing in the heights array, return 0 as the area
            if (heights == null || !heights.Any())
            {
                return 0;
            }

            int max = 0;

            // Starting from the first height, for each height, 
            // try expand the rectangle area to the right and find the max area
            for (int i = 0; i < heights.Length - 1; i++)
            {
                int localMax = heights[i];
                int maxLevel = heights[i];

                for (int j = i + 1; j < heights.Length; j++)
                {
                    if (heights[j] >= maxLevel)
                    {
                        localMax += maxLevel;
                    }
                    else
                    {
                        max = max > localMax ? max : localMax;
                        localMax = heights[j] * (j - i + 1);
                        maxLevel = heights[j];
                    }
                }

                max = localMax > max ? localMax : max;
            }

            // The last height alone could be the max area
            return heights[heights.Length - 1] > max ? heights[heights.Length - 1] : max;
        }

        /// <summary>
        /// Given n non-negative integers representing the histogram's bar height where the width of each bar is 1, 
        /// find the area of largest rectangle in the histogram.
        /// </summary>
        /// <param name="heights">n non-negative integers representing the histogram's bar height</param>
        /// <returns>area of largest rectangle in the histogram</returns>
        public int LargestRectangleArea2(int[] heights)
        {
            // If heights is null or nothing in the heights array, return 0 as the area
            if (heights == null || !heights.Any())
            {
                return 0;
            }

            Stack<int> stack = new Stack<int>();
            int max = 0;

            for (int i = 0; i <= heights.Length; i++)
            {
                int height = i == heights.Length ? 0 : heights[i];

                // If the stack is empty, or the current height is greater than the top height in the stack, push the height into the stack.
                // If the current height is lower than the top height in the stack, pop the stack. 
                // Calculate the area of the rectangle using the top height in the stack, times the distance to the current height, since higher heights are popped first before lower height.
                if (!stack.Any() || height >= heights[stack.Peek()])
                {
                    stack.Push(i);
                }
                else
                {
                    int lastHeightIndex = stack.Pop();
                    max = Math.Max(max, heights[lastHeightIndex] * (stack.Any() ? i - 1 - stack.Peek() : i));
                    i--;
                }
            }

            return max;
        }
    }
}
