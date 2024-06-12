namespace LCPalindromePartitioning;

class Program
{
    static void Main(string[] args)
    {
        string s = "aab";
        Program p = new Program();
        var res = p.Partition(s);
        foreach(var item in res)
        {
            foreach(var str in item)
            {
                Console.Write(str + " ");
            }
            Console.WriteLine();
        }
    }
    public IList<IList<string>> Partition(string s) {
        IList<IList<string>> res = new List<IList<string>>();
        int n = s.Length;
        bool[][] memo = new bool[n][];
        for(int i = 0;i<n;i++)
        {
            memo[i] = new bool[n];
        }
        backtrack(s,res,new List<string>(),0,memo);
        
        return res;
    }

    public void backtrack(string s, IList<IList<string>> res, List<string> temp, int i, bool[][] memo)
    {
        if(i == s.Length)
        {
            res.Add(new List<string>(temp));
        }
        else
        {
            for(int j = i;j<s.Length;j++)
            {
                if(s[i] == s[j] && (j-i<=2 || memo[i+1][j-1]))
                {
                    memo[i][j] = true;
                    temp.Add(s.Substring(i,j-i+1));
                    backtrack(s,res,temp,j+1,memo);
                    temp.RemoveAt(temp.Count-1);
                }
            }
        }
    }
    public bool IsPalindrome(string s)
    {
        int i = 0;
        int j = s.Length-1;
        {
            while(i < j)
            {
                if(s[i] != s[j])
                {
                    return false;
                }
                i++;
                j--;
            }
            return true;
        }
    }
}
