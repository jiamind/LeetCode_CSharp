using System;
namespace LeetCode_CSharp
{
    /// <summary>
    /// Given an integer, write a function to determine if it is a power of two.
    /// </summary>
    public class PowerOfTwo
    {
        public bool IsPowerOfTwo(int n)
        {
            /// If the number is less than or equal to 0
            /// returns false
            if (n <= 0)
            {
                return false;
            }

            // If the number is between 0 and 1, it could be 2 to the power of a negative number
            if (n < 1)
            {
                return IsPowerOfTwo(1 / n);
            }

            // If the number is 1, return true
            if (n == 1)
            {
                return true;
            }

            // If the number cannot be devided by 2, return false
            if (n % 2 != 0)
            {
                return false;
            }

            return IsPowerOfTwo(n / 2);
        }

        public bool IsPowerOfTwo2(int n)
        {
            return n > 0 && (n & (n - 1)) == 0;
        }
    }
}
