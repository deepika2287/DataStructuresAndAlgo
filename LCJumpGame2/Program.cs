using System;

namespace LCJumpGame2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            int[] nums = new int[]{2,0,1,1,4};
            //int[] nums = new int[]{1,2,3};
            int count = new Program().Jump(nums);
        }
        //dynamic programming approach
        public int Jump(int[] nums) {
            int[] dp = new int[nums.Length];
            for(int i = 1;i<nums.Length;i++)
            {
                for(int j = 0;j<i;j++)
                {
                    if(j+nums[j] >= i)
                        dp[i] = 1+dp[j];
                        break;
                }
            }
            return dp[nums.Length-1];
        }
        //greedy approach
        /*public int Jump(int[] nums) {
            if(nums.Length == 0 || nums.Length == 1)
                return 0;

            int highJump = 0;
            int jumps = 0; 
            int currPos = 0;

            for(int i = 0;i<nums.Length;i++)
            {
                highJump = Math.Max(highJump,i+nums[i]);
                if(highJump >= nums.Length-1)
                    return jumps+1;
                
                if(i == currPos)
                {
                    currPos = highJump;
                    jumps++;
                }
            }

            return 0;
        }*/

        //recursive approach getting timed out
        /*public int Jump(int[] nums) {
            //int maxJump = 0;
            if(nums[0] == 0)
                return 0;
            int[] maxJump = new int[nums.Length];
            for(int i = 0;i<maxJump.Length;i++)
            {
                maxJump[i] = 0;
            }
            maxJump[maxJump.Length-1] = int.MaxValue;
            int count = 0;
            int res = FindMin(0,nums,count,maxJump);
            return maxJump[maxJump.Length-1];
        }
        public static int FindMin(int start, int[] nums,int count, int[] maxJump)
        {
            if(start >= nums.Length-1)
                return maxJump[nums.Length-1];
            
            int tempCount = int.MaxValue-1;
            for(int i = start+1;i<=nums[start]+start && i<nums.Length;i++)
            {
                int res =  FindMin(i,nums,count+1,maxJump);
                tempCount = Math.Min(res,count+1);
                maxJump[i] = Math.Min(tempCount,maxJump[i]);;
            }
            
            return maxJump[start];
        }*/
    }
}
