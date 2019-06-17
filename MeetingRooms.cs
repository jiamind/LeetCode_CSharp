using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode_CSharp
{
    /// <summary>
    /// 252. Meeting Rooms
    /// Given an array of meeting time intervals consisting of start and end times [[s1,e1],[s2,e2],...] (si < ei), determine if a person could attend all meetings.
    /// Example 1:
    /// Input: [[0,30],[5,10],[15,20]]
    /// Output: false
    /// Example 2:
    /// Input: [[7,10],[2,4]]
    /// Output: true
    /// </summary>
    public class MeetingRooms
    {
        public bool CanAttendMeetings(int[][] intervals)
        {
            if (intervals == null || intervals.Length == 0)
            {
                return true;
            }

            Array.Sort(intervals, (x, y) => x[0].CompareTo(y[0]));
            for (int i = 1; i < intervals.Length; i++)
            {
                if (intervals[i][0] < intervals[i - 1][1])
                {
                    return false;
                }
            }

            return true;
        }
    }
}
