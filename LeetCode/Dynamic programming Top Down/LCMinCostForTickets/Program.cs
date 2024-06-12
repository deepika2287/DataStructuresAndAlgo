namespace LCMinCostForTickets;

class Program
{
    static void Main(string[] args)
    {
        int[] days = [1,2,3,4,5,6,7,8,9,10,30,31];
        int[] costs = [2,7,15];
        Program p = new Program();
        Console.WriteLine(p.MincostTickets(days,costs));
    }
    public int MincostTickets(int[] days, int[] costs) {
        int[] memo = Enumerable.Repeat(0,days[days.Length-1]+1).ToArray();
        List<int> travelDays = new List<int>(days);
        
        for(int i = 1;i<memo.Length;i++)
        {
            if(!travelDays.Contains(i))
            {
                memo[i] = memo[i-1];
            }
            else
            {
                memo[i] = Math.Min(memo[i-1] + costs[0], Math.Min(memo[Math.Max(0,i-7)]+costs[1],memo[Math.Max(0,i-30)]+costs[2]));
            }
        }
        return memo[memo.Length-1];
    }
    public int Backtrack(List<int> days,int[] costs, int currDay, int[] memo)
    {
        if(currDay > days[days.Count-1])
        {
            return 0;
        }
        if (!days.Contains(currDay)) {
            return Backtrack(days,costs,currDay+1,memo);
        }
        if(memo[currDay] != -1)
        {
            return memo[currDay];
        }
        //1day ticket
        int res1 = Backtrack(days,costs,currDay+1,memo) + costs[0];

        //7day ticket
        int res2 = Backtrack(days,costs, currDay+7,memo) + costs[1];

        //30day ticket
        int res3 = Backtrack(days,costs, currDay+30, memo) + costs[2];

        memo[currDay] = Math.Min(res1, Math.Min(res2,res3));
        return memo[currDay];
    }
}
