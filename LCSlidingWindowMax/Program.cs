using System;
using System.Collections.Generic;

namespace LCSlidingWindowMax
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            int[] nums = new int[]{3,1,-1,-3,5,3,6,7};
            int[] res = new Program().MaxSlidingWindow(nums,3);
        }
        //using double ended queue deque
        public int[] MaxSlidingWindow(int[] nums, int k) {
            List<int> res = new List<int>();
            LinkedList<int> queue = new LinkedList<int>();
            for(int i = 0;i<nums.Length;i++)
            {
                while(queue.Count>0 && queue.First.Value<i-k+1)
                {
                    queue.RemoveFirst();
                }
                var currentItem = nums[i];
                while(queue.Count>0 && nums[queue.Last.Value]<currentItem)
                {
                    queue.RemoveLast();
                }

                queue.AddLast(i);

                if(i >=k-1 )
                {
                    res.Add(nums[queue.First.Value]);
                }
            }
            return res.ToArray();
        }
        //this approach is getting time out
        /*public int[] MaxSlidingWindow(int[] nums, int k) {
            int[] res = new int[nums.Length-k+1];
            int max = nums[0];
            int maxIdx = 0;
            maxIdx = FindMaxIndex(nums,0,k-1);
            max = nums[maxIdx];
            /*for(int i = 1;i<k;i++)
            {
                if(nums[i]>max)
                {
                    max = nums[i];
                    maxIdx = i;
                }
            }*/
            /*res[0] = max;
            int startIdx = 1;
            int endIdx = startIdx+k-1;
            while(endIdx<nums.Length)
            {
                if(nums[endIdx]<max && maxIdx != startIdx-1)
                {
                    res[startIdx] = max;
                }
                else if(nums[endIdx] >= max)
                {
                    res[startIdx] = nums[endIdx];
                    max = nums[endIdx];
                    maxIdx = endIdx;
                }
                else
                {
                   // max = nums[startIdx];
                   // maxIdx = startIdx;
                    maxIdx = FindMaxIndex(nums,startIdx,endIdx);
                    max = nums[maxIdx];
                    /*for(int i = startIdx;i<=endIdx;i++)
                    {
                        if(nums[i]>max)
                        {
                            max = nums[i];
                            maxIdx = i;
                        }
                    }*/
                    /*res[startIdx] = max;
                }
                startIdx++;
                endIdx++;
            }
            return res;
        }
        public static int FindMaxIndex(int[] nums,int start, int end)
        {
            int res = start;
            int max = nums[start];
            while(start<end)
            {
                if(nums[start]<nums[end])
                {
                    if(max<nums[end])
                    {
                    max = nums[end];
                    res = end;
                    }
                    end--;
                }
                else
                {
                    if(max<nums[start])
                    {
                    max = nums[start];
                    res = start;
                    }
                    start++;
                }
            }
            return res;
        }*/
    }
}
