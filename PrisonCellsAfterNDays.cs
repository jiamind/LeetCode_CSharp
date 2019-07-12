using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode_CSharp
{
    /// <summary>
    /// 957. Prison Cells After N Days
    /// There are 8 prison cells in a row, and each cell is either occupied or vacant.
    /// Each day, whether the cell is occupied or vacant changes according to the following rules:
    /// If a cell has two adjacent neighbors that are both occupied or both vacant, then the cell becomes occupied.
    /// Otherwise, it becomes vacant.
    /// (Note that because the prison is a row, the first and the last cells in the row can't have two adjacent neighbors.)
    /// We describe the current state of the prison in the following way: cells[i] == 1 if the i-th cell is occupied, else cells[i] == 0.
    /// Given the initial state of the prison, return the state of the prison after N days (and N such changes described above.)
    /// Example 1:
    /// Input: cells = [0,1,0,1,1,0,0,1], N = 7
    /// Output: [0,0,1,1,0,0,0,0]
    /// Explanation: 
    /// The following table summarizes the state of the prison on each day:
    /// Day 0: [0, 1, 0, 1, 1, 0, 0, 1]
    /// Day 1: [0, 1, 1, 0, 0, 0, 0, 0]
    /// Day 2: [0, 0, 0, 0, 1, 1, 1, 0]
    /// Day 3: [0, 1, 1, 0, 0, 1, 0, 0]
    /// Day 4: [0, 0, 0, 0, 0, 1, 0, 0]
    /// Day 5: [0, 1, 1, 1, 0, 1, 0, 0]
    /// Day 6: [0, 0, 1, 0, 1, 1, 0, 0]
    /// Day 7: [0, 0, 1, 1, 0, 0, 0, 0]
    /// Example 2:
    /// Input: cells = [1,0,0,1,0,0,1,0], N = 1000000000
    /// Output: [0,0,1,1,1,1,1,0]
    /// </summary>
    public class PrisonCellsAfterNDays
    {
        public int[] PrisonAfterNDays(int[] cells, int N)
        {
            //// Since the states (combination of state in 8 cells) is finite, state transitions must have a cycle
            //// Represent the cell state using bits of integer, so that we store the last seen day of a state
            Dictionary<int, int> lastSeen = new Dictionary<int, int>();

            int state = 0;
            for (int i = 0; i < 8; i++)
            {
                state |= cells[i] << (7 - i);
            }

            while (N > 0)
            {
                if (lastSeen.ContainsKey(state))
                {
                    // Get the length of the cycle. Skip ahead the days.
                    N %= (lastSeen[state] - N);
                }

                lastSeen[state] = N;

                if (N > 0)
                {
                    N--;
                    state = NextDay(state);
                }
            }

            int[] result = new int[8];
            for (int i = 0; i < 8; i++)
            {
                result[i] = (state & (1 << (7 - i))) > 0 ? 1 : 0;
            }

            return result;
        }

        private int NextDay(int state)
        {
            int nextState = 0;

            for (int i = 5; i >= 0; i--)
            {
                if ((((1 << i + 2) & state) >> i + 2) == (((1 << i) & state) >> i))
                {
                    nextState |= 1 << i + 1;
                }
            }

            return nextState;
        }
    }
}
