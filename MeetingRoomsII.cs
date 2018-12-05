﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode_CSharp
{

    public class Interval
    {
        public int start;
        public int end;
        public Interval() { start = 0; end = 0; }
        public Interval(int s, int e) { start = s; end = e; }
    }

    public class MeetingRoomsII
    {
        public class PriorityQueue
        {
            public List<int> list;
            public int Count { get { return list.Count; } }

            public PriorityQueue()
            {
                list = new List<int>();
            }

            public PriorityQueue(int count)
            {
                list = new List<int>(count);
            }


            public void Enqueue(int x)
            {
                list.Add(x);
                int i = Count - 1;

                while (i > 0)
                {
                    int p = (i - 1) / 2;
                    if (list[p] <= x) break;

                    list[i] = list[p];
                    i = p;
                }

                if (Count > 0) list[i] = x;
            }

            public int Dequeue()
            {
                int min = Peek();
                int root = list[Count - 1];
                list.RemoveAt(Count - 1);

                int i = 0;
                while (i * 2 + 1 < Count)
                {
                    int a = i * 2 + 1;
                    int b = i * 2 + 2;
                    int c = b < Count && list[b] < list[a] ? b : a;

                    if (list[c] >= root) break;
                    list[i] = list[c];
                    i = c;
                }

                if (Count > 0) list[i] = root;
                return min;
            }

            public int Peek()
            {
                if (Count == 0) throw new InvalidOperationException("Queue is empty.");
                return list[0];
            }

            public void Clear()
            {
                list.Clear();
            }
        }

        public int MinMeetingRooms(Interval[] intervals)
        {
            PriorityQueue queue = new PriorityQueue();
            intervals = intervals.OrderBy(i => i.start).ToArray();

            foreach (Interval i in intervals)
            {
                if (queue.Count == 0)
                {
                    queue.Enqueue(i.end);
                }
                else
                {
                    int earliestEndTime = queue.Peek();
                    if (earliestEndTime <= i.start)
                    {
                        queue.Dequeue();
                    }

                    queue.Enqueue(i.end);
                }
            }

            return queue.Count;
        }
    }
}
