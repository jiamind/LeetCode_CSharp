using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode_CSharp
{
    /// <summary>
    /// 621. Task Scheduler
    /// Given a char array representing tasks CPU need to do. It contains capital letters A to Z where different letters represent different tasks. Tasks could be done without original order. Each task could be done in one interval. For each interval, CPU could finish one task or just be idle.
    /// However, there is a non-negative cooling interval n that means between two same tasks, there must be at least n intervals that CPU are doing different tasks or just be idle.
    /// You need to return the least number of intervals the CPU will take to finish all the given tasks.
    /// Example:
    /// Input: tasks = ["A", "A", "A", "B", "B", "B"], n = 2
    /// Output: 8
    /// Explanation: A -> B -> idle -> A -> B -> idle -> A -> B.
    /// </summary>
    public class TaskScheduler
    {
        /// <summary>
        /// Sort the tasks base on the number of times it appears in the tasks array.
        /// We schedule from the task which appears the most to the least, untill we schedule n + 1 tasks
        /// Then we sort the tasks again, and schedule, until all tasks are depleted.
        /// </summary>
        /// <param name="tasks">the tasks array</param>
        /// <param name="n">the cooling interval</param>
        /// <returns>the least number of intervals the CPU will take to finish all the given tasks</returns>
        public int LeastInterval(char[] tasks, int n)
        {
            int[] taskCounts = new int[26];
            foreach (char c in tasks)
            {
                taskCounts[c - 'A']++;
            }

            Array.Sort(taskCounts);

            int numOfIntervals = 0;

            while (taskCounts[25] != 0)
            {
                int i = 0;

                while (i <= n)
                {
                    // If all tasks are schedule before this iteration is finished, we don't need to schedule idle tasks, just end it
                    if (taskCounts[25] == 0)
                    {
                        break;
                    }

                    //// i < 26: Cooling interval can be greater than 26. In that case, it's beyond the number of different tasks we have, we schedule a idle task
                    //// taskCounts[25 - i] > 0 : there's task left for this type of task. Otherwise, we schedule a idle task
                    if (i < 26 && taskCounts[25 - i] > 0)
                    {
                        taskCounts[25 - i]--;
                    }

                    i++;
                    numOfIntervals++;
                }

                Array.Sort(taskCounts);
            }

            return numOfIntervals;
        }
    }
}
