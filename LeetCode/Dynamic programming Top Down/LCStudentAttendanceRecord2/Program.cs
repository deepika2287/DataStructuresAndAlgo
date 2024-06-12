namespace LCStudentAttendanceRecord2;

class Program
{
    static void Main(string[] args)
    {
        Program p = new Program();
        int res = p.CheckRecord(2);
    }

    int mod = 1000000007;
    public int CheckRecord(int n) {
        int[][][] memo = new int[n+1][][];
        for(int i = 0;i<n+1;i++)
        {
            memo[i] = new int[2][];
            for(int j = 0;j<2;j++)
            {
                memo[i][j] = new int[3];
                for(int k = 0;k<3;k++)
                {
                    memo[i][j][k] = -1;
                }
            }
        }
        return CountValidRecords(n,0,0,memo);
    }

    public int CountValidRecords(int n, int numA, int numL, int[][][] memo)
    {
        if(numA>=2 || numL>=3)
            return 0;

        if(n==0)
            return 1;

        if(memo[n][numA][numL] != -1)
            return memo[n][numA][numL];

        int count = 0;

        count = CountValidRecords(n-1,numA,0,memo)%mod;
        count = (count + CountValidRecords(n-1,numA+1,0,memo))%mod;
        count = (count + CountValidRecords(n-1,numA,numL+1,memo))%mod;

        return memo[n][numA][numL] = count;
    }
}
