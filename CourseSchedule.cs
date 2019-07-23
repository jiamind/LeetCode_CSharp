using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode_CSharp
{
    /// <summary>
    /// 207. Course Schedule
    /// There are a total of n courses you have to take, labeled from 0 to n-1.
    /// Some courses may have prerequisites, for example to take course 0 you have to first take course 1, which is expressed as a pair: [0,1]
    /// Given the total number of courses and a list of prerequisite pairs, is it possible for you to finish all courses?
    /// Example 1:
    /// Input: 2, [[1,0]] 
    /// Output: true
    /// Explanation: There are a total of 2 courses to take.
    /// To take course 1 you should have finished course 0. So it is possible.
    /// Example 2:
    /// Input: 2, [[1,0],[0,1]]
    /// Output: false
    /// Explanation: There are a total of 2 courses to take.
    /// To take course 1 you should have finished course 0, and to take course 0 you should
    /// also have finished course 1. So it is impossible.
    /// Note:
    /// The input prerequisites is a graph represented by a list of edges, not adjacency matrices.Read more about how a graph is represented.
    /// You may assume that there are no duplicate edges in the input prerequisites.
    /// </summary>
    public class CourseSchedule
    {
        public bool CanFinish(int numCourses, int[][] prerequisites)
        {
            // Save the number of prerequisites each course has
            Dictionary<int, int> numOfPreReq = new Dictionary<int, int>();

            // Save the list of courses that depend on each course (e.g. has this course as the prerequiste)
            Dictionary<int, List<int>> coursesDependedOn = new Dictionary<int, List<int>>();
            for (int i = 0; i < numCourses; i++)
            {
                numOfPreReq.Add(i, 0);
                coursesDependedOn.Add(i, new List<int>());
            }

            foreach (int[] prereq in prerequisites)
            {
                numOfPreReq[prereq[0]]++;
                coursesDependedOn[prereq[1]].Add(prereq[0]);
            }

            int numOfCoursesCompleted = 0;
            Queue<int> queue = new Queue<int>();

            // Start with courses that have 0 prerequisite
            List<int> noPreReq = numOfPreReq.Where(c => c.Value == 0).Select(c => c.Key).ToList();
            foreach (int c in noPreReq)
            {
                queue.Enqueue(c);
            }

            while (queue.Any())
            {
                int course = queue.Dequeue();
                // Mark the current course as completed
                numOfCoursesCompleted++;

                // Since we've completed the current course, for all the courses that depends on the current course, their numOfPreReq goes down by 1
                // Then we add those courses which have 0 prerequisite to the queue so that we can take them in the next round
                foreach (int c in coursesDependedOn[course])
                {
                    if (--numOfPreReq[c] == 0)
                    {
                        queue.Enqueue(c);
                    }
                }
            }

            return numOfCoursesCompleted == numCourses;
        }
    }
}
