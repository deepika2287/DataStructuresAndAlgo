using System;

namespace LCSearchInRotatedArray
{
    class Program
    {
        
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            int[] nums = new int[]{4,5,6,7,0,1,2};
                                 //5,6,7,0,1,2,4  
                                 //2,4,5,6,7,0,1 
                                 //6,7,0,1,2,4,5
            int target = 0;
            int res = new Program().Search(nums,target);
        }
        public int Search(int[] nums, int target) {
            int resIdx = -1;
            int left = 0;
            int right = nums.Length - 1;
            int pivot;
            //find k
            while(left<=right)
            {
                pivot = (left+right)/2;
                if(nums[pivot]>nums[right])
                {
                    left = pivot+1;
                }
                else
                {
                    right=pivot-1;
                }
            }
            
            return resIdx;
        }
    }
}
