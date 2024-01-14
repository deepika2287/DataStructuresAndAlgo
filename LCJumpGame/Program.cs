using System;
using System.ComponentModel;

namespace LCJumpGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            int[] nums = new int[]{1,1,2,2,0,1};
            //int[] nums = new int[]{3,2,1,0,1};
            //int[] nums = new int[]{3,0,8,2,0,0,1};

            Console.WriteLine(new Program().CanJump(nums));
        }

        public bool CanJump(int[] nums) {
            int lasPos = nums.Length-1;

            for(int i = lasPos-1;i>0;i--)
            {
                if(i+nums[i] >= lasPos)
                {
                    lasPos = i;
                }
            }

            return lasPos == 0;
        }
        /*public bool CanJump(int[] nums) {
            return RecursiveFunction(0,nums);
        }
        public static bool RecursiveFunction(int n, int[] nums)
        {
            if(n == nums.Length-1 )
                return true;
            
            int furthestJump = Math.Min(n+nums[n],nums.Length-1);

            for(int i=n+1;i<=furthestJump;i++)
            {
                if(RecursiveFunction(i,nums))
                    return true;
            }

            return false;
        }*/
    }
}
