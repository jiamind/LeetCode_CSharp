using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode_CSharp
{
    /// <summary>
    /// 273. Integer to English Words
    /// Convert a non-negative integer to its english words representation. Given input is guaranteed to be less than 231 - 1.
    /// Example 1:
    /// Input: 123
    /// Output: "One Hundred Twenty Three"
    /// Example 2:
    /// Input: 12345
    /// Output: "Twelve Thousand Three Hundred Forty Five"
    /// Example 3:
    /// Input: 1234567
    /// Output: "One Million Two Hundred Thirty Four Thousand Five Hundred Sixty Seven"
    /// Example 4:
    /// Input: 1234567891
    /// Output: "One Billion Two Hundred Thirty Four Million Five Hundred Sixty Seven Thousand Eight Hundred Ninety One"
    /// </summary>
    public class IntegerToEnglishWords
    {
        private string[] thousands = { string.Empty, "Thousand", "Million", "Billion" };

        private string[] lessThanTwenty = { string.Empty, "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Nineteen" };

        private string[] tens = { string.Empty, string.Empty, "Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety" };

        public string NumberToWords(int num)
        {
            if (num == 0)
            {
                return "Zero";
            }

            StringBuilder sb = new StringBuilder();

            int i = 0;
            while (num > 0)
            {
                if (num % 1000 != 0)
                {
                    sb.Insert(0, PrintLessThanThousand(num % 1000) + " " + thousands[i] + " ");
                }

                num /= 1000;
                i++;
            }

            return sb.ToString().Trim();
        }

        private string PrintLessThanThousand(int num)
        {
            if (num < 20)
            {
                return lessThanTwenty[num];
            }

            if (num < 100)
            {
                return (tens[num / 10] + " " + PrintLessThanThousand(num % 10)).Trim();
            }

            return (lessThanTwenty[num / 100] + " Hundred " + PrintLessThanThousand(num % 100)).Trim();
        }
    }
}
