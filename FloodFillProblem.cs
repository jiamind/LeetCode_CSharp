using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode_CSharp
{
    /// <summary>
    /// 733. Flood Fill
    /// An image is represented by a 2-D array of integers, each integer representing the pixel value of the image (from 0 to 65535).
    /// Given a coordinate(sr, sc) representing the starting pixel(row and column) of the flood fill, and a pixel value newColor, "flood fill" the image.
    /// To perform a "flood fill", consider the starting pixel, plus any pixels connected 4-directionally to the starting pixel of the same color as the starting pixel, plus any pixels connected 4-directionally to those pixels (also with the same color as the starting pixel), and so on.Replace the color of all of the aforementioned pixels with the newColor.
    /// At the end, return the modified image.
    /// Example 1:
    /// Input: 
    /// image = [[1, 1, 1], [1,1,0], [1,0,1]]
    /// sr = 1, sc = 1, newColor = 2
    /// Output: [[2,2,2],[2,2,0],[2,0,1]]
    /// Explanation: 
    /// From the center of the image(with position (sr, sc) = (1, 1)), all pixels connected
    /// by a path of the same color as the starting pixel are colored with the new color.
    /// Note the bottom corner is not colored 2, because it is not 4-directionally connected
    /// to the starting pixel.
    /// </summary>
    public class FloodFillProblem
    {
        public int[][] FloodFill(int[][] image, int sr, int sc, int newColor)
        {
            if (image == null || image.Length <= 0 || image[0].Length <= 0)
            {
                return image;
            }

            if (sr < 0 || sr >= image.Length)
            {
                return image;
            }

            if (sc < 0 || sc >= image[0].Length)
            {
                return image;
            }

            if (image[sr][sc] == newColor)
            {
                return image;
            }

            this.Fill(image, sr, sc, newColor);

            return image;
        }

        private void Fill(int[][] image, int row, int column, int color)
        {
            int originalColor = image[row][column];
            image[row][column] = color;
            if (row - 1 >= 0 && image[row - 1][column] == originalColor)
            {
                Fill(image, row - 1, column, color);
            }

            if (row + 1 < image.Length && image[row + 1][column] == originalColor)
            {
                Fill(image, row + 1, column, color);
            }

            if (column - 1 >= 0 && image[row][column - 1] == originalColor)
            {
                Fill(image, row, column - 1, color);
            }

            if (column + 1 < image[0].Length && image[row][column + 1] == originalColor)
            {
                Fill(image, row, column + 1, color);
            }
        }
    }
}
