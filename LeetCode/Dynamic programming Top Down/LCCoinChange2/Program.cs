public class Solution {
    public static void Main(string[] args)
    {
        int amount = 6;
        int[] coins = [2,2,1];
        int res = new Solution().Change(amount,coins);
    }
    int[][] memo;
    public int Change(int amount, int[] coins) {
        memo = new int[coins.Length][];
        for(int i = 0;i<memo.Length;i++)
        {
            memo[i] = new int[amount+1];
            for(int j = 0;j<amount+1;j++)
            {
                memo[i][j] = -1;
            }
        }
        return Backtrack(amount,coins,0);
    }
    public int Backtrack(int amount, int[] coins, int i)
    {
        
        if(amount==0)
            return 1;
        if(i==coins.Length)
            return 0;
        if(memo[i][amount]!=-1)
        {
            return memo[i][amount];
        }
        if(coins[i] > amount)
        {
            return memo[i][amount] = Backtrack(amount,coins,i+1);
        }
        
        memo[i][amount] = Backtrack(amount-coins[i],coins,i) + Backtrack(amount,coins,i+1);

        return memo[i][amount];
    }
}