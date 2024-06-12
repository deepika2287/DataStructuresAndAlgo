namespace LCGetEqualSubstringsWithinBudget;

class Program
{
    static void Main(string[] args)
    {
        string s = "krrgw";
        string t = "zjxss";
        Program p = new Program();
        p.EqualSubstring(s,t,19);
    }
    //prefix sum
    public int EqualSubstring(string s, string t, int maxCost) {
        int[] cost = new int[s.Length];
        for(int i = 0;i<s.Length;i++)
        {
            cost[i] = Math.Abs(s[i]-t[i]);
            Console.Write(cost[i] + " ");
        }
        Console.WriteLine();
        int[] prefixSum = new int[cost.Length+1];
        prefixSum[0]  = 0;
        Console.Write(prefixSum[0] + " ");
        for(int i = 1;i<prefixSum.Length;i++)
        {
            prefixSum[i] = prefixSum[i-1] + cost[i-1];
            Console.Write(prefixSum[i] + " ");
        }
        int maxLen = 0;
        int l = 0;

        for(int i = 1;i<prefixSum.Length;i++)
        {
            while(l<i && prefixSum[i] - prefixSum[l] > maxCost)
            {
                l++;
            }
            maxLen = Math.Max(maxLen, i - l);
        }

        return maxLen;
    }

    //sliding window
    /*public int EqualSubstring(string s, string t, int maxCost) {
        int start = 0;
        int currentCost = 0;
        int maxLen = 0;
        for(int i = 0;i<s.Length;i++)
        {
            currentCost = currentCost + (Math.Abs(s[i]-t[i]));

            while(currentCost > maxCost)
            {
                currentCost = currentCost - (Math.Abs(s[start]-t[start]));
                start++;
            }

            maxLen = Math.Max(maxLen, i - start + 1);
        }

        return maxLen;
    }*/
}
