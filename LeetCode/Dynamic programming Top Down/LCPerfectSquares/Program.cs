namespace LCPerfectSquares;

class Program
{
    static void Main(string[] args)
    {
        Program p = new Program();
        Console.WriteLine(p.NumSquares(22));
    }
    public int NumSquares(int n) {
        int[] memo = Enumerable.Repeat(-1,n+1).ToArray();
        return Backtrack(n,memo);
    }
    public int Backtrack(int n,int[] memo)
    {
        if(n <= 0)
            return 0;
        if(memo[n] != -1)
            return memo[n];
        int res = 0;
        int ans = int.MaxValue;
        for(int i = 1;i<(int)Math.Sqrt(n)+1;i++)
        {
            res = 1 + Backtrack(n-(i*i),memo);
            ans = Math.Min(ans,res);
        }
        memo[n] = ans;
        return memo[n];
    }
    //DP 2D array. Pick/Not Pick approach
    /*public int NumSquares(int n) {
        if(n==1)
            return 1;
        int a = (int)Math.Sqrt(n) + 1;
        int[][] memo = new int[a+1][];
        for(int i = 0;i<a+1;i++)
        {
            memo[i] = Enumerable.Repeat(-1,n+1).ToArray();
        }
        //
        return Backtrack(n,a,memo);
    }
    public int Backtrack(int n,int a,int[][] memo)
    {
        if(n <= 0)
        {
            return 0;
        }
        if(a<1)
        {
            return int.MaxValue;
        }
        if(memo[a][n] != -1)
        {
            return memo[a][n];
        }
        int res1 = int.MaxValue;
        int res2 = int.MaxValue;
        if(n - (a*a) >= 0)
        {
            res1 = Backtrack(n - (a*a),a,memo) + 1;
        }
        res2 = Backtrack(n,a-1,memo);
        memo[a][n] = Math.Min(res1,res2);
        return memo[a][n];
    }*/
}
