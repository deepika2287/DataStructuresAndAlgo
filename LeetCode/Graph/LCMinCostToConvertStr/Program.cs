public class Solution {
    public static void Main(string[] args)
    {
        string source = "abcd";
        string target = "abce";
        char[] original = ['a'];
        char[] changed = ['e'];
        int[] cost = [10000];
        long res = new Solution().MinimumCost(source,target,original,changed,cost);
    }
    Dictionary<int,List<Node>> graph = new Dictionary<int,List<Node>>();
    long[][] memo;
    public long MinimumCost(string source, string target, char[] original, char[] changed, int[] cost) {
        memo = new long[26][];
        for(int i = 0;i<26;i++)
        {
            memo[i] = new long[26];
            for(int j = 0;j<26;j++)
            {
                memo[i][j] = -1;
            }
        }
        for(int i = 0;i<original.Length;i++)
        {
            if(!graph.ContainsKey(original[i]-'a'))
            {
                graph.Add(original[i]-'a',new List<Node>());
            }
            graph[original[i]-'a'].Add(new Node(changed[i]-'a',cost[i]));
        }
        for(int i = 0;i<changed.Length;i++)
        {
            if(!graph.ContainsKey(changed[i]-'a'))
            {
                graph.Add(changed[i]-'a',new List<Node>());
            }
            //graph[original[i]].Add(new Node(changed[i],cost[i]));
        }
        long res = 0;
        for(int i = 0;i<source.Length;i++)
        {
            if(source[i]!=target[i])
            {
                if(memo[source[i]-'a'][target[i]-'a'] == -1)
                {
                    long dist = FindMinDist(source[i]-'a',target[i]-'a');
                    if(dist == int.MaxValue)
                        return -1;
                    res = res+dist;
                    memo[source[i]-'a'][target[i]-'a'] = dist;
                }
                else
                {
                    res = res + memo[source[i]-'a'][target[i]-'a'];
                }
            }
        }
        return res;
    }
    public long FindMinDist(int src, int dest)
    {
        long[] dist = new long[26];
        bool[] visited = new bool[26];
        for(int i = 0;i<dist.Length;i++)
        {
            dist[i] = int.MaxValue;
        }
        //int srcIdx = graph.Keys.ToList().IndexOf(src);
        
        dist[src] = 0;
        for(int i = 0;i<graph.Count-1;i++)
        {
            int s = FindMinFromGraph(dist,visited);
            
            if(s!=-1 && graph.ContainsKey(s))
            {
                List<Node> temp = graph[s];
                visited[s] = true;
                for(int d = 0;d<temp.Count;d++)
                {
                    int idx = temp[d].name;
                    
                    if(!visited[idx] && dist[s] != int.MaxValue && dist[idx]>dist[s]+temp[d].weight)
                    {
                        dist[idx]=dist[s]+temp[d].weight;
                    }
                }
            }
        }
        //int destIdx = graph[dest];
        
        return dist[dest];
    }
    public int FindMinFromGraph(long[] dist,bool[] visited)
    {
        long min = long.MaxValue;
        int minIdx = -1;
        for(int i = 0;i<dist.Length;i++)
        {
            if(!visited[i])
            {
                if(min > dist[i])
                {
                    min = dist[i];
                    minIdx = i;
                }
            }
        }
        return minIdx;
    }
    public class Node
    {
        public int name;
        public long weight;
        public Node(int n, long w)
        {
            name = n;
            weight = w;
        }
    }
}