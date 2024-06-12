public class Solution {
    public static void Main(string[] args)
    {
        int[] nums = [1,2,3];
        int target = 4;
        int res = new Solution().CombinationSum4(nums,target);
    }
    Dictionary<int,int> memo;
    public int CombinationSum4(int[] nums, int target) {
        memo = new Dictionary<int,int>();
        Backtrack(target,nums);
        return memo[target];
    }
    public int Backtrack(int amount, int[] coins)
    {
        if(amount == 0)
        {
            return 1;
        }
        if(memo.ContainsKey(amount))
            return memo[amount];
        
        int res = 0;
        for(int i = 0;i<coins.Length;i++)
        {
            if(amount - coins[i] >=0)
            {
                res = res + Backtrack(amount-coins[i],coins);
            }
        }
        memo.Add(amount,res);
        return res;
    }
}