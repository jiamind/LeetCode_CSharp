using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode_CSharp
{
    /// <summary>
    /// 29. Divide Two Integers
    /// Given two integers dividend and divisor, divide two integers without using multiplication, division and mod operator.
    /// Return the quotient after dividing dividend by divisor.
    /// The integer division should truncate toward zero.
    /// Example 1:
    /// Input: dividend = 10, divisor = 3
    /// Output: 3
    /// Example 2:
    /// Input: dividend = 7, divisor = -3
    /// Output: -2
    /// </summary>
    public class DivideTwoIntegers
    {
        public int Divide(int dividend, int divisor)
        {
            // Any dividend divide by 1 is the dividend itself
            if (divisor == 1)
            {
                return dividend;
            }

            //// Any dividend (except for the int.MinValue) divide by -1 is the negative of the dividend itself
            //// The negative of int.MinValue will overflow. Return int.MaxValue instead
            if (divisor == -1)
            {
                return dividend == int.MinValue ? int.MaxValue : -dividend;
            }

            bool negative = (dividend < 0) != (divisor < 0);
            int negDividend = dividend > 0 ? -dividend : dividend;
            int negDivisor = divisor > 0 ? -divisor : divisor;

            return negative ? -DivideNegatives(negDividend, negDivisor) : DivideNegatives(negDividend, negDivisor);
        }

        public int DivideNegatives(int dividend, int divisor)
        {
            // If the dividend is the same as divisor, return 1
            if (dividend == divisor)
            {
                return 1;
            }

            // If the dividend (negative value) is greater than the divisor (negative value), the int result is 0 (actual result between 0 and 1)
            if (dividend > divisor)
            {
                return 0;
            }

            int shift = 1;

            // Shift the divisor to the left, until it is less than the dividend (note: the devisor and dividend should all be negative value)
            while ((divisor << shift) >= dividend && (divisor << shift) < 0)
            {
                shift++;
            }

            // The quotient is how many time we shifted, recursive divide the reminder
            return (1 << (shift - 1)) + DivideNegatives(dividend - (divisor << (shift - 1)), divisor);
        }
    }
}
