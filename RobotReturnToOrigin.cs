using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode_CSharp
{
    /// <summary>
    /// There is a robot starting at position (0, 0), the origin, on a 2D plane. Given a sequence of its moves, judge if this robot ends up at (0, 0) after it completes its moves.
    /// The move sequence is represented by a string, and the character moves[i] represents its ith move.Valid moves are R (right), L (left), U (up), and D (down). If the robot returns to the origin after it finishes all of its moves, return true. Otherwise, return false.
    /// Note: The way that the robot is "facing" is irrelevant. "R" will always make the robot move to the right once, "L" will always make it move left, etc.Also, assume that the magnitude of the robot's movement is the same for each move.
    /// </summary>
    public class RobotReturnToOrigin
    {
        public bool JudgeCircle(string moves)
        {
            int horizontalDistance = 0, verticalDistance = 0;
            foreach (char c in moves)
            {
                switch (c)
                {
                    case 'U':
                        verticalDistance++;
                        break;
                    case 'D':
                        verticalDistance--;
                        break;
                    case 'R':
                        horizontalDistance++;
                        break;
                    case 'L':
                        horizontalDistance--;
                        break;
                    default:
                        break;
                }
            }

            return horizontalDistance == 0 && verticalDistance == 0;
        }
    }
}
