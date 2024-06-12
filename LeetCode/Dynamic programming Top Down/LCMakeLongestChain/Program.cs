public class Solution {
    public static void Main(string[] args)
    {
        int[][] pairs = [[-1,1],[-2,7],[-5,8],[-3,8],[1,3],[-2,9],[-5,2]];
        //int[][] pairs = [[1,2],[2,3],[5,6]];
        //int[][] pairs = [[7,9],[4,5],[7,9],[-7,-1],[0,10],[3,10],[3,6],[2,3]];
        int res = new Solution().FindLongestChain(pairs);
    }
    int res = 0;
    Dictionary<int, List<List<int>>> memo;
    public int FindLongestChain(int[][] pairs) {
        memo = new Dictionary<int, List<List<int>>>();
        List<List<int>> pq = new List<List<int>>();
        for(int i = 0;i<pairs.Length;i++)
        {
            pq.Add(pairs[i].ToList());
        }
        pq.Sort((a,b)=>a[0]-b[0]);
        /*for(int i = 0;i<pq.Count;i++)
        {
            Console.Write("( "+pq[i][0]+" , "+pq[i][1]+" ) ");
        }
        Console.WriteLine();*/
        List<List<int>> temp = new List<List<int>>();
        temp.Add(new List<int>(pq[pq.Count-1]));
        memo.Add(pq.Count-1,temp);
        for(int i = pq.Count-1;i>=0;i--)
        {
            var a = RecursiveHelper(pq,i);
            if(res < a.Count)
            {
                res = a.Count;
            }
        }
        return res;
    }
    public List<List<int>> RecursiveHelper(List<List<int>> pq, int idx)
    {
        if(memo.ContainsKey(idx))
            return new List<List<int>>(memo[idx]);
            
        for(int i = pq.Count-1;i>idx;i--)
        {
            if(pq[i][0] > pq[idx][1])
            {
                var l = RecursiveHelper(pq,i);   
                if(!memo.ContainsKey(idx))
                {
                    memo.Add(idx,new List<List<int>>(l));
                }
                else
                {
                    if(memo[idx].Count<l.Count+1)
                    {
                        memo[idx] = new List<List<int>>(l);
                    }
                }
                if(!memo[idx].Contains(pq[idx]))
                    memo[idx].Add(pq[idx]);
            }
        }
        if(!memo.ContainsKey(idx))
        {
            memo.Add(idx,new List<List<int>>());
        }
        if(!memo[idx].Contains(pq[idx]))
            memo[idx].Add(pq[idx]);
        //PrintMemo(memo);
        return memo[idx];
    }
    public void PrintMemo(Dictionary<int, List<List<int>>> m)
    {
        foreach(var i in m)
        {
            Console.WriteLine(i.Key);
            for(int j = 0;j<m[i.Key].Count;j++)
            {
                Console.Write("( "+m[i.Key][j][0]+" , "+m[i.Key][j][1]+" ) ");
            }
            Console.WriteLine();
        }
        Console.WriteLine("--------------------");
    }
}