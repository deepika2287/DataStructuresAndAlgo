namespace LCOnesandZeroes;

class Program
{
    static void Main(string[] args)
    {
        string[] strs = ["10","0001","111001","1","0"];
        int m = 4;
        int n = 3;
        Program p = new Program();
        Console.WriteLine(p.FindMaxForm(strs, m, n));
    }
    public int FindMaxForm(string[] strs, int m, int n) {
        List<(string, DigitCount)> dict = new List<(string, DigitCount)>();
        for(int i = 0;i<strs.Length;i++)
        {
            int n0=0;
            int n1=0;
            string str = strs[i];
            for(int j = 0;j<strs[i].Length;j++)
            {
                if(str[j] == '0')
                {
                    n0++;
                }
                else if(str[j] == '1')
                {
                    n1++;
                }   
            }
            dict.Add(new (str,new DigitCount(n0,n1)));
        }
        int index = strs.Length;
        int[][][] memo = new int[index][][];
        for(int i = 0;i<index;i++)
        {
            memo[i] = new int[m+1][];
            for(int j = 0;j<m+1;j++)
            {
                memo[i][j] = new int[n+1];
                for(int k = 0;k<n+1;k++)
                {
                    memo[i][j][k] = -1;
                }
            }
        }
        return Backtrack(dict,m,n,0,memo);
        //return maxCount;
    }
    public int Backtrack(List<(string,DigitCount)> dict, int m, int n, int index, int[][][] memo)
    {
        if(index == dict.Count )
        {
            return 0;
        }

        if(memo[index][m][n] != -1)
        {
            return memo[index][m][n];
        }
        //not pick
        int res1 = Backtrack(dict,m,n,index+1,memo);
        //pick
        int res2 = -1;
        if(m-dict[index].Item2.num0 >= 0 && n-dict[index].Item2.num1 >= 0)
            res2 = Backtrack(dict,m-dict[index].Item2.num0,n-dict[index].Item2.num1,index+1,memo) + 1;

        memo[index][m][n] = Math.Max(res1,res2);

        return memo[index][m][n];
    }

    public class DigitCount
    {
        public int num0;
        public int num1;
        public DigitCount(int a, int b)
        {
            num0=a;
            num1=b;
        }
    }
}
