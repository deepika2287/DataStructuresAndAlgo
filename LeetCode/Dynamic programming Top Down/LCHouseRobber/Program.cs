namespace LCHouseRobber;

class Program
{
    static void Main(string[] args)
    {
        int[] nums = [2,7,9,3,1];
        Program p = new Program();
        Console.WriteLine(p.Rob(nums)); 
    }
    
    public int Rob(int[] nums) {
        int[] memo = new int[nums.Length];
        memo[0] = nums[0];
        memo[1] = Math.Max(nums[0],nums[1]);
        for(int i = 2;i<nums.Length;i++)
        {
            memo[i] = Math.Max(memo[i-1], nums[i] + memo[i-2]);
        }
        return memo[memo.Length - 1];
    }
    //top down approach
    /*public int Rob(int[] nums) {
        int[] memo = new int[nums.Length];
        for(int i = 0;i<nums.Length;i++)
        {
            memo[i] = -1;
        }
        RecursiveHelper(nums, 0, memo);
        return memo[0];
    }

    public int RecursiveHelper(int[] nums, int i, int[] memo)
    {
        if(i >= nums.Length)
        {
            return 0;
        }

        if(memo[i] != -1)
            return memo[i];

        memo[i] = Math.Max(RecursiveHelper(nums,i+1,memo), nums[i] + RecursiveHelper(nums,i+2,memo));
        return memo[i];
    }*/
}
