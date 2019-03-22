using System;
using System.Text;

namespace LeetCode_CSharp
{
    /// <summary>
    /// Given two non-negative integers num1 and num2 represented as string, return the sum of num1 and num2.
    /// Note:
    /// The length of both num1 and num2 is < 5100.
    /// Both num1 and num2 contains only digits 0-9.
    /// Both num1 and num2 does not contain any leading zero.
    /// You must not use any built-in BigInteger library or convert the inputs to integer directly.
    /// </summary>
    public class AddStringsProblem
    {
        public string AddStrings(string num1, string num2)
        {
            if (num1.Equals("0"))
            {
                return num2;
            }

            if (num2.Equals("0"))
            {
                return num1;
            }

            int min = Math.Min(num1.Length, num2.Length);

            StringBuilder sb = new StringBuilder();
            char[] array1 = num1.ToCharArray();
            char[] array2 = num2.ToCharArray();

            int carry = 0;
            for (int i = 1; i <= min; i++)
            {
                int s = int.Parse(array1[array1.Length - i].ToString()) + int.Parse(array2[array2.Length - i].ToString());
                s += carry;
                carry = s >= 10 ? s / 10 : 0;
                s %= 10;
                sb.Append(s);
            }

            char[] longerStr = array1.Length > array2.Length ? array1 : array2;
            char[] str = this.AddStrings(new string(longerStr, 0, longerStr.Length - min), carry.ToString()).ToCharArray();
            for (int i = str.Length - 1; i >= 0; i--)
            {
                sb.Append(str[i]);
            }

            char[] result = sb.ToString().ToCharArray();
            Array.Reverse(result);
            return new string(result);
        }
    }
}
