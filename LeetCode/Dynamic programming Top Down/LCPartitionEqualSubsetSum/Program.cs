namespace LCPartitionEqualSubsetSum;

class Program
{
    static void Main(string[] args)
    {
        int[] nums = [1,5,11,5];
        //int[] nums = [1,2,3,5];
        Program p = new Program();
        bool res = p.CanPartition(nums);
        Console.WriteLine(res);
    }
    public bool CanPartition(int[] nums) {
        int totalSum = 0;
        for(int i = 0;i<nums.Length;i++)
        {
            totalSum += nums[i];
        }
        if(totalSum%2 != 0)
            return false;

        int targetSum = totalSum/2;
        int[][] memo = new int[nums.Length+1][];
        for(int i = 0;i<nums.Length+1;i++)
        {
            memo[i]= new int[targetSum+1];
            for(int j=0;j<targetSum+1;j++)
            {
                memo[i][j] = -1;
            }
        }
        int r = Backtrack(nums,targetSum,0,memo);
        return r == 1?true:false;
    }
    public int Backtrack(int[] nums,int targetSum, int index, int[][] memo)
    {
        if(targetSum == 0)
        {
            return 1;
        }
        if(index == nums.Length || targetSum < 0)
        {
            return 0;
        }
        if(memo[index][targetSum] != -1)
        {
            return memo[index][targetSum];
        }
        int res1 = Backtrack(nums,targetSum,index+1,memo);
        int res2 = Backtrack(nums,targetSum-nums[index],index+1,memo);

        return memo[index][targetSum] = !(res1 == 0 && res2 == 0) ? 1 : 0;
    }
}
