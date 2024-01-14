using System;

namespace LCFindPeakElement
{
    class Program
    {
        public int resIdx = -1;
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            int[] nums = new int[]{3,2,1};
            int idx = new Program().FindPeakElement(nums);
        }
        public int FindPeakElement(int[] nums) {
            RecursiveFind(nums,0,nums.Length-1);
            return resIdx;
        }
        public void RecursiveFind(int[] nums,int lo, int hi)
        {
            int mid = (lo+hi)/2;
            if(mid-1>=0 && mid+1<=nums.Length-1)
            {
                if(nums[mid]>nums[mid-1] && nums[mid]>nums[mid+1])
                {
                    resIdx = mid;
                    return;
                }
            }
            if(mid == 0 && mid+1<=nums.Length-1)
            {
                if(nums[mid]>nums[mid+1])
                {
                    resIdx = mid;
                    return;
                }
            }
            if(mid == nums.Length-1 && mid-1>=0)
            {
                if(nums[mid]>nums[mid-1])
                {
                    resIdx = mid;
                    return;
                }
            }
            
            if(resIdx == -1)
            {
                if(mid+1<=nums.Length-1 && mid+1<=hi)
                    RecursiveFind(nums,mid+1,hi);
                if(mid-1>=0 && lo<=mid-1)
                    RecursiveFind(nums,lo,mid-1);
            }
        }
    }
}
