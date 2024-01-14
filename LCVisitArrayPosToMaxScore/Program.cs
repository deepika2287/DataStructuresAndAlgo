using System;
using System.Linq;

namespace LCVisitArrayPosToMaxScore
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            int[] nums = new int[]{2,3,6,1,9,2};
            //int[] nums = new int[]{2,4,6,8};
            long res = new Program().MaxScore(nums,5);
        }
        public long MaxScore(int[] nums, int x) {
            long res = 0;
            long largestEven = 0;
            long largestOdd = 0;
            if(nums[0]%2==0)
            {
                largestEven = nums[0];
                largestOdd = nums[0] - x;
            }
            else
            {
                largestEven = nums[0] - x;
                largestOdd = nums[0];
            }
            for(int i = 1;i<nums.Length;i++)
            {
                if(nums[i]%2 == 0)
                {
                    largestEven = Math.Max(largestEven + nums[i],largestOdd+nums[i]-x);
                }
                else
                {
                    largestOdd = Math.Max(largestOdd + nums[i], largestEven+nums[i]-x);
                }
                res = Math.Max(largestEven,largestOdd);
            }
            return res;
        }
       /* public long MaxScore(int[] nums, int x) {
            long[] dp = new long[nums.Length];
            dp[0] = nums[0];
            for(int i = 1;i<nums.Length;i++)
            {
                long maxScore = long.MinValue;
                for(int j = 0;j<i;j++)
                {
                    long sum;
                    if((nums[i]%2 == 0 && nums[j]%2 == 0) || (nums[i]%2 == 1 && nums[j]%2 == 1))
                    {
                        sum = dp[j] + nums[i];
                    }
                    else
                    {
                        sum = dp[j] + nums[i] - x;
                    }
                    if(sum>maxScore)
                        maxScore = sum;
                }
                dp[i] = maxScore;
            }
            return dp.ToList().Max();
        }*/
    }
}
