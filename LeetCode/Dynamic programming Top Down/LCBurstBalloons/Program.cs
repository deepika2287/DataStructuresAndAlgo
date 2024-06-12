public class Solution {
    public static void Main(string[] args)
    {
        int[] nums = [3,1,5,8];
        int res = new Solution().MaxCoins(nums);
    }
    int[][] memo;
    public int MaxCoins(int[] nums) {
        if(nums.Length == 1)
         return nums[0];
        memo = new int[nums.Length+2][];
        for(int i = 0;i<nums.Length+2;i++)
        {
            memo[i] = new int[nums.Length+2];
            for(int j = 0;j<nums.Length+2;j++)
            {
                memo[i][j] = -1;
            }
        }
        int[] newNums = new int[nums.Length + 2];
        newNums[0] = 1;
        newNums[newNums.Length-1] = 1;
        for(int i = 0;i<nums.Length;i++)
        {
            newNums[i+1] = nums[i];
        }
        Backtrack(newNums,1,newNums.Length-2);
        return memo[1][newNums.Length-2];
        //return maxSum;
    }
    public int Backtrack(int[] nums, int left, int right)
    {
        if(right<left)
        {return 0;}
        if(memo[left][right] != -1)
            return memo[left][right];
        
        int coins = 0;
        for(int i = left;i<=right;i++)
        {
                int gain = (nums[left-1] * nums[right+1] * nums[i]);
                int remaining = Backtrack(nums,i+1,right) + Backtrack(nums,left,i-1);
                coins = Math.Max(coins, gain+remaining);
        }
        memo[left][right] = coins;
        return coins;
    }
}