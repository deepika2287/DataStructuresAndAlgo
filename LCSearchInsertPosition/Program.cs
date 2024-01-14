using System;

namespace LCSearchInsertPosition
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            
        }
        public int SearchInsert(int[] nums, int target) {
            int idx = -1;
            int left = 0;
            int right = nums.Length -1;
            if(target<nums[0])
                return 0;
            if(target > nums[right])
                return right + 1;
            
            //[1,3,5,6]
            while(left<=right)
            {
                idx = left + (right - left) / 2;
                if(target == nums[idx])
                    return idx;
                if(target > nums[idx])
                    left = idx+1;
                else
                    right = idx-1;
            }
            
            return left;
        }
    }
}
