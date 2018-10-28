using System.Collections.Generic;

namespace LeetCode_CSharp
{
    /// <summary>
    /// Given a sorted integer array without duplicates, return the summary of its ranges.
    /// </summary>
    public class SummaryRangesProblem
    {
        public IList<string> SummaryRanges(int[] nums)
        {
            IList<string> result = new List<string>();
            // If input is null or input length is 0, return empty list
            if (nums == null || nums.Length == 0)
            {
                return result;
            }

            // Keep the start number of an interval
            int? start = null;
            for (int i = 0; i < nums.Length; i++)
            {
                if (start == null)
                {
                    start = nums[i];
                }
                else
                {
                    // If non-consecutive numbers are detected
                    if (nums[i] - nums[i - 1] != 1)
                    {
                        if (start == nums[i - 1])
                        {
                            result.Add($"{start}");
                        }
                        else
                        {
                            result.Add($"{start}->{nums[i - 1]}");
                        }

                        // Set start number to null to indicate readiness for a new interval
                        start = null;
                        i--;
                    }
                }
            }

            if (start != null)
            {
                if (nums[nums.Length - 1] == start)
                {
                    result.Add($"{start}");
                }
                else
                {
                    result.Add($"{start}->{nums[nums.Length - 1]}");
                }
            }

            return result;
        }

        public IList<string> SummaryRanges2(int[] nums)
        {
            IList<string> result = new List<string>();
            for(int i = 0, j = 0; j < nums.Length; j++)
            {
                if (j + 1 < nums.Length && nums[j+1] == nums[j] + 1)
                {
                    continue;
                }

                if (i == j)
                {
                    result.Add($"{nums[i]}");
                }
                else
                {
                    result.Add($"{nums[i]}->{nums[j]}");
                }

                i = j + 1;
            }

            return result;
        }
    }
}
