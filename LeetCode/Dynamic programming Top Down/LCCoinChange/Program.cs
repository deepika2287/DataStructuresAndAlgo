using System;
using System.Collections.Generic;
using System.Linq;

namespace LCCoinChange
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] coins = new int[]{2,5,10,1};
            int amount = 27;
            int res = new Program().CoinChange(coins,amount);
            Console.WriteLine(res);
        }

        public int CoinChange(int[] coins, int amount) {
            int[][] memo = new int[coins.Length][];
            for (int i = 0;i<coins.Length;i++)
            {
                memo[i] = Enumerable.Repeat(-1,amount+1).ToArray();
            }
            int ans = Backtrack(coins,amount,coins.Length-1,memo);
            return ans ;
        }
        public int Backtrack(int[] coins, int amount, int index, int[][] memo)
        {
            if(amount == 0)
                return 0;

            if(index < 0)
                return int.MaxValue;

            if(memo[index][amount] != -1)
                return memo[index][amount];
            
            int ans = -1;
            if(amount < coins[index])
            {
                ans = Backtrack(coins,amount,index-1,memo);
            }
            else
            {
                int res1 = Backtrack(coins,amount,index-1,memo);
                int res2 = 1 + Backtrack(coins,amount-coins[index],index,memo);
                ans = Math.Min(res1,res2);
            }
            return memo[index][amount] = ans;
        } 
        /*public int CoinChange(int[] coins, int amount) {
            Dictionary<int,int> memo = new Dictionary<int,int>();
            memo.Add(0,0);
            CoinChangeHelper(coins,amount,memo);
            
            return memo[amount] == Int32.MaxValue?-1:memo[amount];
        }
        public int CoinChangeHelper(int[] coins, int amount,Dictionary<int,int> memo)
        {
            if(memo.ContainsKey(amount) && memo[amount]!=-1)
                return memo[amount];
            if(amount == 0)
            {
                return memo[0]; 
            }
            if(amount<0)
                return -1;
            int shortestCount = Int32.MaxValue;
            for(int i = 0;i<coins.Length;i++)
            {
                if(!memo.ContainsKey(amount))
                    memo.Add(amount,-1);
                int count = CoinChangeHelper(coins,amount-coins[i],memo);
                if(count != -1 && count != Int32.MaxValue && shortestCount>count+1)
                    shortestCount = count+1;
            }
            memo[amount] = shortestCount;
            return memo[amount];
        }*/
    }
}
