namespace LCUniqueBinarySearchTrees;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
    }
    
    public int NumTrees(int n) {
        int[] memo = Enumerable.Repeat(-1,n+1).ToArray();
        return Backtrack(n,memo);
    }
    public int Backtrack(int n, int[] memo)
    {
        if(n<=1)
        {
            return 1;
        }
        if(memo[n] != -1)
            return memo[n];

        int res = 0;
        for(int i = 1;i<=n;i++)
        {
            res = res + Backtrack(i-1,memo) * Backtrack(n-i,memo);
        }
        return memo[n] = res;
    }
}
