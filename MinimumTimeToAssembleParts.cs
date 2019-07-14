using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode_CSharp
{
    /// <summary>
    /// Amazon Online Assessment
    /// </summary>
    public class MinimumTimeToAssembleParts
    {
        int min = Int32.MaxValue;

        public int minimumTime(int numOfParts, int[] parts)
        {
            return Assemble(parts);
        }

        private int Assemble(int[] parts)
        {
            if (parts.Length == 2)
            {
                return parts[0] + parts[1];
            }

            int min = Int32.MaxValue;

            for (int i = 0; i < parts.Length - 1; i++)
            {
                for (int j = i + 1; j < parts.Length; j++)
                {
                    List<int> list = new List<int>(parts);
                    list.RemoveAt(j);
                    list.RemoveAt(i);
                    list.Add(parts[i] + parts[j]);
                    int cost = Assemble(list.ToArray()) + parts[i] + parts[j];
                    min = Math.Min(min, cost);
                }
            }

            return min;
        }
    }
}
