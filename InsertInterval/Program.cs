using System;
using System.Collections.Generic;
using System.Linq;

namespace InsertInterval
{
    class Program
    {
        static void Main(string[] args)
        {
            
            //int[][] intervals = new int[][]{
            //    new int[]{1,3},
            //    new int[]{4,6},
            //    new int[]{8,10},
            //    new int[]{13,17},
            //    new int[]{14,16},
            //    new int[]{16,20},
            //    new int[]{21,23}
            //    };
            //int[] newInterval = new int[]{4,8};
            int[][] intervals = new int[][]{
                new int[]{2,3},
                new int[]{2,2},
                new int[]{3,3},
                new int[]{1,3},
                new int[]{5,7},
                new int[]{2,2},
                new int[]{4,6}
                };

            Program p =new Program();
            p.Merge(intervals);
            Console.WriteLine("Hello World!");
        }

        public int[][] Merge(int[][] intervals) {
            if(intervals.Length <= 1)
                return intervals;
            
            var sortedArray = intervals.OrderBy(y=>y[0]).ToArray();

            List<int[]> res = new List<int[]>();
            int i = 1;
            int[] newInterval = new int[2];
            
            while(i<=intervals.Length)
            {
                if(i<intervals.Length && sortedArray[i][0] <= sortedArray[i-1][1])
                {  
                    newInterval[0] = int.MaxValue;
                    newInterval[1] = int.MinValue; 
                    while(i<intervals.Length && (sortedArray[i][0] <= sortedArray[i-1][1] || sortedArray[i][0] <= newInterval[1]))   
                    {     
                        newInterval[0] = Math.Min(newInterval[0],Math.Min(sortedArray[i][0], sortedArray[i-1][0]));
                        newInterval[1] = Math.Max(newInterval[1],Math.Max(sortedArray[i-1][1],sortedArray[i][1]));
                        i++;
                    }
                    res.Add(newInterval);
                }
                else
                {
                    res.Add(sortedArray[i-1]);                  
                }
                i++;
            }

            return res.ToArray();
        }

        
    }
}
