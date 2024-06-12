using System;
using System.Collections.Generic;
using System.Linq;

namespace LCMinMeetingRooms
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            int[][] intervals = new int[6][];
            intervals[0] = new int[]{1,10};
            intervals[1] = new int[]{2,7};
            intervals[2] = new int[]{3,19};
            intervals[3] = new int[]{8,12};
            intervals[4] = new int[]{10,20};
            intervals[5] = new int[]{11,30};

            Console.WriteLine(new Program().MinMeetingRooms(intervals));
        }
        //prefix sum
        public int MinMeetingRooms(int[][] intervals) {
            int freLength = intervals.Select(x=>x[1]).Max();
            int[] frequency = new int[freLength+1];

            for(int i = 0;i<intervals.Length;i++)
            {
                frequency[intervals[i][0]]++;
                frequency[intervals[i][1]]--;
            }
            int result = frequency[0];
            for(int i = 1;i<frequency.Length;i++)
            {
                frequency[i] += frequency[i-1];
                result = result<frequency[i]?frequency[i]:result;
            }

            return result;
        }
        //heap solution
        /*public int MinMeetingRooms(int[][] intervals) {
            Array.Sort(intervals,(x,y)=>x[0]-y[0]);
            SortedList<int[],int> pq = new SortedList<int[], int>(Comparer<int[]>.Create((a,b)=>
            {
                return a[1] == b[1]? -1 : a[1] - b[1];
            }));

            for(int i = 0;i<intervals.Length;i++)
            {
                if(pq.Count>0 && pq.First().Key[1]<=intervals[i][0])
                {
                    pq.RemoveAt(0);
                }
                pq.Add(intervals[i],1);
            }

            return pq.Count;
        }*/
        //sorting and two pointer solution
        /*public int MinMeetingRooms(int[][] intervals) {
            int[] startIntervals = new int[intervals.Length];
            int[] endIntervals = new int[intervals.Length];
            for(int i = 0;i<startIntervals.Length;i++)
            {
                startIntervals[i] = intervals[i][0];
                endIntervals[i] = intervals[i][1];
            }
            Array.Sort(startIntervals);
            Array.Sort(endIntervals);

            int sPtr = 0;
            int ePtr = 0;
            int usedRooms = 0;
            while(sPtr < startIntervals.Length)
            {
                if(startIntervals[sPtr] >= endIntervals[ePtr])
                {
                    ePtr++;
                    usedRooms--;
                }
                usedRooms++;
                sPtr++;
            }

            return usedRooms;
        }*/
    }
}
