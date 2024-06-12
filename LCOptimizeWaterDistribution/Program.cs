public class Solution {
    public static void Main(string[] args)
    {
        int n = 3;
        int[] wells = [1,2,2];
        int[][] pipes = [[1,2,1],[2,3,1]];
        int res = new Solution().MinCostToSupplyWater(n,wells,pipes);
    }
    Edge[] graphEdges;
    int[] parent;
    int[] rank;
    public int MinCostToSupplyWater(int n, int[] wells, int[][] pipes) {
        graphEdges = new Edge[pipes.Length+n];
        for(int i = 0;i<pipes.Length;i++)
        {
            int[] temp = pipes[i];
            graphEdges[i] = new Edge(temp[0],temp[1],temp[2]);
        }
        for(int i = pipes.Length;i<graphEdges.Length;i++)
        {
            int idx = i-pipes.Length;
            graphEdges[i] = new Edge(0, idx+1, wells[idx]);
        }
        Array.Sort(graphEdges);
        parent = new int[n+1];
        rank = new int[n+1];
        int res = 0;
        for(int i = 0;i<n+1;i++)
        {
            parent[i] = i;
            rank[i] = 0;
        }
        int e = 0;
        int a = 0;
        while(e<n)
        {
            Edge nextEdge = graphEdges[a++];
            int x = FindParent(nextEdge.src);
            int y = FindParent(nextEdge.dest);

            if(x!=y)
            {
                Union(x,y);
                res = res+nextEdge.weight;
                e++;
            }
        }
        return res;
    }
    public int FindParent(int i)
    {
        if(parent[i] != i)
        {
            parent[i] = FindParent(parent[i]);
        }
        return parent[i];
    }
    public void Union(int i, int j)
    {
        int iP = FindParent(i);
        int jP = FindParent(j);
        if(rank[iP] < rank[jP])
        {
            parent[iP] = jP;
        }
        else if(rank[iP] > rank[jP])
        {
            parent[jP] = iP;
        }
        else
        {
            parent[jP] = iP;
            rank[iP]++;
        }
    }
    public class Edge : IComparable<Edge>
        {
            public int src;
            public int dest;
            public int weight;
            public Edge(int s, int d, int w)
            {
                src = s; dest = d; weight = w;
            }
            public int CompareTo(Edge edge2)
            {
                return this.weight - edge2.weight;
            }
        }
}